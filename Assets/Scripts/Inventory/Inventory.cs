using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject inventoryUI;
    public List<Item> itemList;

    public delegate void OnInventoryChange();
    public OnInventoryChange inventoryChange;
    private List<Item> showedItems;

    private int gold;
    
    public int Gold
    {
        get
        {
            return gold;
        }
    }
    public List<Item> ShowedItems
    {
        get
        {
            return showedItems;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gold = 100;
        ToggleInventory(false);
        //FilterList("All");
    }
    private void OnLevelWasLoaded(int level)
    {
        ToggleInventory(false);
        FilterList("All");
        //inventoryUI = FindObjectOfType<InventoryUI>().gameObject;
        //ToggleInventory(false);
    }

    private void Update()
    {
        if (!InputManager.isPaused && InputManager.GetInventory())
        {
            ToggleInventory(true);
        }
        else if (InputManager.isPaused && InputManager.GetInventory() && !InputManager.shopOpened)
        {
            ToggleInventory(false);
        }
    }
    /// <summary>
    /// Checks the item type and adds it to the corresponding list
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(Item item)
    {
        switch (item.type)
        {
            case ItemSlot.Hood:
                if (showedItems != itemList)
                {
                    showedItems.Add(HoodObject.CreateItem((HoodObject)item));
                }
                itemList.Add(HoodObject.CreateItem((HoodObject)item));
                break;
            case ItemSlot.Face:
                if (showedItems != itemList)
                {
                    showedItems.Add(HoodObject.CreateItem((HoodObject)item));
                }
                itemList.Add(FaceObject.CreateItem((FaceObject)item));
                break;
            case ItemSlot.Chest:
                if (showedItems != itemList)
                {
                    showedItems.Add(HoodObject.CreateItem((HoodObject)item));
                }
                itemList.Add(ChestObject.CreateItem((ChestObject)item));
                break;
            case ItemSlot.Leg:
                if (showedItems != itemList)
                {
                    showedItems.Add(HoodObject.CreateItem((HoodObject)item));
                }
                itemList.Add(LegsObject.CreateItem((LegsObject)item));
                break;
            default:
                break;
        }
        inventoryChange.Invoke();
    }
    //public void FilterList()
    //{
    //    showedItems = itemList;
    //    inventoryChange.Invoke();
    //}
    public void FilterList(string itemSlot)
    {
        if (itemSlot == "All")
        {
            showedItems = itemList;
        }
        else
        {
        showedItems = Filter(itemSlot);
        }
        if(inventoryChange != null)
            inventoryChange.Invoke();
    }
    private List<Item> Filter(string itemSlot)
    {
        List<Item> returnList = new List<Item>();
        ItemSlot aux = new ItemSlot();
        switch (itemSlot)
        {
            case "Hood":
                aux = ItemSlot.Hood;
                break;
            case "Face":
                aux = ItemSlot.Face;
                break;
            case "Chest":
                aux = ItemSlot.Chest;
                break;
            case "Leg":
                aux = ItemSlot.Leg;
                break;
            default:
                break;
        }

        foreach (Item item in itemList)
        {
            if (item.type == aux)
            {
                returnList.Add(item);
            }
        }
        return returnList;
    }
    public bool Pay(int amount)
    {
        if (amount <= Gold)
        {
            gold -= amount;
            return true;
        }
        else
        {
            Debug.Log("not enough money");
            return false;
        }
    }
    public void GetPayed(int amount)
    {
        gold += amount;
    }
    public void RemoveItem(Item item)
    {
        if (showedItems != itemList)
        {
            showedItems.Remove(item);
        }
        itemList.Remove(item);
        inventoryChange.Invoke();
    }
    public void ToggleInventory(bool toggle)
    {
        InputManager.isPaused = toggle;
        if (!inventoryUI) return;
        inventoryUI.SetActive(toggle);
    }
    public void UnEquipAll(ItemSlot itemSlot)
    {
        foreach (Item item in itemList)
        {
            if (item.type == itemSlot)
            {
                item.Equiped = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shop;

    public List<Item> itemsOnSale;
    public delegate void OnShopUpdate();
    public OnShopUpdate shopUpdate;

    private bool isInside;
    private List<Item> showedItems;

    public List<Item> ShowedItems
    {
        get
        {
            return showedItems;
        }
    }
    private void Start()
    {
        showedItems = itemsOnSale;
        if (itemsOnSale.Count <= 0)
        {
            itemsOnSale = Manager.instance.LoadedItems;
            ShopUI.instance.SetUpShop();
        }

        InputManager.shopOpened = InputManager.CheckScene("Shop scene");

        foreach (Item item in itemsOnSale)
        {
            item.Equiped = false;
        }
        FilterList("All");
    }
    // Update is called once per frame
    void Update()
    {
        if (isInside && InputManager.GetInteract() && !InputManager.isPaused)
        {
            Interact(true);
        }
        else if (isInside && InputManager.GetInteract() && InputManager.isPaused)
        {
            Interact(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInside = true;
        }
        Manager.instance.LoadedItems = this.ShowedItems;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInside = false;
        }
        shop.SetActive(false);
        Inventory.instance.ToggleInventory(false);
        Manager.instance.LoadedItems = null;
    }
    public void Interact(bool toggle)
    {
        Debug.Log("Interacted");
        InputManager.LoadScene("Shop scene");
    }
    public void Buy(Item item)
    {
        if (Inventory.instance.Pay(item.cost))
        {
            Inventory.instance.AddItem(item);
            //itemsOnSale.Remove(item);
            if (shopUpdate != null)
                shopUpdate.Invoke();
        }
    }
    public void Sell(Item item)
    {
        if (!item.Equiped)
        {
        Inventory.instance.GetPayed(item.cost);
        Inventory.instance.RemoveItem(item);
            //itemsOnSale.Add(item);
            if (shopUpdate != null)
                shopUpdate.Invoke();
        }
        else
        {
            Debug.Log("Item equiped");
        }
    }
    public void FilterList(string itemSlot)
    {
        if (itemSlot == "All")
        {
            showedItems = itemsOnSale;
        }
        else
        {
            showedItems = Filter(itemSlot);
        }
        if(shopUpdate != null)
            shopUpdate.Invoke();
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

        foreach (Item item in itemsOnSale)
        {
            if (item.type == aux)
            {
                returnList.Add(item);
            }
        }
        return returnList;
    }
}

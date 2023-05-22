using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform itemParents;
    public Text goldText;

    private Inventory inventory;
    private InventorySlot[] slots;

    // Start is called before the first frame update
    void Start() //Start()
    {
        inventory = Inventory.instance;
        inventory.inventoryUI = this.gameObject;
        inventory.inventoryChange += UpdateUI;
        inventory.inventoryChange += UpdateGold;
        inventory.inventoryChange.Invoke();
        inventory.ToggleInventory(false);
        inventory.FilterList("All");
    }
    private void OnDestroy()
    {
        inventory.inventoryChange -= UpdateUI;
        inventory.inventoryChange -= UpdateGold;
    }
    private void OnEnable()
    {
        slots = itemParents.GetComponentsInChildren<InventorySlot>();
        
        
    }
    public void UpdateGold()
    {
        goldText.text = inventory.Gold.ToString();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (inventory.ShowedItems != null && i < inventory.ShowedItems.Count)
            {
                slots[i].AddItem(inventory.ShowedItems[i]);
                Debug.Log("Item added");
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}

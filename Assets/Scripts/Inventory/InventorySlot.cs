using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public GameObject cost;
    public Text costText;

    private Item item;

    public void AddItem(Item addItem)
    {
        item = addItem;

        icon.sprite = item.logo;
        icon.enabled = true;

        if (cost != null)
        {
            cost.SetActive(true);
            costText.text = addItem.cost.ToString();
        }
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        Debug.Log("Cleans the slot");
        if (cost != null)
        {
            cost.SetActive(false);
            costText.text = "0";
        }
    }
    public void UseItem()
    {
        if(item != null)
            item.Use();
    }
    public void BuyItem()
    {
        if (item != null)
            ShopUI.instance.interactShop.Buy(item);
    }
}

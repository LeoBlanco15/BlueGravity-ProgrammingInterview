using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    #region Singleton
    public static ShopUI instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public Transform itemParents;
    public Shop interactShop;

    private InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
        slots = itemParents.GetComponentsInChildren<InventorySlot>();
        //InputManager.shopOpened = true;
        //if(Manager.instance.Shop)
        //{
        //    interactShop = Manager.instance.Shop;
        //    UpdateShop();
        //}
    }
    public void SetUpShop()
    {
        interactShop.shopUpdate += UpdateShop;
        interactShop.shopUpdate.Invoke();

    }

    private void UpdateShop()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < Manager.instance.LoadedItems.Count) //interactShop.ShowedItems.Count
            {
                slots[i].AddItem(Manager.instance.LoadedItems[i]); //interactShop.ShowedItems[i]
            }
            else
            {
                Debug.Log("tries to clear");
                slots[i].ClearSlot();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewUI : MonoBehaviour
{
    #region Singleton
    public static PreviewUI instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public Transform itemParents;

    private InventorySlot hoodSlot;
    private InventorySlot faceSlot;
    private InventorySlot chestSlot;
    private InventorySlot legsSlot;
    // Start is called before the first frame update
    void Start()
    {
        hoodSlot = itemParents.GetComponentsInChildren<InventorySlot>()[0];
        faceSlot = itemParents.GetComponentsInChildren<InventorySlot>()[1];
        chestSlot = itemParents.GetComponentsInChildren<InventorySlot>()[2];
        legsSlot = itemParents.GetComponentsInChildren<InventorySlot>()[3];
    }

    public void PreviewArmon(Item item)
    {
        switch (item.type)
        {
            case ItemSlot.Hood:
                hoodSlot.AddItem(item);
                break;
            case ItemSlot.Face:
                faceSlot.AddItem(item);
                break;
            case ItemSlot.Chest:
                chestSlot.AddItem(item);
                break;
            case ItemSlot.Leg:
                legsSlot.AddItem(item);
                break;
            default:
                break;
        }
        MainCharacterChothes.instance.SwitchItems(item);
    }
    public void ResetPreview()
    {
        MainCharacterChothes.instance.ResetApparience();
        hoodSlot.ClearSlot();
        faceSlot.ClearSlot();
        chestSlot.ClearSlot();
        legsSlot.ClearSlot();
    }

    public void BuyItems()
    {
        hoodSlot.BuyItem(false);
        faceSlot.BuyItem(false);
        chestSlot.BuyItem(false);
        legsSlot.BuyItem(false);
        ResetPreview();
    }
    public void BuyAndEquip()
    {
        hoodSlot.BuyItem(true);
        faceSlot.BuyItem(true);
        chestSlot.BuyItem(true);
        legsSlot.BuyItem(true);
        ResetPreview();
    }

}

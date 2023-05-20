using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterChothes : MonoBehaviour
{
    #region Singleton
    public static MainCharacterChothes instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public Hood hood;
    public Face face;
    public Chest chest;
    public Legs legs;
    void Start()
    {
        Inventory.instance.itemList.Add(HoodObject.CreateItem(hood, 5));
        Inventory.instance.itemList.Add(FaceObject.CreateItem(face, 5));
        Inventory.instance.itemList.Add(ChestObject.CreateItem(chest, 5));
        Inventory.instance.itemList.Add(LegsObject.CreateItem(legs, 5));
        Inventory.instance.inventoryChange.Invoke();
    }

    public void ChangeItem(Item item)
    {
        Inventory.instance.UnEquipAll(item.type);
        switch (item.type)
        {
            case ItemSlot.Hood:
                hood.SwitchHood((HoodObject)item);
                break;
            case ItemSlot.Face:
                face.SwitchFace((FaceObject)item);
                break;
            case ItemSlot.Chest:
                chest.SwitchChest((ChestObject)item);
                break;
            case ItemSlot.Leg:
                legs.SwitchLegs((LegsObject)item);
                break;
            default:
                break;
        }
        item.Equiped = true;
    }
}

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
        if (Manager.instance != null)
        {
            HoodObject hoodAux = HoodObject.CreateItem(hood, 5);
            FaceObject faceAux = FaceObject.CreateItem(face, 5);
            ChestObject chestAux = ChestObject.CreateItem(chest, 5);
            LegsObject legsAux = LegsObject.CreateItem(legs, 5);

            if (!Manager.instance.CheckManagerItems())
            {
                Manager.instance.hood = hoodAux;
                Manager.instance.face = faceAux;
                Manager.instance.chest = chestAux;
                Manager.instance.legs = legsAux;

                Inventory.instance.AddItem(hoodAux);
                Inventory.instance.AddItem(chestAux);
                Inventory.instance.AddItem(legsAux);
                Inventory.instance.AddItem(faceAux);

                ChangeItem(hoodAux, true);
                ChangeItem(faceAux, true);
                ChangeItem(chestAux, true);
                ChangeItem(legsAux, true);
                foreach (Item item in Inventory.instance.itemList)
                {
                    item.Equiped = true;
                }
            }
            else
            {
                ResetApparience();
            }

        }
    }

    public void ChangeItem(Item item, bool equiped)
    {

        Inventory.instance.UnEquipAll(item.type);
        SwitchItems(item, equiped);
        item.Equiped = true;
    }
    public void ResetApparience()
    {
        foreach (Item item in Inventory.instance.itemList)
        {
            if (item.Equiped)
            {
                ChangeItem(item, true);
            }
        }

    }

    public void SwitchItems(Item item, bool equiped = false)
    {
        switch (item.type)
        {
            case ItemSlot.Hood:
                HoodObject hoodObject = (HoodObject)item;
                hood.SwitchHood(hoodObject);
                if (equiped)
                    Manager.instance.hood = hoodObject;
                break;
            case ItemSlot.Face:
                face.SwitchFace((FaceObject)item);
                if (equiped)
                    Manager.instance.face = (FaceObject)item;
                break;
            case ItemSlot.Chest:
                chest.SwitchChest((ChestObject)item);
                if (equiped)
                    Manager.instance.chest = (ChestObject)item;
                break;
            case ItemSlot.Leg:
                legs.SwitchLegs((LegsObject)item);
                if (equiped)
                    Manager.instance.legs = (LegsObject)item;
                break;
            default:
                break;
        }
    }
    public void LoadScene(string sceneName)
    {
        InputManager.LoadScene(sceneName);
    }
}

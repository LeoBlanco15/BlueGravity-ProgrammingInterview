using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " chest", menuName = "Inventory/Chest")]
public class ChestObject : Item
{
    public Sprite torso;
    public Sprite pelvis;
    public Sprite shoulderL;
    public Sprite shoulderR;
    public Sprite elbowL;
    public Sprite elbowR;
    public Sprite wristL;
    public Sprite wristR;

    
    public static ChestObject CreateItem(Chest chest, int auxCost)
    {
        ChestObject auxChest = ScriptableObject.CreateInstance<ChestObject>();

        auxChest.torso = chest.torso.sprite;
        auxChest.pelvis = chest.pelvis.sprite;
        auxChest.shoulderL = chest.shoulderL.sprite;
        auxChest.shoulderR = chest.shoulderR.sprite;
        auxChest.elbowL = chest.elbowL.sprite;
        auxChest.elbowR = chest.elbowR.sprite;
        auxChest.wristL = chest.wristL.sprite;
        auxChest.wristR = chest.wristR.sprite;

        auxChest.cost = auxCost;
        auxChest.type = ItemSlot.Chest;
        auxChest.logo = auxChest.torso;

        auxChest.Equiped = true;

        return auxChest;
    }
    public static ChestObject CreateItem(ChestObject item)
    {
        ChestObject auxChest = CreateInstance<ChestObject>();

        auxChest.torso = item.torso;
        auxChest.pelvis = item.pelvis;
        auxChest.shoulderL = item.shoulderL;
        auxChest.shoulderR = item.shoulderR;
        auxChest.elbowL = item.elbowL;
        auxChest.elbowR = item.elbowR;
        auxChest.wristL = item.wristL;
        auxChest.wristR = item.wristR;

        auxChest.cost = item.cost;
        auxChest.type = ItemSlot.Chest;
        auxChest.logo = auxChest.torso;

        return auxChest;
    }
}

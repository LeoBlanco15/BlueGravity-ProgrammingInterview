using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " chest", menuName = "Inventory/Legs")]
public class LegsObject : Item
{
    public Sprite legL;
    public Sprite legR;
    public Sprite bootL;
    public Sprite bootR;

    public static LegsObject CreateItem(Legs leg, int auxCost)
    {
        LegsObject auxReturn = ScriptableObject.CreateInstance<LegsObject>();
        auxReturn.legL = leg.legL.sprite;
        auxReturn.legR = leg.legR.sprite;
        auxReturn.bootL = leg.bootL.sprite;
        auxReturn.bootR = leg.bootR.sprite;

        auxReturn.cost = auxCost;
        auxReturn.type = ItemSlot.Leg;
        auxReturn.logo = auxReturn.bootL;
        auxReturn.Equiped = true;

        return auxReturn;
    }
    public static LegsObject CreateItem(LegsObject item)
    {
        LegsObject auxReturn = ScriptableObject.CreateInstance<LegsObject>();

        auxReturn.legL = item.legL;
        auxReturn.legR = item.legR;
        auxReturn.bootL = item.bootL;
        auxReturn.bootR = item.bootR;

        auxReturn.cost = item.cost;
        auxReturn.type = ItemSlot.Leg;
        auxReturn.logo = auxReturn.bootL;

        return auxReturn;
    }
}

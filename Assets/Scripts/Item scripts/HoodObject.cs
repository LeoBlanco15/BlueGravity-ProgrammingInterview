using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " chest", menuName = "Inventory/Hood")]
public class HoodObject : Item
{
    public Sprite hood;
    public static HoodObject CreateItem(Hood sprite, int cost)
    {
        HoodObject auxHood = ScriptableObject.CreateInstance<HoodObject>();
        auxHood.cost = cost;
        auxHood.hood = sprite.sprite.sprite;
        auxHood.logo = sprite.sprite.sprite;
        auxHood.type = ItemSlot.Hood;
        auxHood.Equiped = true;
        return auxHood;
    }
    public static HoodObject CreateItem(HoodObject item)
    {
        HoodObject auxHood = ScriptableObject.CreateInstance<HoodObject>();

        auxHood.cost = item.cost;
        auxHood.hood = item.hood;
        auxHood.logo = item.logo;
        auxHood.type = ItemSlot.Hood;
        
        return auxHood;
    }
}

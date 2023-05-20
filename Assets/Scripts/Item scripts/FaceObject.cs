using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " chest", menuName = "Inventory/Face")]
public class FaceObject : Item
{
    public Sprite face;

    public static FaceObject CreateItem(Face sprite, int auxCost)
    {
        FaceObject auxFace = ScriptableObject.CreateInstance<FaceObject>();

        auxFace.cost = auxCost;
        auxFace.face = sprite.sprite.sprite;

        auxFace.type = ItemSlot.Face;
        auxFace.logo = sprite.sprite.sprite;
        auxFace.Equiped = true;
        return auxFace;
    }
    public static FaceObject CreateItem(FaceObject item)
    {
        FaceObject auxFace = ScriptableObject.CreateInstance<FaceObject>();

        auxFace.cost = item.cost;
        auxFace.face = item.face;

        auxFace.type = ItemSlot.Face;
        auxFace.logo = item.logo;

        return auxFace;
    }
    public void SwitchFace(ref SpriteRenderer sprite)
    {
        sprite.sprite = face;
    }
}

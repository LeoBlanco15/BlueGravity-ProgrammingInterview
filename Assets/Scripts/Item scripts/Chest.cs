using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class Chest : MonoBehaviour
{
    public SpriteRenderer torso;
    public SpriteRenderer pelvis;
    public SpriteRenderer shoulderL;
    public SpriteRenderer shoulderR;
    public SpriteRenderer elbowL;
    public SpriteRenderer elbowR;
    public SpriteRenderer wristL;
    public SpriteRenderer wristR;


    public void SwitchChest(ChestObject chest)
    {
        torso.sprite = chest.torso;
        pelvis.sprite = chest.pelvis;
        shoulderL.sprite = chest.shoulderL;
        shoulderR.sprite = chest.shoulderR;
        elbowL.sprite = chest.elbowL;
        elbowR.sprite = chest.elbowR;
        wristL.sprite = chest.wristL;
        wristR.sprite = chest.wristR;
    }
}

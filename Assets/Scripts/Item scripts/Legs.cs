using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour
{
    public SpriteRenderer legL;
    public SpriteRenderer legR;
    public SpriteRenderer bootL;
    public SpriteRenderer bootR;

    public void SwitchLegs(LegsObject legs)
    {
        legL.sprite = legs.legL;
        legR.sprite = legs.legR;
        bootL.sprite = legs.bootL;
        bootR.sprite = legs.bootR;
    }
}

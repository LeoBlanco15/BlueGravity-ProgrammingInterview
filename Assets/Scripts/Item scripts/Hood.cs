using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hood : MonoBehaviour
{
    public SpriteRenderer sprite;

    public void SwitchHood(HoodObject hood)
    {
        sprite.sprite = hood.hood;
    }
}

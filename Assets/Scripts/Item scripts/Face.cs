using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    public SpriteRenderer sprite;

    public void SwitchFace(FaceObject face)
    {
        sprite.sprite = face.face;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    public static bool isPaused;
    public static bool shopOpened;

    public static float GetVertical()
    {
        return Input.GetAxisRaw("Vertical");
    }
    public static float GetHorizontal()
    {
        return Input.GetAxisRaw("Horizontal");
    }
    public static bool GetInteract()
    {
        return Input.GetButtonDown("Interact");
    }
    public static bool GetInventory()
    {
        return Input.GetButtonDown("Open inventory");
    }
}

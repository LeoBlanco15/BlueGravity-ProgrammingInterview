using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public static void LoadScene(string sceneName)
    {
        if (CheckScene("Main scene"))
        {
            Manager.instance.LastLocationCharacter = MainCharacterChothes.instance.transform.position;
        }
        SceneManager.LoadScene(sceneName);
    }
    public static bool CheckScene(string sceneName)
    {
        return SceneManager.GetActiveScene().name == sceneName;
    }
}

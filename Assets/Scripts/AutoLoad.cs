using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InputManager.LoadScene("Main scene");
    } 
}

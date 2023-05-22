using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    #region Singleton
    public static Manager instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    #endregion
    public HoodObject hood;
    public FaceObject face;
    public ChestObject chest;
    public LegsObject legs;

    private List<Item> loadedItems;
    private Vector3 lastLocationCharacter;


    public Vector3 LastLocationCharacter
    {
        set
        {
            lastLocationCharacter = value;
        }
        get
        {
            return lastLocationCharacter;
        }
    }
    public List<Item> LoadedItems
    {
        get
        {
            return loadedItems;
        }
        set
        {
            loadedItems = value;
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        if (InputManager.CheckScene("Main scene") && lastLocationCharacter != null)
            MainCharacterChothes.instance.transform.position = lastLocationCharacter;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public bool CheckManagerItems()
    {
        return instance.hood && instance.face && instance.chest && instance.legs;
    }
}

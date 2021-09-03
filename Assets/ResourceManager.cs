using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private Dictionary<string, Sprite> loadedSprites;

    private const string spriteFolder = "./Images/Sprites/";


    private static ResourceManager instance;


    public static ResourceManager GetInstance()
    {
        return instance;
    }


    void Start()
    {
        if (instance != null)
            instance = this;
        else
            return;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Sprite GetSprite(string spriteName)
    {
        return loadedSprites.ContainsKey(spriteName) ? loadedSprites[spriteName] : null;
    }


    public void LoadSprite(string spriteName)
    {
        if (loadedSprites[spriteName] != null) return; // Sprite already loaded
        loadedSprites[spriteName] = Resources.Load<Sprite>(spriteFolder + spriteName);
    }


    public void UnloadSprite(string spriteName)
    {
        if (loadedSprites[spriteName] == null) return; // Sprite non-existing
        Resources.UnloadAsset(loadedSprites[spriteName]);
        loadedSprites.Remove(spriteName);
    }
}

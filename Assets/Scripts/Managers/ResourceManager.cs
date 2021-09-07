using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public enum PrefabType
    {
        City,
        Items,
        UI,
        Weapons,
    }


    private Dictionary<string, Sprite> loadedSprites;
    private Dictionary<string, GameObject> loadedPrefabs;
    private Dictionary<string, Mesh> loadedModels;

    private const string spriteFolder = "Images/Sprites/";
    private const string prefabFolder = "Prefabs/";
    private const string modelFolder = "Models/";

    
    private static ResourceManager instance;


    public static ResourceManager GetInstance()
    {
        return instance;
    }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Init();
        }
        else
            return;
    }


    void Start()
    {

    }


    void Init()
    {
        loadedSprites = new Dictionary<string, Sprite>();
        loadedPrefabs = new Dictionary<string, GameObject>();
        loadedModels = new Dictionary<string, Mesh>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Sprite LoadSprite(string spriteName)
    {
        if (!loadedSprites.ContainsKey(spriteName))
            loadedSprites[spriteName] = Resources.Load<Sprite>(spriteFolder + spriteName);
        return loadedSprites[spriteName];
    }


    public void UnloadSprite(string spriteName)
    {
        if (!loadedSprites.ContainsKey(spriteName)) return; // Sprite non-existing
        Resources.UnloadAsset(loadedSprites[spriteName]);
        loadedSprites.Remove(spriteName);
    }


    public GameObject LoadPrefab(string prefabName, PrefabType prefabType)
    {
        if (!loadedPrefabs.ContainsKey(prefabName))
            loadedPrefabs[prefabName] = Resources.Load<GameObject>(prefabFolder + prefabType.ToString() + "/" + prefabName);
        return loadedPrefabs[prefabName];
    }


    public void UnloadPrefab(string prefabName)
    {
        if (!loadedPrefabs.ContainsKey(prefabName)) return;
        Resources.UnloadAsset(loadedPrefabs[prefabName]);
        loadedPrefabs.Remove(prefabName);
    }


    public Mesh LoadModel(string modelName)
    {
        if (!loadedPrefabs.ContainsKey(modelName))
            loadedModels[modelName] = Resources.Load<Mesh>(modelFolder + modelName);
        return loadedModels[modelName];
    }


    public void UnloadModel(string modelName)
    {
        if (!loadedModels.ContainsKey(modelName)) return;
        Resources.UnloadAsset(loadedModels[modelName]);
        loadedModels.Remove(modelName);
    }
}

using Assets.Scripts.Business.Items;
using System.Collections.Generic;
using UnityEngine;

public class ItemRepository : MonoBehaviour
{
    private static ItemRepository instance;
    public Dictionary<int, Item> items;


    public static ItemRepository GetInstance()
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
    }

    private void Init()
    {
        items = new Dictionary<int, Item>();
        items.Add(0, new BulletItem
        {
            name = "Bullet",
            spriteName = "",
            projectile = ResourceManager.GetInstance().LoadPrefab("Bullet", ResourceManager.PrefabType.Items),
            damage = 10,
            velocity = 75,
            decayTime = 3
        });
        items.Add(1, new BulletItem
        {
            name = "Shell",
            spriteName = "",
            projectile = ResourceManager.GetInstance().LoadPrefab("Bullet", ResourceManager.PrefabType.Items),
            damage = 100,
            velocity = 75,
            decayTime = 1,
            projectileCount = 6
        });
        items.Add(20, new WeaponItem
        {
            name = "Revolver",
            spriteName = "",
            bulletItem = (BulletItem)items[0],
            coolDown = 0.8f,
            isAutomatic = false,
            magSize = 6,
            errorAngle = 0,
            reloadTime = 2,
            weaponModel = ResourceManager.GetInstance().LoadModel("Revolver"),
        });
        items.Add(21, new WeaponItem
        {
            name = "SMG",
            spriteName = "",
            bulletItem = (BulletItem)items[0],
            coolDown = 0.05f,
            isAutomatic = true,
            magSize = 30,
            errorAngle = 30,
            reloadTime = 2,
            weaponModel = ResourceManager.GetInstance().LoadModel("SMG"),
        });
        items.Add(22, new WeaponItem
        {
            name = "Shotgun",
            spriteName = "",
            bulletItem = (BulletItem)items[1],
            coolDown = 0,
            isAutomatic = false,
            magSize = 2,
            errorAngle = 60,
            reloadTime = 1,
            weaponModel = ResourceManager.GetInstance().LoadModel("Shotgun"),
        });

    }


    public T CreateCopy<T>(T i) where T : Item
    {
        return (T) i.Clone();
    }


    public T CopyItem<T>(int id) where T : Item
    {
        if (items.ContainsKey(id))
            return (T)items[id].Clone();
        else return null;
    }
}
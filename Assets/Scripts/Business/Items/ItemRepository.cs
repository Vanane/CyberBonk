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
            bulletPrefab = ResourceManager.GetInstance().LoadPrefab("Bullet", ResourceManager.PrefabType.Items),
            damage = 10,
            velocity = 10
        });
        items.Add(20, new WeaponItem
        {
            name = "Revolver",
            spriteName = "",
            bulletAmmo = (BulletItem)items[0],
            coolDown = 1,
            isAutomatic = false,
            magSize = 6,
            reloadTime = 2
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
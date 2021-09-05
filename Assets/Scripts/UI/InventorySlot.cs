using Assets.Scripts.Business.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;


    void Start()
    {
        GetComponentInChildren<Image>().sprite = ResourceManager.GetInstance().GetSprite(item.spriteName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

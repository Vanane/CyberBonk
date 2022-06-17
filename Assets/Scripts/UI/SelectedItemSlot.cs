using Assets.Scripts.Business.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedItemSlot : InventorySlot
{
    override protected void Start()
    {
        Refresh();
    }


    override protected void Update()
    {
        transform.position = Input.mousePosition;
    }


    public void SelectItem(UsableItem i)
    {
        item = i;
        Refresh();
    }


    public void UnselectItem()
    {
        item = null;
        Refresh();
    }


    override public void Refresh()
    {
        if(item != null)
            spriteImage.sprite = ResourceManager.GetInstance().LoadSprite(item.spriteName);
        else
        {
            spriteImage.sprite = null;
            spriteImage.color = new Color(0, 0, 0, 0);
        }
    }
}

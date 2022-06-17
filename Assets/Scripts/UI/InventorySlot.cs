using Assets.Scripts.Business.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public Item item { get; protected set; }
    public int count;
    
    public Image spriteImage;
    public Text itemCount;
    public Text itemName;


    virtual protected void Start()
    {
        Refresh();
    }


    // Update is called once per frame
    virtual protected void Update()
    {
        
    }

    virtual public void Refresh()
    {
        if (item != null && count > 0)
        {
            spriteImage.sprite = ResourceManager.GetInstance().LoadSprite(item.spriteName);
            itemCount.text = count > 1 ? count.ToString() : string.Empty;
            itemName.text = item.name;
        }
        else
        {
            spriteImage.sprite = null;
            spriteImage.color = new Color(0, 0, 0, 0);
            itemCount.text = string.Empty;
            itemName.text = string.Empty;

        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("prout" + name);
    }


    public void SetItem(Item i)
    {
        item = i;
        Refresh();
    }
}

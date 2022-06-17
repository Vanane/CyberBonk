using Assets.Scripts.Business.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchField : MonoBehaviour
{
    private string oldInput;

    public RectTransform inventoryContent;



    // Start is called before the first frame update
    void Start()
    {
        oldInput = "";
    }


    public void OnInputUpdated(string newInput)
    {
        if(newInput == string.Empty)
            ResetDisplay();
        else
        {
            if (newInput.StartsWith(oldInput, System.StringComparison.OrdinalIgnoreCase))
            {
                FilterItemsOnName(newInput);
            }
            else
            {
                FilterAllItemsOnName(newInput);
            }
        }
        oldInput = newInput;
    }


    public void ResetDisplay()
    {
        foreach(RectTransform child in inventoryContent)
        {
            child.gameObject.SetActive(true);
        }
    }


    /// <summary>
    /// Iterates through all slots and hides slots whose items don't contain {name} in their name.
    /// </summary>
    /// <param name="name"></param>

    private void FilterAllItemsOnName(string name)
    {
        foreach (RectTransform child in inventoryContent)
        {
            if(child.GetComponent<InventorySlot>().item != null)
                if (child.GetComponent<InventorySlot>().item.name.Contains(name))
                    child.gameObject.SetActive(true);
                else
                    child.gameObject.SetActive(false);
        }
    }


    /// <summary>
    /// Iterates through active slots and hides those whose items don't contain {name} in their name.
    /// </summary>
    /// <param name="name"></param>
    private void FilterItemsOnName(string name)
    {
        foreach (RectTransform child in inventoryContent)
        {
            if(child.GetComponent<InventorySlot>().item != null)
                if(child.gameObject.activeSelf && !child.GetComponent<InventorySlot>().item.name.Contains(name))
                    child.gameObject.SetActive(false);
        }
    }
}

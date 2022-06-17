using Assets.Scripts.Business.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : UIPanel
{
    public Player player;
    public GameObject slotPrefab;
    public List<GameObject> slotList;


    override public void OnOpen()
    {
        GridLayoutGroup grid = this.gameObject.GetComponentInChildren<GridLayoutGroup>();
        RectTransform content = grid.gameObject.GetComponent<RectTransform>();

        CreateSlots(grid, content);
        ResizeContent(content);
    }


    override public void OnClose()
    {
        GridLayoutGroup grid = this.gameObject.GetComponentInChildren<GridLayoutGroup>();
        RectTransform content = grid.gameObject.GetComponent<RectTransform>();

        foreach(RectTransform child in content.transform)
        {
            Destroy(child.gameObject);
        }
    }


    private void ResizeContent(RectTransform content)
    {
        if (content.childCount == 0)
            return;

        float cellWidth = content.GetComponent<GridLayoutGroup>().cellSize.x + content.GetComponent<GridLayoutGroup>().spacing.x;
        float cellHeight = content.GetComponent<GridLayoutGroup>().cellSize.y + content.GetComponent<GridLayoutGroup>().spacing.y;

        int childrenPerRow = Mathf.FloorToInt(content.rect.width / cellWidth);
        int rowCount = Mathf.CeilToInt(content.childCount / childrenPerRow);

        float newHeight = cellHeight * rowCount;
        content.sizeDelta = new Vector2(content.sizeDelta.x, newHeight);
    }


    /// <summary>
    /// Creates the inventory slots of the inventory panel
    /// </summary>
    /// <param name="grid"></param>
    /// <param name="content"></param>
    private void CreateSlots(GridLayoutGroup grid, RectTransform content)
    {
        slotList = new List<GameObject>();
        int invCount = player.inventory.GetItemCount();
        int colCount = Mathf.FloorToInt(content.rect.width / (grid.cellSize.x + grid.spacing.x));
        int slotCount = colCount * (Mathf.FloorToInt(invCount / colCount) + 1);

        Dictionary<Item, int>.Enumerator itemIterator = player.inventory.GetEnumerator();

        for (int i = 0; i < slotCount; i++)
        {
            GameObject slot = Instantiate(slotPrefab);
            slot.transform.SetParent(content);
            slotList.Add(slot);

            if(itemIterator.MoveNext())
                slot.GetComponent<InventorySlot>().SetItem(itemIterator.Current.Key);
        }
    }
}

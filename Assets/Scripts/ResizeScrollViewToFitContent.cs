using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeScrollViewToFitContent : MonoBehaviour
{
    public RectTransform contentObject;

    private void Start()
    {
        ResizeContent();
    }

    public void ResizeContent()
    {
        if (contentObject.childCount == 0)
            contentObject.rect.Set(contentObject.rect.x, contentObject.rect.y, contentObject.rect.width, 0);

        float cellWidth = contentObject.GetComponent<GridLayoutGroup>().cellSize.x + contentObject.GetComponent<GridLayoutGroup>().spacing.x;
        float cellHeight = contentObject.GetComponent<GridLayoutGroup>().cellSize.y + contentObject.GetComponent<GridLayoutGroup>().spacing.y;

        int childrenPerRow = Mathf.FloorToInt(contentObject.rect.width / cellWidth);
        int rowCount = Mathf.CeilToInt(contentObject.childCount / childrenPerRow);

        float newHeight = cellHeight * rowCount;
        contentObject.sizeDelta = new Vector2(contentObject.rect.width, newHeight);
    }
}

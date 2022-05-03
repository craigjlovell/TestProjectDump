using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Inv Inventory;

    private GridLayoutGroup grid;

    [Space(10)]
    [Header("Inventory Controls")]
    [Range(0, 10)]
    public int numberOfRows;
    [Range(0, 10)]
    public int numberOfColumns;
    public float cellWidth;
    public float cellHeight;
    public float cellSpacing;
    public Vector2 positionOnScreen;
    public bool hasBoundingBox = false;
    public Sprite slotImage;
    public Sprite boundingBoxImage;
    public bool hasBin = false;
    public Sprite binImage;
    public Vector2 binPosition;

    void Start()
    {
        Inventory.ItemAdded += InvScript_ItemAdded;
    }

    private void InvScript_ItemAdded(object sender, InvEventArgs e)
    {
        Transform invetoryPanel = transform.Find("InvetoryPanel");
        foreach(Transform slot in invetoryPanel)
        {
            Image image = slot.GetChild(0).GetComponent<Image>();

            if(!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;
                break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Item Data")]
public class InventoryItemData : ScriptableObject
{
    public string id;
    public string displayName;
    public GameObject item;
    public Sprite itemImage;

    //public Enery_Chase enemy = null;
    //public PlayerController player;

    //public string Name
    //{
    //    get
    //    {
    //        return displayName;
    //    }
    //}
    ////public GameObject ScriptialObject;
    //public Sprite Image
    //{
    //    get
    //    {
    //        return itemImage;
    //    }
    //}
    //public void OnPickup()
    //{
    //    item.SetActive(false);
    //    player.items += 1;
    //    enemy.myAgent.speed += 0.5f;
    //}
}

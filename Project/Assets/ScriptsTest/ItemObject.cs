using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemObject : MonoBehaviour
{
    public InventoryItemData refItem;

    public void OnHandlePickupItem()
    {
        InvSystem.current.Add(refItem);
        Destroy(gameObject);
    }
}

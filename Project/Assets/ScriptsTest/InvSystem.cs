using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InvSystem : MonoBehaviour
{
    public event Action onInventoryChangeEvent;
    public static InvSystem current;
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    [SerializeField]
    public List<InventoryItem> inventory;// { get; set; } 

    private void Awake()
    {
        current = this;
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }

    public void InventoryEvent()
    {
        if(onInventoryChangeEvent != null)
        {
            onInventoryChangeEvent();
        }
    }

    public InventoryItem Get(InventoryItemData refData)
    {
        if(m_itemDictionary.TryGetValue(refData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

    public void Add(InventoryItemData refData)
    {
        Debug.Log(refData.name);
        if(m_itemDictionary.TryGetValue(refData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(refData);
            inventory.Add(newItem);
            m_itemDictionary.Add(refData, newItem);
        }
    }

    public void Remove(InventoryItemData refData)
    {
        if(m_itemDictionary.TryGetValue(refData, out InventoryItem value))
        {
            value.RemoveFromStack();

            if(value.stackSize == 0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(refData);
            }
        }
    }
}

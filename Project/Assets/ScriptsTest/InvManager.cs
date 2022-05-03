using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvManager : MonoBehaviour
{

    public GameObject m_slotPrefab;
    public void Start()
    {
        InvSystem.current.onInventoryChangeEvent += OnUpdateInventory;
    }

    private void OnUpdateInventory()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        DrawInventory();
    }    

    public void DrawInventory()
    {
        Debug.Log("DrawInventory ");
        foreach(InventoryItem item in InvSystem.current.inv)
        {
            AddInventorySlot(item);
        }
    }
    public void AddInventorySlot(InventoryItem item)
    {
        GameObject obj = Instantiate(m_slotPrefab);
        obj.transform.SetParent(transform, false);

        InvSlot slot = obj.GetComponent<InvSlot>();
        slot.Set(item);
    }
}

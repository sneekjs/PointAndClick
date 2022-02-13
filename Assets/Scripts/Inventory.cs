using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    [SerializeField]
    private List<InventoryObject> inventoryItems = new List<InventoryObject>();

    [SerializeField]
    private List<Transform> slotLocations = new List<Transform>();

    private int maxInventorySize = 8;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddItemToIntory(InventoryObject clickedObject)
    {
        if (inventoryItems.Count >= 8)
        {
            return;
        }
        inventoryItems.Add(clickedObject);
        MoveItemTowardsSlot(clickedObject.gameObject, slotLocations[inventoryItems.Count].position);
    }

    void MoveItemTowardsSlot(GameObject item, Vector3 slotLocation)
    {
        //start moving the picked up item towards the slot.
    }
}

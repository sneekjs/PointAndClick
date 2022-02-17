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

    [SerializeField]
    private float itemMoveSpeed = 15f;

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

    public void AddItemToInventory(InventoryObject addedItem)
    {
        if (inventoryItems.Count >= 8)
        {
            return;
        }
        StartCoroutine(MoveItemTowardsSlot(addedItem.gameObject, slotLocations[inventoryItems.Count].position));
        inventoryItems.Add(addedItem);
    }

    IEnumerator MoveItemTowardsSlot(GameObject item, Vector3 slotLocation)
    {
        Vector2 startPos = item.transform.position;
        while (Vector2.Distance(item.transform.position, slotLocation) > 0.01f)
        {
            item.transform.position = Vector2.MoveTowards(item.transform.position, slotLocation, Time.deltaTime * itemMoveSpeed);
            yield return new WaitForEndOfFrame();
        }
    }

    public void RemoveItemFromInventory(InventoryObject removedItem)
    {
        if (inventoryItems.Contains(removedItem))
        {
            inventoryItems.Remove(removedItem);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class InventoryObject : HiddenObject, IClickable
{
    [SerializeField]
    private string inventoryObjectID = "UNDEFINED";
    private PolygonCollider2D col;
    private Vector3 inventoryPos;
    private bool inInventory = false;
    private bool holding = false;

    public bool Holding
    {
        get
        {
            return holding;
        }
        set
        {
            holding = value;
            if (!holding)
            {
                CheckForInteraction();
                transform.position = inventoryPos;
            }
            col.enabled = !holding;
        }
    }

    protected override void Start()
    {
        base.Start();
        col = GetComponent<PolygonCollider2D>();
    }

    public override void Click()
    {
        base.Click();
        if (inInventory)
        {
            inventoryPos = transform.position;
            Holding = true;
        }
    }

    private void Update()
    {
        if (Holding)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePos.x, mousePos.y);
            if (Holding != Input.GetMouseButton(0))
            {
                Holding = Input.GetMouseButton(0);
            }
        }
    }

    protected override void PlayAnimation()
    {
        base.PlayAnimation();
    }

    protected override void AnimationFinished()
    {
        LevelManager.Instance.CrossOffItem((HiddenObject)this);
        Inventory.Instance.AddItemToIntory(this);
        inInventory = true;
    }

    private void CheckForInteraction()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (!hit)
        {
            return;
        }
        Debug.Log(hit.collider.gameObject.name);
        Lock targetLock = hit.collider.gameObject.GetComponent<Lock>();
        if (targetLock != null && targetLock.lockID == inventoryObjectID)
        {
            targetLock.Unlock();
        }
    }
}

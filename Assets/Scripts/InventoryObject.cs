using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : HiddenObject, IClickable
{
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
                transform.position = inventoryPos;
            }
        }
    }

    protected override void Start()
    {
        base.Start();
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
            Holding = Input.GetMouseButton(0);
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

    private void ResetPos()
    {

    }
}

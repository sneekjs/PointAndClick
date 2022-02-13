using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : HiddenObject, IClickable
{

    protected override void Start()
    {
        base.Start();
    }

    public override void Click()
    {
        base.Click();
    }

    protected override void PlayAnimation()
    {
        base.PlayAnimation();
    }

    protected override void AnimationFinished()
    {
        LevelManager.Instance.CrossOffItem((HiddenObject)this);
        Inventory.Instance.AddItemToIntory(this);
    }
}

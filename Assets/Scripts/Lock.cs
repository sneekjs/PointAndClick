using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : WorldObject, IClickable
{
    public string lockID = "UNDEFINED";
    private string unlockAnimation = "Unlock";
    private Animator anim;

    protected override void Start()
    {
        base.Start();
        anim = gameObject.GetComponent<Animator>();
    }

    public void Unlock()
    {
        anim.Play(unlockAnimation);
    }

    public override void Click()
    {
        base.Click();
        Debug.Log("You clicked a lock that is locked."); //Implement a way to make this known to the player.
    }
}
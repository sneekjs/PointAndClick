using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatedObject : WorldObject, IClickable
{
    private Animator anim;
    public string animationName = "Default";

    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    public override void Click()
    {
        base.Start();
        anim.Play(animationName);
    }
}

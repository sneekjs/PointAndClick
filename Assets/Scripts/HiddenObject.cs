using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(ParticleSystem))]
public class HiddenObject : WorldObject, IClickable
{
    public string objectName;
    protected Animator anim;
    protected ParticleSystem particleSystem;
    protected string animationName = "Clicked";
    protected bool isInteractable = true;

    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    public override void Click()
    {
        if (isInteractable)
        {
            base.Click();
            isInteractable = false;
            PlayAnimation();
        }
    }

    protected virtual void PlayAnimation()
    {
        anim.Play(animationName);
        particleSystem.Play();
    }

    protected virtual void AnimationFinished()
    {
        LevelManager.Instance.CrossOffItem(this);
        Destroy(gameObject);
    }
}

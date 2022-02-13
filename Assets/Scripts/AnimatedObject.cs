using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatedObject : MonoBehaviour, IClickable
{
    private Animator anim;
    public string animationName = "Default";

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Click()
    {
        anim.Play(animationName);
    }
}

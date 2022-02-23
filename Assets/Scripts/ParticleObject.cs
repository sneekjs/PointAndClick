using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleObject : WorldObject, IClickable
{
    private ParticleSystem particleSystem;

    protected override void Start()
    {
        base.Start();
        particleSystem = GetComponent<ParticleSystem>();
    }

    public override void Click()
    {
        base.Click();
        particleSystem.Play();
    }
}

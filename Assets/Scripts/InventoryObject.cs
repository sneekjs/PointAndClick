using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(ParticleSystem))]
public class InventoryObject : MonoBehaviour, IClickable
{
    private Animator anim;
    private ParticleSystem particleSystem;
    private bool lootable = true;
    private string animationName = "Clicked";

    private void Start()
    {
        anim = GetComponent<Animator>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    public void Click()
    {
        if (lootable)
        {
            lootable = false;
            PlayAnimation();
        }
    }

    void PlayAnimation()
    {
        anim.Play(animationName);
        particleSystem.Play();
    }

    void AddToInventory()
    {
        Inventory.Instance.AddItemToIntory(this);
    }
}

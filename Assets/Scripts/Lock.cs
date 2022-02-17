using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour, IClickable
{
    private string unlockAnimation = "Unlock";
    private Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void Unlock()
    {
        anim.Play(unlockAnimation);
    }

    public void Click()
    {
        Debug.Log("You clicked a lock that is locked."); //Implement a way to make this known to the player.
    }
}
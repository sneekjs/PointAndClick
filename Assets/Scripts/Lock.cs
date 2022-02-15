using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour, IClickable
{
    public void Unlock()
    {
        Debug.Log("Cool, you just unlocked something!"); //implement an animation that makes a certain area transparant
    }

    public void Click()
    {
        Debug.Log("You clicked a lock that is locked."); //Implement a way to make this known to the player.
    }
}

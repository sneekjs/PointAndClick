using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour, IClickable
{
    public AudioSource audioSource;

    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void Click()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}

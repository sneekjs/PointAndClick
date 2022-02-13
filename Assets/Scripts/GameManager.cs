using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckClick();
        }
    }

    void CheckClick()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (!hit)
        {
            return;
        }

        IClickable clickedObject = hit.collider.gameObject.GetComponent<IClickable>();
        if (clickedObject != null)
        {
            clickedObject.Click();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField]
    private List<HiddenObject> hiddenObjects = new List<HiddenObject>();

    [SerializeField]
    private List<TMP_Text> hiddenObjectsText = new List<TMP_Text>();

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

    public void LoadLevel()
    {
        hiddenObjects.AddRange(FindObjectsOfType<HiddenObject>());
        foreach (UItextIdentifier item in FindObjectsOfType<UItextIdentifier>())
        {
            hiddenObjectsText.Add(item.gameObject.GetComponent<TMP_Text>());
        }

        hiddenObjects.Reverse();
        hiddenObjectsText.Reverse();

        for (int i = 0; i < hiddenObjects.Count; i++)
        {
            hiddenObjectsText[i].text = hiddenObjects[i].objectName;
        }
    }

    public void CrossOffItem(HiddenObject hiddenObject)
    {
        if (hiddenObjects.Contains(hiddenObject))
        {
            hiddenObjectsText[hiddenObjects.IndexOf(hiddenObject)].fontStyle = FontStyles.Strikethrough;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameAccept : MonoBehaviour
{
    [SerializeField] Button accept;
    [SerializeField] GameObject[] nameSelectors;

    public static bool nameSaved = false;

    // Start is called before the first frame update
    void Start()
    {
        accept.onClick.AddListener(SaveNameContinue);
    }

    void SaveNameContinue()
    {
        LevelManager.playerName = "";
        foreach (var item in nameSelectors)
        {
            LevelManager.playerName += item.GetComponent<TextMeshProUGUI>().text;
        }
        nameSaved = true;
        SqlTasks.UploadScore();
        gameObject.SetActive(false);
    }
}

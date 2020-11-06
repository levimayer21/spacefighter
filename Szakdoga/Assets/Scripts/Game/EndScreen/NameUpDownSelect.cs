using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameUpDownSelect : MonoBehaviour
{
    [SerializeField] Button buttonUp;
    [SerializeField] Button buttonDown;

    const string abc = "abcdefghijklmnopqrstuvwxyz123456789 ";
    int actIndex;

    // Start is called before the first frame update
    void Start()
    {
        actIndex = 0;
        buttonUp.onClick.AddListener(UpClick);
        buttonDown.onClick.AddListener(DownClick);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = abc[actIndex].ToString();
    }

    void UpClick()
    {
        if (actIndex == abc.Length-1)
        {
            actIndex = 0;
        }
        else
        {
            actIndex++;
        }
    }

    void DownClick()
    {
        if (actIndex == 0)
        {
            actIndex = 35;
        }
        else
        {
            actIndex--;
        }
    }
}

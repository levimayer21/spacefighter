using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class OnKeyPress : MonoBehaviour
{
    [SerializeField]
    Button howToButton;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            MenuEvent.menuEvent.Press();
            Destroy(gameObject.GetComponent<OnKeyPress>());
        }
    }

}

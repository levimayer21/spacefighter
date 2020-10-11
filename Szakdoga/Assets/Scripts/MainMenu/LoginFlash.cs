using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;

public class LoginFlash : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Flashing());
        MenuEvent.menuEvent.OnPress += OnPressed;
    }

    // Update is called once per frame
    IEnumerator Flashing()
    {
        while (gameObject.activeSelf)
        {
            if (text.enabled)
            {
                yield return new WaitForSeconds(0.85f);
                text.enabled = false;
                Debug.Log("Disabled");
            }
            else
            {
                yield return new WaitForSeconds(0.85f);
                text.enabled = true;
                Debug.Log("Enabled");
            }
        }
    }

    void OnPressed()
    {
        Destroy(gameObject);
    }
}

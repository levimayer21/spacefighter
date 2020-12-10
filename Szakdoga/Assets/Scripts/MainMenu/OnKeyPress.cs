using System;
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
        string szoveg1 = "asd";
        string szoveg2 = "fgh";

        string osszeadva = $"{szoveg1}{szoveg2}";
        Console.WriteLine("{0}{1}", szoveg1, szoveg2);
        Console.WriteLine(szoveg1 + szoveg2);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEvent : MonoBehaviour
{
    public static MenuEvent menuEvent;

    private void Awake()
    {
        menuEvent = this;
    }

    public event Action OnPress;
    public void Press()
    {
        OnPress?.Invoke();
    }

    public event Action OnHowToClick;
    public void HowToClick()
    {
        OnHowToClick?.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuAnim : MonoBehaviour
{
    [SerializeField]
    RectTransform menu;
    [SerializeField]
    RectTransform ship;
    [SerializeField]
    RectTransform menuFinal;
    [SerializeField]
    RectTransform shipFinal;
    [SerializeField]
    RectTransform guide;
    [SerializeField]
    RectTransform guideFinal;

    Vector2 menuStartPoint = new Vector2(0, -1200);
    Vector2 shipStartPoint = new Vector2(0, -980);
    Vector2 guideStartPoint = new Vector2(0, -1200);

    public static bool guideIsUp;

    // Start is called before the first frame update
    void Start()
    {
        guideIsUp = false;
        menu.anchoredPosition = menuStartPoint;
        ship.anchoredPosition = shipStartPoint;
        guide.anchoredPosition = guideStartPoint;
        menu.gameObject.SetActive(true);
        MenuEvent.menuEvent.OnPress += UponStart;
        MenuEvent.menuEvent.OnHowToClick += OnGuideClick;
    }

    void UponStart()
    {
        StartCoroutine(UpAnim());
    }

    IEnumerator UpAnim()
    {
        while (ship.anchoredPosition.y != shipFinal.anchoredPosition.y || menu.anchoredPosition.y != menuFinal.anchoredPosition.y)
        {
            if (ship.anchoredPosition.y < shipFinal.anchoredPosition.y)
            {
                ship.anchoredPosition += new Vector2(0, 2.5f);
            }
            if (menu.anchoredPosition.y < menuFinal.anchoredPosition.y)
            {
                menu.anchoredPosition += new Vector2(0, 2.5f);
            }
            yield return null;
        }
    }

    public void OnGuideClick()
    {
        StartCoroutine(GuideAnim());
    }

    IEnumerator GuideAnim()
    {
        if (guideIsUp)
        {
            while (guide.anchoredPosition.y > guideStartPoint.y)
            {
                guide.anchoredPosition -= new Vector2(0, 10f);
                yield return null;
            }
            if (guide.anchoredPosition.y == guideStartPoint.y)
            {
                Debug.Log("Done, guide disabled");
                guideIsUp = false;
            }
        }
        else
        {
            while (guide.anchoredPosition.y < guideFinal.anchoredPosition.y)
            {
                guide.anchoredPosition += new Vector2(0, 10f);
                yield return null;
            }
            if (guide.anchoredPosition.y == guideFinal.anchoredPosition.y)
            {
                Debug.Log("Done, guide Enabled");
                guideIsUp = true;
            }
        }
    }
}

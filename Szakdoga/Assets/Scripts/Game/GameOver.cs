using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverScn;
    [SerializeField]
    TextMeshProUGUI gameOverTxt;

    private void Awake()
    {

    }

    private void Start()
    {
        GameEvent.gameEvent.onGameEnd += ActivateEndScreen;
    }

    private void Update()
    {
        /*if (onEnd && Input.anyKeyDown)
        {
            SceneManager.LoadSceneAsync(2);
        }*/
    }

    void ActivateEndScreen()
    {
        StartCoroutine(EndScreenToPointScreen());
    }

    IEnumerator EndScreenToPointScreen()
    {
        gameOverScn.SetActive(true);
        while (gameOverScn.activeSelf)
        {
            if (gameOverTxt.enabled)
            {
                yield return new WaitForSeconds(0.75f);
                gameOverTxt.enabled = false;
            }
            else
            {
                yield return new WaitForSeconds(0.75f);
                gameOverTxt.enabled = true;
            }
        }
    }
}

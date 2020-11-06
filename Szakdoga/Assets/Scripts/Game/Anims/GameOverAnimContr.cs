using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityMySQL;

public class GameOverAnimContr : MonoBehaviour
{
    [SerializeField] GameObject gameOverTxtContainer;
    [SerializeField] GameObject nameContainer;
    [SerializeField] GameObject scoreContainer;
    [SerializeField] GameObject timeContainer;
    [SerializeField] GameObject buttonContainer;
    [SerializeField] GameObject scoreChecker;

    UnityMySQL.UnityMySQL mySql;

    void Update()
    {
        gameOverTxtContainer.SetActive(true);
        if (LevelManager.points > 50000 && !NameAccept.nameSaved)
        {
            nameContainer.SetActive(true);
        }
        if (gameOverTxtContainer.GetComponent<Animator>().GetBool("gameOverAnimEnded") && !nameContainer.activeSelf)
        {
            scoreContainer.SetActive(true);
            if (scoreContainer.GetComponent<Animator>().GetBool("scoreScreenCountingEnded"))
            {
                timeContainer.SetActive(true);
            }
        }
        if (scoreContainer.GetComponent<Animator>().GetBool("scoreScreenCountingEnded") && timeContainer.GetComponent<Animator>().GetBool("timeScreenAnimEnded") && timeContainer.GetComponent<Animator>().GetBool("timeScreenCountEnded"))
        {
            scoreChecker.GetComponent<TextMeshProUGUI>().text = SqlTasks.CheckForPlacement();
            buttonContainer.SetActive(true);
            scoreChecker.SetActive(true);
        }
    }

    public void OnRestart()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void OnMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}

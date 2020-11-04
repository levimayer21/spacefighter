using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityMySQL;

public class GameOverAnimContr : MonoBehaviour
{
    [SerializeField] GameObject gameOverTxtContainer;
    [SerializeField] GameObject scoreContainer;
    [SerializeField] GameObject timeContainer;
    [SerializeField] GameObject buttonContainer;

    UnityMySQL.UnityMySQL mySql;

    // Start is called before the first frame update
    void Start()
    {
        LevelManager.points = 10000;
        LevelManager.time = new ClockTime(new TimeSpan(0, 25, 15));
        Debug.Log(LevelManager.time.Time);
    }

    void Update()
    {
        if (!gameOverTxtContainer.activeSelf)
        {
            gameOverTxtContainer.SetActive(true); 
        }
        if (gameOverTxtContainer.GetComponent<Animator>().GetBool("gameOverAnimEnded"))
        {
            scoreContainer.SetActive(true);
            if (scoreContainer.GetComponent<Animator>().GetBool("scoreScreenCountingEnded"))
            {
                timeContainer.SetActive(true);
            }
        }
        if (scoreContainer.GetComponent<Animator>().GetBool("scoreScreenAnimEnded") && scoreContainer.GetComponent<Animator>().GetBool("scoreScreenCountingEnded") && timeContainer.GetComponent<Animator>().GetBool("timeScreenAnimEnded") && timeContainer.GetComponent<Animator>().GetBool("timeScreenCountEnded"))
        {
            buttonContainer.SetActive(true);
        }
    }
}

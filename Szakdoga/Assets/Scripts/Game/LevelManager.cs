using System;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public static ClockTime time;
    public static string playerName;
    public static bool isMoveEnabled;
    public static bool lostALife;
    public static bool spawnerSet;
    public static bool roundEnded;
    public static bool playerLost;
    public static float enemySpeed;
    public static int round;
    public static int usableEnemyCount;

    public static int playerHealth;
    public static int points;
    public GameObject enemySpawner;

    public static Stopwatch sp;

    int backupScore;
    GameObject spawner;

    private void Awake()
    {
        GameEvent.gameEvent.onRoundStart += SetRound;
    }

    private void Start()
    {
        sp = new Stopwatch();
        sp.Start();
        playerLost = false;
        roundEnded = false;
        spawnerSet = false;
        instance = this;
        round = 0;
        isMoveEnabled = true;
        lostALife = false;
        playerHealth = 1;
        points = 49000;
    }

    private void Update()
    {
        if (!playerLost)
        {
            if (!lostALife && !GameAnim.roundAnimActive && !spawnerSet && usableEnemyCount > 1)
            {
                spawner = Instantiate(enemySpawner);
                spawnerSet = true;
            }
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < 1 && roundEnded && !spawnerSet && playerHealth > 0)
            {
                GameEvent.gameEvent.RoundStart();
                roundEnded = false;
            } 
        }
    }

    void SetRound()
    {
        roundEnded = false;
        if (!lostALife)
        {
            round++;
        }
        usableEnemyCount = 20 + (2*round);
        enemySpeed = -10f * (0.14f * round);
        backupScore = points;
    }

    public void ReloadRound()
    {
        points = backupScore;
        GameEvent.gameEvent.RoundStart();
        lostALife = false;
    }
}

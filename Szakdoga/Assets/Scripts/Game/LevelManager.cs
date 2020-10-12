using System;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public static bool isMoveEnabled;
    public static bool lostALife;
    public static float enemySpeed;
    public static int round;
    public static int usableEnemyCount;
    public static bool spawnerSet;
    public static bool roundEnded;
    public static bool playerLost;

    public static int playerHealth;
    public static int points;
    public GameObject enemySpawner;

    int backupScore;
    GameObject spawner;

    private void Awake()
    {
        GameEvent.gameEvent.onRoundStart += SetRound;
    }

    private void Start()
    {
        playerLost = false;
        roundEnded = false;
        spawnerSet = false;
        instance = this;
        round = 4;
        isMoveEnabled = true;
        lostALife = false;
        playerHealth = 1;
        points = 0;
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
        usableEnemyCount = 2 + (5*round);
        enemySpeed = -2.3f * (0.3f * round);
        backupScore = points;
    }

    public void ReloadRound()
    {
        points = backupScore;
        GameEvent.gameEvent.RoundStart();
        lostALife = false;
    }
}

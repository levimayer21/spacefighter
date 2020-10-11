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

    public static int playerHealth;
    public static int points;
    public GameObject enemySpawner;

    LevelManager backup;

    private void Awake()
    {
        roundEnded = false;
        spawnerSet = false;
        instance = this;
        round = 0;
        isMoveEnabled = true;
        lostALife = false;
        playerHealth = 3;
        points = 0;
        GameEvent.gameEvent.onRoundStart += SetRound;
    }

    private void Update()
    {
        if (!GameAnim.roundAnimActive && !spawnerSet && usableEnemyCount > 1)
        {
            GameObject spawner = Instantiate(enemySpawner);
            spawnerSet = true;
        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 1 && roundEnded && !spawnerSet && playerHealth > 0)
        {
            GameEvent.gameEvent.RoundStart();
            roundEnded = false;
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
        enemySpeed = -2f * (0.7f * round);
        backup = instance;
    }

    public void ReloadRound()
    {
        instance = backup;
        GameEvent.gameEvent.RoundStart();
        lostALife = false;
    }
}

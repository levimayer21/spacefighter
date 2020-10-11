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

    public int playerHealth;
    public int points;
    public GameObject enemySpawner;

    LevelManager backup;

    private void Awake()
    {
        spawnerSet = false;
        instance = this;
        round = 1;
        isMoveEnabled = true;
        lostALife = false;
        playerHealth = 3;
        points = 0;
    }

    private void Start()
    {
        GameEvent.gameEvent.onRoundStart += SetRound;
    }
    private void Update()
    {
        if (!GameAnim.roundAnimActive && !spawnerSet)
        {
            GameObject spawner = Instantiate(enemySpawner);
            spawnerSet = true;
        }
    }

    void SetRound()
    {
        usableEnemyCount = 25 + (5*round);
        backup = instance;
        Debug.Log("Backup Done");
        enemySpeed = -2f * (0.7f * round);
        Debug.Log(enemySpeed);
    }

    void AfterDeath()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(item);
        }
        ReloadRound();
    }

    void ReloadRound()
    {
        instance = backup;
        GameEvent.gameEvent.RoundStart();
    }
}

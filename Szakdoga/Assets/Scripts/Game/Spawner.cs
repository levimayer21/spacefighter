using System.Collections;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemyPref;

    private void Update()
    {
        if ((LevelManager.usableEnemyCount < 1 && GameObject.FindGameObjectsWithTag("Enemy").Length < 1) || LevelManager.lostALife)
        {
            LevelManager.roundEnded = true;
            LevelManager.spawnerSet = false;
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (LevelManager.usableEnemyCount > 0 && !LevelManager.lostALife)
        {
            float rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0:
                    Instantiate(enemyPref[0], new Vector3(Random.Range(-2.8f, 1f), 9f, 0f), Quaternion.Euler(new Vector3(180, 0, 0))).GetComponent<Rigidbody2D>().velocity = new Vector2(0, LevelManager.enemySpeed);
                    LevelManager.usableEnemyCount--;
                    break;
                case 1:
                    Instantiate(enemyPref[1], new Vector3(Random.Range(-2.8f, 1f), 9f, 0f), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, LevelManager.enemySpeed);
                    LevelManager.usableEnemyCount--;
                    break;
                case 2:
                    float randX = Random.Range(-2.0f, 0.2f);
                    GameObject en = Instantiate(enemyPref[2], new Vector3(randX, 9f, 0f), Quaternion.identity);
                    en.GetComponent<Rigidbody2D>().velocity = new Vector2(0, LevelManager.enemySpeed);
                    Instantiate(enemyPref[2], new Vector3(randX < -0.874f? en.transform.position.x - Random.Range(3f, 4f): en.transform.position.x + Random.Range(3f, 4f), 9f, 0f), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(0, LevelManager.enemySpeed);
                    LevelManager.usableEnemyCount -= 2;
                    break;
            }
            yield return new WaitForSecondsRealtime(Random.Range(1.5f, 3f));
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normie : EnemyBehaviour
{
    [SerializeField]
    GameObject enemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        points = 1000;
        StartCoroutine(ShootActuator());
    }

    void ShootRandomly()
    {
        if (LevelManager.round > 3)
        {
            if (Random.Range(0,101) >= 70)
            {
                Instantiate(enemyBullet, gameObject.transform.position, Quaternion.identity);
            }
        }
    }

    IEnumerator ShootActuator()
    {
        yield return new WaitForSecondsRealtime(Random.Range(0,3));
        ShootRandomly();
    }
}

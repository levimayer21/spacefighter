using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreePSmall : EnemyBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        points = 100;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, 0.05f);
    }
}

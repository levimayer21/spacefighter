using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeP : MonoBehaviour
{
    int health;

    public int Health { get => health; set => health = value; }

    private void Start()
    {
        health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}

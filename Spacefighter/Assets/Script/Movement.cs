using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed = 1.0f;
    Rigidbody2D playerrig;

    private void Start()
    {
        playerrig = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void ToLeft()
    {
        playerrig.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
    }
}

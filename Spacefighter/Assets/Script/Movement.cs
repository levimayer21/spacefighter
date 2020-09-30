using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed;
    Rigidbody2D playerrig;

    private void Start()
    {
        playerrig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        speed = Input.GetAxisRaw("Horizontal") * 170.0f * Time.deltaTime;
    }

    void FixedUpdate()
    {
        playerrig.velocity = new Vector2(speed, 0);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), -3.8f);
    }
}

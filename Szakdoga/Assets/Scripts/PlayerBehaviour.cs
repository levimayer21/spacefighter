using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject bulletPref;
    float moveSpeed;
    public int health;

    public int Health { get => health; set => health = health > -1 ? value: throw new ArgumentException("Az élet nem lehet -1nél kisebb!"); }

    // Start is called before the first frame update
    void Start()
    {
        Input.multiTouchEnabled = true;
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 150.0f * Time.deltaTime;
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.position = new Vector2(Mathf.Clamp(rb.transform.position.x, -2.7f, 2.7f), -3.3f);
        float horMov = Input.GetAxisRaw("Horizontal");
        float tCount = Input.touchCount;

        if (tCount > 0)
        {
            for (int i = 0; i < tCount; i++)
            {
                Touch t = Input.GetTouch(i);
                if (t.position.y < Screen.height / 2)
                {
                    if (t.phase == TouchPhase.Began && t.position.x > Screen.width / 2)
                    {
                        ShootBullet();
                    }
                    else if (t.phase == TouchPhase.Began && t.position.x < Screen.width / 4)
                    {
                        Move(-1 * moveSpeed);
                    }
                    else if (t.phase == TouchPhase.Began && t.position.x > Screen.width / 4 && t.position.x < Screen.width / 2)
                    {
                        Move(1 * moveSpeed);
                    }
                    if (t.phase == TouchPhase.Moved && t.position.x < Screen.width / 2)
                    {
                        if (t.position.x < Screen.width / 4)
                        {
                            Move(-1 * moveSpeed);
                        }
                        else if (t.position.x > Screen.width / 4 && t.position.x < Screen.width / 2)
                        {
                            Move(1 * moveSpeed);
                        }
                    }
                    else if (t.phase == TouchPhase.Ended && t.position.x < Screen.width / 2)
                    {
                        Move(0);
                    } 
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootBullet();
            }
            if (Input.GetAxisRaw("Horizontal") != 0f)
            {
                Move(horMov * moveSpeed);
            }
            else
            {
                Move(0);
            }
        }
    }

    void Move(float speed)
    {
        rb.velocity = new Vector2(speed, 0);
    }

    void ShootBullet()
    {
        GameObject b = Instantiate(bulletPref) as GameObject;
        b.transform.position = transform.position;
    }
}

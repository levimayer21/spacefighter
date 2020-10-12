using System.Collections;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerBehaviour : MonoBehaviour
{
    public static bool MoveEnabled;

    Rigidbody2D rb;
    public GameObject bulletPref;
    public GameObject explosion;

    public float moveSpeed;
    float fireRate = 0.25f;
    float nextFire = 0.0f;

    Vector2 startPoint = new Vector2(-0.875f, -3.3f);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameEvent.gameEvent.onDeath += Killed;
        Input.multiTouchEnabled = true;
        moveSpeed = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.position = new Vector2(Mathf.Clamp(rb.transform.position.x, -2.8f, 1f), rb.transform.position.y);
        float horMov = Input.GetAxisRaw("Horizontal");
        float tCount = Input.touchCount;

        if (LevelManager.isMoveEnabled)
        {
            if (tCount > 0)
            {
                for (int i = 0; i < tCount; i++)
                {
                    Touch t = Input.GetTouch(i);
                    if (t.position.y < Screen.height / 4)
                    {
                        if (t.phase == TouchPhase.Began)
                        {
                            if (t.position.x > Screen.width / 2 && Time.time > nextFire)
                            {
                                nextFire = Time.time + fireRate;
                                ShootBullet();
                            }
                            else if (t.position.x < Screen.width / 4)
                            {
                                Move(-1 * moveSpeed);
                            }
                            else if (t.position.x > Screen.width / 4 && t.position.x < Screen.width / 2)
                            {
                                Move(1 * moveSpeed);
                            }
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
                if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
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

    void Killed()
    {
        LevelManager.lostALife = true;
        LevelManager.isMoveEnabled = false;
        Instantiate(explosion, transform.position, Quaternion.identity);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<EdgeCollider2D>().enabled = false;
        LevelManager.playerHealth--;
        if (LevelManager.playerHealth == 0)
        {
            LevelManager.playerLost = true;
            GameEvent.gameEvent.GameEnd();
        }
        else
        {
            StartCoroutine(RespawnPlayer());  
        }
    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        LevelManager.isMoveEnabled = true;
        gameObject.transform.position = startPoint;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<EdgeCollider2D>().enabled = true;
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(item);
        }
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("EnemyBullet"))
        {
            Destroy(item);
        }    
        LevelManager.instance.ReloadRound();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameEvent.gameEvent.Death();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            GameEvent.gameEvent.Death();
            Destroy(collision.gameObject);
        }
    }
}

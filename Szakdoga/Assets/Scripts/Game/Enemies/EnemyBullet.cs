using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed = -15.0f;
    Rigidbody2D rb;
    Vector2 scBound;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
        scBound = new Vector2(0, -5.4f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < scBound.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameEvent.gameEvent.Death();
            Destroy(gameObject);
        }
    }
}
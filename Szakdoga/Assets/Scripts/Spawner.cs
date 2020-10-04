using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float speed = 5.0f;
    Rigidbody2D rb;
    Vector2 screenBounds;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < screenBounds.y * -2)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = collision.gameObject.transform.position;
            collision.gameObject.GetComponent<PlayerBehaviour>().Health -= 1;
            Debug.Log(collision.gameObject.GetComponent<PlayerBehaviour>().Health);
            Destroy(gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}

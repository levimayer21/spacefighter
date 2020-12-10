using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour
{
    protected int health;
    protected int points;

    public GameObject explosion;

    Vector2 screenBounds = new Vector2(0, -8);

    internal virtual void OnHit()
    {
        health--;
        if (health < 1)
        {
            LevelManager.score += points;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2.8f, 1f), transform.position.y);
        if (transform.position.y < screenBounds.y || transform.position.x > 4.5f || transform.position.x < -4.5f)
        {
            Destroy(gameObject);
        }
        switch (LevelManager.lostALife)
        {
            case true:
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                break;
            default:
                if (GetType().ToString() != "ThreePSmall")
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, LevelManager.enemySpeed);
                }
                break;
        }
    }
}

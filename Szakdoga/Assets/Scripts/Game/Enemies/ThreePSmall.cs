using UnityEngine;

public class ThreePSmall : EnemyBehaviour
{
    Vector2 velocity;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = 1;
        points = 100;
    }

    private void Update()
    {
        if (transform.position.y > -1.8f)
        {
            transform.LookAt(player.transform);
            GetComponent<Rigidbody2D>().AddForce(transform.forward);
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(transform.forward);
        }
    }
}

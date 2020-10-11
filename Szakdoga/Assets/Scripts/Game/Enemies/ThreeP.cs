using UnityEngine;

public class ThreeP : EnemyBehaviour
{
    [SerializeField]
    GameObject threePSmall;

    private void Start()
    {
        health = 1;
        points = 150;
    }

    internal override void OnHit()
    {
        float add = -0.8f;
        for (int i = 0; i < 3; i++)
        {
            Instantiate(threePSmall, new Vector3(transform.position.x + add, transform.position.y, transform.position.z), Quaternion.identity);
            add += 0.8f;
        }
        base.OnHit();
    }
}

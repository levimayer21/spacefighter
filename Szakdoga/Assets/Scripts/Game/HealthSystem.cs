using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int health;
    public Image[] shiphp;

    private void Update()
    {
        health = LevelManager.playerHealth;

        for (int i = 0; i < shiphp.Length; i++)
        {
            if (i > health - 2) // Három élete van, de csak kettőt kell kijelezni, -2 az indexelés miatt
            {
                shiphp[i].enabled = false;
            }
            else
            {
                shiphp[i].enabled = true;
            }
        }
    }
}

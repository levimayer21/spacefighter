using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenMov : MonoBehaviour
{
    float movement;
    Rigidbody2D playerrig;

    private void Start()
    {
        playerrig = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

        if (tag == "Left")
        {
            movement = 1.0f * 150.0f * Time.deltaTime;
        }
        else if (tag == "Right")
        {
            movement = 1.0f * 150.0f * Time.deltaTime;
        }
        else
        {
            movement = 0 * 150.0f * Time.deltaTime;
        }
    }

    /*public void OnPointerDown(PointerEventData eventData)
    {
        playerrig.velocity = new Vector2(movement, 0);
    }*/
}

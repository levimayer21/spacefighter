using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeScreenTxtCount : MonoBehaviour
{
    Animator animator;
    [SerializeField] TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("timeScreenAnimEnded"))
        {
            StartCoroutine(Counter());
        }
    }

    IEnumerator Counter()
    {
        TimeSpan i = new TimeSpan(0, 0, 0);
        while (TimeSpan.Parse(text.text) < LevelManager.time.Time)
        {
            i += new TimeSpan(0, 0, 53);
            text.text = i.Hours + ":" + i.Minutes + ":" + i.Seconds;
            yield return null;
        }
        text.text = LevelManager.time.Time.ToString();
        animator.SetBool("timeScreenCountEnded", true);
    }
}

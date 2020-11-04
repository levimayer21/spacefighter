using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScreenTextCount : MonoBehaviour
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
        if (animator.GetBool("scoreScreenAnimEnded"))
        {
            StartCoroutine(Counter());
        }
    }

    IEnumerator Counter()
    {
        int i = 0;
        while (text.text != LevelManager.points.ToString())
        {
            i += 50;
            text.text = i.ToString();
            yield return null;
        }
        animator.SetBool("scoreScreenCountingEnded", true);
    }
}

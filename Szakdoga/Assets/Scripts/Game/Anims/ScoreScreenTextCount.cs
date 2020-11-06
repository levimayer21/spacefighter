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
        while (int.Parse(text.text) <= LevelManager.points)
        {
            text.text = (int.Parse(text.text) + 350).ToString();
            yield return null;
        }
        text.text = LevelManager.points.ToString();
        animator.SetBool("scoreScreenCountingEnded", true);
    }
}

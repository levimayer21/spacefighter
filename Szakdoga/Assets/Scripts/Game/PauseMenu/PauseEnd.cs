using System.Collections;
using TMPro;
using UnityEngine;

public class PauseEnd : MonoBehaviour
{
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        LevelManager.isMoveEnabled = false;
        for (int i = 3; i > 0; i--)
        {
            text.text = i.ToString();
            Debug.Log(i);
            yield return new WaitForSecondsRealtime(1f);
        }
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
        LevelManager.isMoveEnabled = true;
        Destroy(gameObject);
    }
}

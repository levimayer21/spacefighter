using System.Collections;
using TMPro;
using UnityEngine;

public class GameAnim : MonoBehaviour
{
    [SerializeField]
    GameObject animPlayer;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject playerStartPoint;
    [SerializeField]
    GameObject roundStartScreen;
    [SerializeField]
    GameObject controlGUI;
    [SerializeField]
    GameObject roundText;

    public static bool roundAnimActive;

    private void Awake()
    {
        GameEvent.gameEvent.onRoundStart += ActivateRoundStart;
    }

    private void Start()
    {
        StartCoroutine(StartAnim());
    }

    IEnumerator StartAnim()
    {
        roundAnimActive = true;
        while (animPlayer.transform.position.y < playerStartPoint.transform.position.y)
        {
            animPlayer.transform.position += new Vector3(0, 0.015f, 0);
            yield return null;
        }
        Destroy(animPlayer);
        Instantiate(player, playerStartPoint.transform.position, Quaternion.identity);
        controlGUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        GameEvent.gameEvent.RoundStart();
    }

    void ActivateRoundStart()
    {
        StartCoroutine(SetRoundAnim());
    }

    IEnumerator SetRoundAnim()
    {
        roundAnimActive = true;
        roundText.GetComponent<TextMeshProUGUI>().text = "Round " + LevelManager.round;
        roundStartScreen.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        roundStartScreen.SetActive(false);
        roundAnimActive = false;
    }
}

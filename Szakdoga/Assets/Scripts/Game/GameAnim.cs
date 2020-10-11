using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

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

    private void Start()
    {
        GameEvent.gameEvent.onRoundStart += ActivateRoundStart;
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
        yield return new WaitForSeconds(1);
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

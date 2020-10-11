using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI hiScore;
    UnityMySQL.UnityMySQL sql;

    // Start is called before the first frame update
    void Start()
    {
        sql = new UnityMySQL.UnityMySQL("server=127.0.0.1;uid=spacefighter;pwd=asd123;database=scoreboard");
        hiScore.text = sql.Query("SELECT score FROM playerscores ORDER BY score DESC LIMIT 1");
    }

    // Update is called once per frame
    void Update()
    {
        score.text = LevelManager.instance.points.ToString();
    }
}

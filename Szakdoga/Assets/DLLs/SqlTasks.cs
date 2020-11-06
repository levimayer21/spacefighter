using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;


public static class SqlTasks
{ 
    static UnityMySQL.UnityMySQL sql;

    static string playerID;

    public static void UploadScore()
    {
        try
        {
            if (LevelManager.points > 50000)
            {
                SHA256 hash = SHA256.Create();
                playerID = Encoding.UTF8.GetString(hash.ComputeHash(Encoding.UTF8.GetBytes(LevelManager.playerName + LevelManager.points.ToString() + LevelManager.time.Time.TotalMinutes.ToString())));
                Debug.Log(playerID);
                Debug.Log(LevelManager.playerName);
                Debug.Log(LevelManager.points);
                Debug.Log(LevelManager.time.Time);
                sql = new UnityMySQL.UnityMySQL("server=127.0.0.1;uid=spacefighter;pwd=asd123;database=scoreboard");
                /*sql.Write($"INSERT INTO `playerscores` (`playerid`, `name`, `score`, `time`) VALUES ('{playerID}', '{LevelManager.playerName}', '{LevelManager.points}', '{LevelManager.time.Time}') ");*/
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log("Write 1:" + ex);
            Debug.Log("Write 2:" + ex.Message);
            if (ex.InnerException != null)
            {
                Debug.Log("Write 3:" + ex.InnerException);
                Debug.Log("Write 4:" + ex.InnerException.Message);
            }
        }
    }

    public static string CheckForPlacement()
    {
        try
        {
            if (LevelManager.points > 50000)
            {
                sql = new UnityMySQL.UnityMySQL("server=127.0.0.1;uid=spacefighter;pwd=asd123;database=scoreboard");
                return "Your Place:" + sql.Query($"SELECT `row` FROM (SELECT (@row_num:= @row_num + 1) AS `row`, `playerid`, `score` FROM `playerscores` ORDER BY `score` DESC) AS e WHERE `playerid` LIKE '{playerID}'", new string[] { "row_num" }) + ".\nGGWP";
            }
            else
            {
                return "You didn't reach the minimum needed points. F";
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log("Read 1:" + ex);
            Debug.Log("Read 2:" + ex.Message);
            if (ex.InnerException != null)
            {
                Debug.Log("Read 3:" + ex.InnerException);
                Debug.Log("Read 4:" + ex.InnerException.Message);
            }
            return "Error while trying to reach server";
        }
    }
}

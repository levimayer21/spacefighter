<?php
$playerid = $_POST["playerid"];

$mysql = new mysqli(host,username,pass);

if ($mysql->connect_errno)
{
    echo("Connection error!");
}
else
{
    if ($result = $mysql->query("SELECT * FROM `playerscores` ORDER BY `score` DESC LIMIT 20"))
    {
        $scoreboard = array();
        for ($i = 1; $i < $result.count(); $i++)
        {
            if ($result[$i-1]["playerid"] == $playerid)
            {
                echo($i);
            }
        }
        echo("-1");
    }
}
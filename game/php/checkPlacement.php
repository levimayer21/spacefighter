<?php
$playerid = $_POST["playerid"];

$mysql = new mysqli('localhost','spacefighter','spacedatabase');

if ($mysql->connect_errno)
{
    echo("Connection error!" . $mysql->connect_error);
}
else
{
    if ($result = $mysql->query("SELECT * FROM `playerscores` ORDER BY `score` DESC;"))
    {
        $scoreboard = array();
        for ($i = 1; $i < $result.count(); $i++)
        {
            if ($result[$i-1]["playerid"] == $playerid)
            {
                echo("Placement: ");
            }
            else
            {
                echo("burh");
            }
        }
        echo("-1");
    }
}
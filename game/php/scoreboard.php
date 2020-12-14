<?php

$mysql = new mysqli('localhost','spacefighter','spacedatabase', 'scoreboard');

if ($mysql->connect_errno)
{
    echo("0");
}

else
{
    if ($result = $mysql->query("SELECT name,score,time FROM playerscores ORDER BY score desc LIMIT 1;"))
    {
        echo($result->fetch_array()["score"]);
    }
    else
    {
        print("0");
    }
}

$mysql->close();
?>
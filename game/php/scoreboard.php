<?php

$mysql = new mysqli('localhost','spacefighter','SfnfXVcb6oAoEvyU');

if ($mysql->connect_errno)
{
    echo("0");
}

else
{
    if ($result = $mysql->query("SELECT name,score,time FROM scoreboard.playerscores ORDER BY score desc LIMIT 1;"))
    {
        foreach($result as $item)
        {
            echo($item["score"]);
        }
        $result->close();

    }
    else
    {
        print("0");
    }
}

$mysql->close();
?>
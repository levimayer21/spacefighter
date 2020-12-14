<?php
$playerid = $_POST["playerid"];

$mysql = new mysqli('localhost','spacefighter','spacedatabase', 'scoreboard');

if ($mysql->connect_errno)
{
    echo("Connection error!" . $mysql->connect_error);
}
else
{
    if ($result = $mysql->query("SELECT `playerid` FROM `playerscores` ORDER BY `score` DESC LIMIT 10;"))
    {
        $scoreboard = array();
        $i = 1;
        while($arr = $result->fetch_array())
        {
            if ($arr["playerid"] == $playerid)
            {
                echo("Your placement: " . $i . ".\nGGWP");
                break;
            }
            else
            {
                $i++;
            }
        }
        if ($i > $result->num_rows)
        {
            echo("You didn't get into the top ". $result->num_rows .".\nBetter luck next time!");
        }
    }
}
$mysql->close();

?>
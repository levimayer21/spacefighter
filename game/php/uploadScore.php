<?php
$name = (string) $_POST['name'];
$score = (string) $_POST['score'];
$time = (string) $_POST['time'];
$playerid = sha1($name . $score . $time . date("ymdHis"));

$conn = new mysqli('localhost','spacefighter','spacedatabase', 'scoreboard');
$insert = 'INSERT INTO `playerscores` (`playerid`, `name`, `score`, `time`) VALUES ("' . $playerid . '","' . $name . '","' . $score . '","' . $time . '");';


if ($conn->connect_errno)
{
    echo("Connection Error");
}
else
{
    if ($result = $conn->query($insert))
    {
        echo($playerid);
    }
    else
    {
        echo("Process error");
    }
}

$conn->close();

?>
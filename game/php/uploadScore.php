<?php
const host = 'localhost';
const username = 'spacefighter';
const pass = 'SfnfXVcb6oAoEvyU';

$name = $_POST('name');
$score = $_POST('score');
$time = $_POST('time');
$playerid = sha1($name + $score + $time);

$mysql = new mysqli(host,username,pass);

if ($mysql->connect_errno)
{
    echo("0");
}
else
{
    if ($result = $mysql->query("INSERT INTO `playerscores` (`playerid`, `name`, `score`, `time`) VALUES ($playerid, $name, $score, $time )"))
    {
        echo($playerid);
        $result->close();
    }
    else
    {
        echo("0");
    }
}
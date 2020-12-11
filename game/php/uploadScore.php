<?php
$name = (string) $_POST['name'];
$score = (string) $_POST['score'];
$time = (string) $_POST['time'];
$playerid = sha1($name . $score . $time);

$conn = new mysqli('localhost','spacefighter','spacedatabase');
$insert = 'INSERT INTO `playerscores` (`playerid`, `name`, `score`, `time`) VALUES (' . $playerid . ',' . $name . ',' . $score . ',' . $time .');';

if ($conn->connect_errno)
{
    echo("Connection Error: " . $conn->connect_error);
}
else
{
    try
    {
        if ($dbselect = mysqli_select_db($conn, 'playerscores'))
        {
            if(mysqli_query($conn, $insert))
            {
                echo($playerid);
            }
            else
            {
                echo('Insert Error: ' . mysqli_error($conn));
            }
        }
        else
        {
            echo("DB selection error: " . $dbselect);
        }
    }
    catch (\MongoDB\Driver\Exception\Exception $ex)
    {
        echo($ex->getMessage());
    }
}
<?php
    require "sitesettings.php";
?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="theme-color" content="#95A3B3">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>SpaceFighter</title>
        <meta name="title" content="SpaceFighter">
        <meta name="description" content="Try to get the most points on the scoreboard, while fighting UFO-s with your own spaceship.">
        <meta name="keywords" content="Space, Airship, Spacefighter, Shooting, 2D, Game, UFO">
        <meta name="robots" content="index, follow">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
        <meta name="language" content="English">
        <meta name="author" content="Mayer Levente">
        <meta name="revisit-after" content="2">
        <link rel="icon" href="img/icons/sh192ico.png">
        <link rel="apple-touch-icon" href="img/icons/sh192ico.png">
        <link rel="stylesheet" href="css/materialize.min.css" type="text/css" media="screen,projection">
        <link rel="manifest" href="manifest.webmanifest">
        <link rel="stylesheet" href="css/aos.css" />
        <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
        <link href="https://fonts.googleapis.com/css2?family=Orbitron&display=swap" rel="stylesheet">
        <link rel="stylesheet" href="css/style.css" type="text/css">
    </head>
    <body>
        <!-- Navbar -->
        <header id="top">
            <nav class="black z-depth-3 nooverflow" role="navigation">
                <div id="spacenav" class="nav-wrapper container">
                    <img src="img/Spaceship.png" alt="Spaceship" id="galagapic">
                    <a id="logo-container" href="index.php" class="brand-logo bold-4">SpaceFighter</a>
                    <a href="#" data-target="nav-mobile" class="sidenav-trigger">
                        <i class="material-icons">menu</i>
                    </a>
                    <ul class="right hide-on-med-and-down">
                        <li><a class="white-text waves-effect waves-light" href="game.php">Game</a></li>
                        <?php
                            if ($_SERVER["REQUEST_URI"] === "/")
                            {
                                echo '<li><a class="white-text waves-effect waves-light" href="scoreboard.php">Scoreboard</a></li>';
                            }
                            else
                            {
                                echo '<li><a class="white-text waves-effect waves-light" href="/">Homepage</a></li>';
                            }
                        ?>
                    </ul>
                </div>
            </nav>

            <ul id="nav-mobile" class="sidenav z-depth-3">
                <li><h2 class="center-align">Menü</h2></li>
                <li><a class="waves-effect waves-light" href="game.php">Game</a></li>
                <?php
                            if ($_SERVER["REQUEST_URI"] === "/")
                            {
                                echo '<li><a class="waves-effect waves-light" href="/">Homepage</a></li>';
                            }
                            else
                            {
                                echo '<li><a class="waves-effect waves-light" href="scoreboard.php">Scoreboard</a></li>';
                            }
                ?>
            </ul>
        </header>
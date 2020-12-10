<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>SpaceFighter</title>
        <link rel="stylesheet" href="css/materialize.css" type="text/css" media="screen,projection">
        <link rel="stylesheet" href="https://unpkg.com/aos@next/dist/aos.css" />
        <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
        <link href="https://fonts.googleapis.com/css2?family=Orbitron&display=swap" rel="stylesheet"> 
        <link rel="stylesheet" href="css/style.css" type="text/css">
    </head>
    <body>
        <!-- Navbar -->
        <header id="top">
            <nav class="black z-depth-3 nooverflow" role="navigation">
                <div id="spacenav" class="nav-wrapper container">
                    <img src="img/galagaship.png" alt="galagaship" id="galagapic">
                    <a id="logo-container" href="index.php" class="brand-logo bold-4">SpaceFighter</a>
                    <a href="#" data-target="nav-mobile" class="sidenav-trigger">
                        <i class="material-icons">menu</i>
                    </a>
                    <ul class="right hide-on-med-and-down">
                        <li><a class="white-text waves-effect waves-light" href="game.php">Játék</a></li>
                        <li><a class="white-text waves-effect waves-light" href="scoreboard.php">Ponttáblázat</a></li>
                    </ul>
                </div>
            </nav>

            <ul id="nav-mobile" class="sidenav z-depth-3">
                <li><h2 class="center-align">Menü</h2></li>
                <li><a class="waves-effect waves-light" href="game.php">Játék</a></li>
                <li><a class="waves-effect waves-light" href="scoreboard.php">Ponttáblázat</a></li>
            </ul>
        </header>
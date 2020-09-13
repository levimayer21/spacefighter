<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>SpaceFighter</title>
        <link rel="stylesheet" href="/css/materialize.css" type="text/css" media="screen,projection">
        <link rel="stylesheet" href="https://unpkg.com/aos@next/dist/aos.css" />
        <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
        <link href="https://fonts.googleapis.com/css2?family=Orbitron&display=swap" rel="stylesheet"> 
        <link rel="stylesheet" href="/css/style.css" type="text/css">
    </head>
    <body>
        <!-- Navbar -->
        <nav class="black z-depth-3 nooverflow" role="navigation">
            <div id="spacenav" class="nav-wrapper container">
                <img src="/img/galagaship.png" alt="galagaship" id="galagapic">
                <a id="logo-container" href="/index.html" class="brand-logo bold-4">SpaceFighter</a>
                <a href="#" data-target="nav-mobile" class="sidenav-trigger">
                    <i class="material-icons">menu</i>
                </a>
                <ul class="right hide-on-med-and-down">
                    <li><a class="white-text waves-effect waves-light" href="/sites/game.html">Játék</a></li>
                    <li><a class="white-text waves-effect waves-light" href="#">Ponttáblázat</a></li>
                    <li><a class="white-text waves-effect waves-light" href="#">Irányítás</a></li>
                </ul>
            </div>
        </nav>

        <ul id="nav-mobile" class="sidenav">
            <li><h2 class="center-align">Menü</h2></li>
            <li><a class="waves-effect waves-light" href="/sites/game.html">Játék</a></li>
            <li><a class="waves-effect waves-light">Ponttáblázat</a></li>
            <li><a class="white-text waves-effect waves-light" href="#">Irányítás</a></li>
        </ul>

        <!-- Content -->
        <div id="content" class="container">
            <table>
                <thead>
                    <th>Helyezés</th>
                    <th>Név</th>
                    <th>Pontszám</th>
                    <th>Játékidő</th>
                </thead>

                
            </table>
        </div>
        <!-- Footer -->
        <footer class="page-footer z-depth-3">
            <div class="container">
                <div class="row">
                    <div class="col s12 m4 push-m8 right-align">
                        <h3>Jó Tesztelést!;)</h3>
                        <p>Ha hibát találnál jelezd itt: <br>
                            <p>leventemayer1@hotmail.hu<a href="mailto: leventemayer1@hotmail.hu"><i class="small material-icons white-text center right">mail</i></a></p>
                            <p>Mayer Levente<a href="https://www.messenger.com/t/levimayer0804"><i class="small material-icons white-text right">people</i></a></p>
                        </p>
                    </div>
                </div>
            </div>
            <div class="footer-copyright black zerooverflow">
                © 2020 Mayer Levente
            </div>
        </footer>

        <!-- JS hátul optimalizációs célokból-->
        <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
        <script type="text/javascript" src="/js/materialize.js"></script>
        <script type="text/javascript" src="/js/actions.js"></script>
        <script src="https://unpkg.com/aos@next/dist/aos.js"></script>
        <script>
          AOS.init();
        </script>
    </body>
</html>
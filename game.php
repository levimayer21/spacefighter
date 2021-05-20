<?php
  require "sitesettings.php";
?>
<!DOCTYPE html>
<html lang="en-us">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta http-equiv="Expires" content="0">
    <meta name="viewport" content="initial-scale=1.0, width=device-width">
    <title>SpaceFighter</title>
    <link rel="icon" href="img/icons/sh192ico.png">
    <link rel="stylesheet" href="game/style/style.css">
    <script src="game/TemplateData/UnityProgress.js"></script>
    <script src="game/Build/UnityLoader.js"></script>
    <script>
      var unityInstance = UnityLoader.instantiate("unityContainer", "game/Build/game.json", {onProgress: UnityProgress});
    </script>
  </head>
  <body>
    <div class="bg-image"></div>
    <div class="webgl-content">
      <div id="unityContainer"></div>
    </div>
  </body>
  <script type="text/javascript" scr="js/main.js"></script>
</html>

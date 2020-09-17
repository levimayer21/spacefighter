<?php
    require "header.php";
?>
    
    <!-- Content -->
    <div id="content" class="container">
        <table>
            <thead>
                <th>Helyezés</th>
                <th>Név</th>
                <th>Pontszám</th>
                <th>Játékidő</th>
            </thead>
            <tbody>
                <?php
                    $mysql = new mysqli('localhost','php','asd123');

                    if ($mysql->connect_errno)
                    {
                        printf("<p>Connect failed: %s\n</p>", $mysql->connect_error);
                        exit();
                    }

                    if ($result = $mysql->query("SELECT * FROM scoreboard.playerscores"))
                    {
                        $placement = 1;
                        foreach($result as $item)
                        {
                            $item = array_values($item);
                            printf("<tr><td>".$placement."</td><td>".$item[1]."</td><td>".$item[2]."</td><td>".$item[3]."</td></tr>");
                            $placement++;
                        }
                    }
                    else
                    {
                        print('f');
                    }

                    $mysql->close();
                ?>
            </tbody>
        </table>
    </div>

<?php
    require "footer.php";
?>
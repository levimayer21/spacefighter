<?php
    require "header.php";
?>
    
    <!-- Content -->
    <main>
        <div id="content" class="container valign-wrapper">
            <table>
                <thead>
                    <th>Helyezés</th>
                    <th>Név</th>
                    <th>Pontszám</th>
                    <th>Játékidő</th>
                </thead>
                <tbody>
                    <?php
                        $mysql = new mysqli('localhost','spacefighter','spacedatabase');

                        if ($mysql->connect_errno)
                        {
                            printf("<p>Connection failed: %s\n</p>");
                        }
                        else
                        {
                            if ($result = $mysql->query("SELECT name,score,time FROM scoreboard.playerscores ORDER BY score desc LIMIT 10;"))
                            {
                                $placement = 1;
                                foreach($result as $item)
                                {
                                    //$item = array_values($item);
                                    printf("<tr><td>".$placement."</td><td>".strtoupper($item['name'])."</td><td>".$item['score']."</td><td>".$item['time']."</td></tr>");
                                    $placement++;
                                }
                                $result->close();

                            }
                            else
                            {
                                print('f');
                            }
                        }
                        $mysql->close();
                    ?>
                </tbody>
            </table>
        </div>
    </main>

<?php
    require "footer.php";
?>
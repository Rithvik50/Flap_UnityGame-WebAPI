<?php
session_start();
if (!isset($_SESSION["username"])) {
    header("Location: index.html");
    exit();
}

$con = mysqli_connect("localhost", "root", "root", "Flap_Server");
$username = $_SESSION["username"];

$scoreQuery = "SELECT high_score FROM players WHERE username='$username'";
$scoreResult = mysqli_query($con, $scoreQuery);
$score = mysqli_fetch_assoc($scoreResult)["high_score"];

$achievementQuery = "
    SELECT a.achievement_name, pa.achievement_unlocked 
    FROM achievement a
    JOIN player_achievement pa ON a.achievement_id = pa.achievement_id 
    WHERE pa.player_id = (SELECT id FROM players WHERE username = '$username')
    ORDER BY pa.achievement_unlocked DESC";
$achievementResult = mysqli_query($con, $achievementQuery);
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>User Stats</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
    <div class="container">
        <h1>Welcome, <?php echo htmlspecialchars($username); ?>!</h1>
        <br>
        <h2>Your High Score: <?php echo htmlspecialchars($score); ?></h2>
        <br>
        <h2>Your Achievements:</h2>
        <table>
            <tr>
                <th>Achievement</th>
                <th>Date Unlocked</th>
            </tr>
            <?php while ($row = mysqli_fetch_assoc($achievementResult)) { ?>
                <tr>
                    <td><?php echo htmlspecialchars($row["achievement_name"]); ?></td>
                    <td><?php echo htmlspecialchars($row["achievement_unlocked"]); ?></td>
                </tr>
            <?php } ?>
        </table>
        <br>
        <button onclick="window.location.href='index.html'">Back to Homepage</button>
    </div>
</body>
</html>

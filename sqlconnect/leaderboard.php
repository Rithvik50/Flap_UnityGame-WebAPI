<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Leaderboard</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
    <div class="container">
        <h1>Leaderboard</h1>
        <table>
            <tr>
                <th>Username</th>
                <th>High Score</th>
            </tr>
            <?php
            $con = mysqli_connect("localhost", "root", "root", "Flap_Server");
            $query = "SELECT username, high_score FROM players ORDER BY high_score DESC";
            $result = mysqli_query($con, $query);
            while ($row = mysqli_fetch_assoc($result)) { ?>
                <tr>
                    <td><?php echo htmlspecialchars($row["username"]); ?></td>
                    <td><?php echo htmlspecialchars($row["high_score"]); ?></td>
                </tr>
            <?php } ?>
        </table>
        <button onclick="window.location.href='index.html'">Back to Homepage</button>
    </div>
</body>
</html>

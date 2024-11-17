<?php
$con = mysqli_connect("localhost", "root", "root", "Flap_Server");

if (mysqli_connect_error()) {
    echo "Error: Could not connect to database.";
    exit();
}

$username = $_POST["username"];
$points = (int)$_POST["points"];

// Get player ID
$player_query = "SELECT id FROM players WHERE username='$username'";
$player_result = mysqli_query($con, $player_query);

if (mysqli_num_rows($player_result) == 0) {
    echo "Error: User not found.";
    exit();
}

$player = mysqli_fetch_assoc($player_result);
$player_id = $player["id"];

$achievement_query = "SELECT achievement_id FROM achievement WHERE points = $points";
$achievement_result = mysqli_query($con, $achievement_query);

if (mysqli_num_rows($achievement_result) == 0) {
    echo "Error: Achievement not found.";
    exit();
}

$achievement = mysqli_fetch_assoc($achievement_result);
$achievement_id = $achievement["achievement_id"];

$check_query = "SELECT * FROM player_achievement WHERE player_id = $player_id AND achievement_id = $achievement_id";
$check_result = mysqli_query($con, $check_query);

if (mysqli_num_rows($check_result) > 0) {
    echo "Error: Achievement already unlocked.";
    exit();
}

$insert_query = "INSERT INTO player_achievement (player_id, achievement_id, achievement_unlocked) VALUES ($player_id, $achievement_id, NOW())";
if (mysqli_query($con, $insert_query)) {
    echo "0";
} else {
    echo "Error: Could not save achievement.";
}
?>

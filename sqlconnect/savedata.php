<?php
$con = mysqli_connect("localhost", "root", "root", "Flap_Server");

if (mysqli_connect_error()) {
    echo "Error: Could not connect to database. " . mysqli_connect_error();
    exit();
}

$username = $_POST["username"];
$new_high_score = $_POST["high_score"];

$namecheckquery = "SELECT username FROM players WHERE username='" . $username . "';";
$namecheck = mysqli_query($con, $namecheckquery);

if (mysqli_num_rows($namecheck) != 1) {
    echo "Error: Username doesn't exist or more than one.";
    exit();
}

$updatequery = "UPDATE players SET high_score=" . $new_high_score . " WHERE username='" . $username . "';";
if (mysqli_query($con, $updatequery)) {
    echo "High score updated successfully!";
} else {
    echo "Error: " . mysqli_error($con);
}
?>

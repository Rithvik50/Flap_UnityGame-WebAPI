<?php
session_start();
$con = mysqli_connect("localhost", "root", "root", "Flap_Server");

if (mysqli_connect_error()) {
    die("Connection failed: " . mysqli_connect_error());
}

$username = $_POST["username"];
$password = $_POST["password"];

$query = "SELECT * FROM players WHERE username = '$username'";
$result = mysqli_query($con, $query);

if (mysqli_num_rows($result) > 0) {
    $user = mysqli_fetch_assoc($result);
    $salt = $user["salt"];
    $hash = $user["hash"];
    $loginhash = crypt($password, $salt);

    if ($hash == $loginhash) {
        $_SESSION["username"] = $username;
        header("Location: user_home.php");
    } else {
        echo "Incorrect password.";
    }
} else {
    echo "Account doesn't exist. Register on the game first.";
}
?>

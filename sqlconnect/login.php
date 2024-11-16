<?php
$con = mysqli_connect("localhost", "root", "root", "Flap_Server");

if (mysqli_connect_error()) {
    echo "Error: Could not connect to database. " . mysqli_connect_error();
    exit();
}

$username = $_POST["username"];
$password = $_POST["password"];

$namecheckquery = "SELECT username, salt, hash, high_score FROM players WHERE username='" . $username . "';";
$namecheck = mysqli_query($con, $namecheckquery);

if (mysqli_num_rows($namecheck) == 0) {
    echo "Error: Username doesn't exist.";
    exit();
}

$existinginfo = mysqli_fetch_assoc($namecheck);
$salt = $existinginfo["salt"];
$hash = $existinginfo["hash"];

$loginhash = crypt($password, $salt);
if ($hash == $loginhash) {
    echo "0\t" . $existinginfo["high_score"];
} else {
    echo "Error: Incorrect password.";
    exit();
}
?>

<?php
$con = mysqli_connect("localhost", "root", "root", "Flap_Server");

if (mysqli_connect_error()) {
    echo "Error: Could not connect to database. " . mysqli_connect_error();
    exit();
}

$username = $_POST["username"];
$password = $_POST["password"];

$namecheckquery = "SELECT username FROM players WHERE username='" . $username . "';";
$namecheck = mysqli_query($con, $namecheckquery);

if (mysqli_num_rows($namecheck) > 0) {
    echo "Error: Username already exists.";
    exit();
}

$salt = "\$5\$rounds=5000\$" . "steamedhams" . $username . "\$";
$hash = crypt($password, $salt);

$insertquery = "INSERT INTO players (username, hash, salt) VALUES ('" . $username . "', '" . $hash . "', '" . $salt . "');";

if (mysqli_query($con, $insertquery)) {
    echo "User created successfully!";
} else {
    echo "Error: " . mysqli_error($con);
}
?>

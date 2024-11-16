using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager
{
    public static string username;
    public static int high_score;

    public static bool LoggedIn => !string.IsNullOrEmpty(username);

    public static void LogOut()
    {
        username = null;
        high_score = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button registerButton;
    public Button loginButton;
    public Button startButton;
    public Button deleteButton;

    public Text playerDisplay;
    public Text scoreText;

    private void Start() 
    {
        if (DBManager.LoggedIn) 
        {
            playerDisplay.text = "Player: " + DBManager.username;
            scoreText.text = "High Score: " + DBManager.high_score;
        }
        registerButton.interactable = !DBManager.LoggedIn;
        loginButton.interactable = !DBManager.LoggedIn;
        startButton.interactable = DBManager.LoggedIn;
        deleteButton.interactable = DBManager.LoggedIn;
    }

    public void GoToRegister() 
    {
        SceneManager.LoadScene(1);
    }

    public void GoToLogin() 
    {
        SceneManager.LoadScene(2);
    }

    public void StartGame() 
    {
        SceneManager.LoadScene(3);
    }

    public void GoToDelete() 
    {
        SceneManager.LoadScene(4);
    }
}

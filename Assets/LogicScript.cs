using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    private void Awake() 
    {
        if (DBManager.username == null) 
        {
            SceneManager.LoadScene(0);
        }
    }

    public void CallSaveData() 
    {
        StartCoroutine(SaveData());
    }

    IEnumerator SaveData() 
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DBManager.username);
        form.AddField("high_score", DBManager.high_score);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8888/sqlconnect/savedata.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Data save failed. Error: " + www.error);
            }
            else
            {
                if (www.downloadHandler.text == "0")
                {
                    Debug.Log("Data saved successfully!");
                }
                else
                {
                    Debug.Log("Data save failed. Error #" + www.downloadHandler.text);
                }
            }
        }

        DBManager.LogOut();
        SceneManager.LoadScene(0);
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        checkScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        checkScore();
        CheckAchievements();
        gameOverScreen.SetActive(true);
    }

    public void checkScore()
    {
        if (playerScore > DBManager.high_score)
        {
            DBManager.high_score = playerScore;
        }
    }

    public void CheckAchievements()
    {
        if (DBManager.high_score >= 2) SaveAchievement(2);
        if (DBManager.high_score >= 5) SaveAchievement(5);
        if (DBManager.high_score >= 7) SaveAchievement(7);
    }

    public void SaveAchievement(int pointsThreshold)
    {
        StartCoroutine(SaveAchievementCoroutine(pointsThreshold));
    }

    IEnumerator SaveAchievementCoroutine(int pointsThreshold)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DBManager.username);
        form.AddField("points", pointsThreshold);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8888/sqlconnect/saveachievement.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Failed to save achievement. Error: " + www.error);
            }
            else if (www.downloadHandler.text == "0")
            {
                Debug.Log("Achievement saved successfully!");
            }
            else
            {
                Debug.Log("Error saving achievement: " + www.downloadHandler.text);
            }
        }
    }

}

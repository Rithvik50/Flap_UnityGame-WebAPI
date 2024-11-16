using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LoginPlayer : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public Button submitButton;
    public Text loginDisplay;

    public void CallLogIn() 
    {
        StartCoroutine(LogIn());
    }

    IEnumerator LogIn() 
    {
        WWWForm form = new WWWForm();
        form.AddField("username", nameField.text);
        form.AddField("password", passwordField.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8888/sqlconnect/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("User login failed. Error: " + www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;

                if (responseText.StartsWith("0"))
                {
                    DBManager.username = nameField.text;

                    string[] responseParts = responseText.Split('\t');
                    if (responseParts.Length > 1 && int.TryParse(responseParts[1], out int highScore))
                    {
                        DBManager.high_score = highScore;
                    }
                    else
                    {
                        Debug.LogWarning("Failed to parse high score from response: " + responseText);
                    }

                    SceneManager.LoadScene(0);
                }
                else
                {
                    loginDisplay.text = "Username or Password is incorrect";
                }
            }
        }
    }

    public void VerifyInputs() 
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }

    public void exit() 
    {
        SceneManager.LoadScene(0);
    }
}

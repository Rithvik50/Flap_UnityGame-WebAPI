using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Registration : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;
    public Text registerDisplay;

    public void CallRegister() 
    {
        StartCoroutine(Register());
    }

    IEnumerator Register() 
    {
        WWWForm form = new WWWForm();
        form.AddField("username", nameField.text);
        form.AddField("password", passwordField.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8888/sqlconnect/register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("User creation failed. Error: " + www.error);
            }
            else
            {
                if (www.downloadHandler.text.Contains("User created successfully!"))
                {
                    SceneManager.LoadScene(0);
                }
                else
                {
                    registerDisplay.text = "Username is already taken";
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

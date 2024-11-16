using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Deletion : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;
    public Text deletionDisplay;

    public void CallDeletion() 
    {
        StartCoroutine(Delete());
    }

    IEnumerator Delete() 
    {
        WWWForm form = new WWWForm();
        form.AddField("username", nameField.text);
        form.AddField("password", passwordField.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:8888/sqlconnect/delete.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("User deletion failed. Error: " + www.error);
            }
            else
            {
                if (www.downloadHandler.text.Contains("User deleted successfully!"))
                {
                    DBManager.LogOut();
                    SceneManager.LoadScene(0);
                }
                else
                {
                    deletionDisplay.text = "Username or Password is incorrect";
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

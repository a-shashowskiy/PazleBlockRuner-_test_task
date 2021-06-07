using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.Networking;

 public class RestGit : MonoBehaviour
{
//HTML Address with user data
    private readonly string basePath = "https://api.github.com/users/a-shashowskiy"; //USER DATA FROM GIT REST API
//Fieald to show gata from request
    public TMPro.TMP_InputField data;
     //For Button call start corutine
    public void Get_D() => StartCoroutine(Get());
//Back to main menue 
    public void Return()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
//Corutine with request
    IEnumerator Get()
    {
        using(UnityWebRequest webRequest = UnityWebRequest.Get(basePath))
        { 
            string[] pages = basePath.Split('/');
            int page = pages.Length - 1;

            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                     data.text = webRequest.error;
                     Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                     break;
                case UnityWebRequest.Result.ProtocolError:
                     data.text = webRequest.error;
                     Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                     break;
                case UnityWebRequest.Result.Success:
                    data.text = webRequest.downloadHandler.text;
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}

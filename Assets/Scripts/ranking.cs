using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

public class ranking : MonoBehaviour
{

    // Temporary values, do not give any default value.
    float points;
    float timer;
    int currentLevel;
    string uploadDestination;

    void Start() {
        uploadDestination = "http://www.daanklein.nl/school/orange_and_teal/rankings.php";
        currentLevel = SceneManager.GetActiveScene().buildIndex-3;
    }

    public void sendPlayerData(float received_points, float received_timer){
        points = (Mathf.Round(received_points));
        timer = (Mathf.Round(received_timer * 100.0f) / 100.0f);

        StartCoroutine(Upload());
    }

    // Upload score data to server.
    IEnumerator Upload() {
        // Create new form.
        WWWForm form = new WWWForm();

        // Add fields to form.
        form.AddField("username", PlayerPrefs.GetString("username"));
        form.AddField("points", ""+points);
        form.AddField("timer", ""+timer);
        form.AddField("level", "" + currentLevel);

        // Send POST request with form data for further handling server-side.
        using (UnityWebRequest www = UnityWebRequest.Post(uploadDestination, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success) {
                Debug.Log(www.error);
            }
            else {
                // Debug.Log received data from server. Usually not important, but useful for debugging.
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}

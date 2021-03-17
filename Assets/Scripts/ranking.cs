using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

public class ranking : MonoBehaviour
{

    float points;
    float timer;

    void Start()
    {
        Debug.Log("Current level: " + (SceneManager.GetActiveScene().buildIndex-3));
    }

    public void sendPlayerData(float received_points, float received_timer){
        points = (Mathf.Round(received_points));
        timer = (Mathf.Round(received_timer * 100.0f) / 100.0f);

        StartCoroutine(Upload());
    }

    IEnumerator Upload() {
        WWWForm form = new WWWForm();
        form.AddField("username", PlayerPrefs.GetString("username"));
        form.AddField("points", ""+points);
        form.AddField("timer", ""+timer);
        form.AddField("level", "" + (SceneManager.GetActiveScene().buildIndex-3));

        using (UnityWebRequest www = UnityWebRequest.Post("http://www.daanklein.nl/school/orange_and_teal/rankings.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success) {
                Debug.Log(www.error);
            }
            else {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointsSystem : MonoBehaviour
{
    public float timer;
    public float points;
    public Text text_timer;
    public Text text_points;
    public Text text_username;
    bool isActive = true;

    void Start()
    {
        timer = 0f;
        points = 10000f;
        isActive = true;
        text_username.text = "Username: " + PlayerPrefs.GetString("username");
    }

    void Update()
    {
        if(isActive == true){
            timer += Time.deltaTime;
            points -= Time.deltaTime*100;
            text_timer.text = "" + (Mathf.Round(timer * 100.0f) / 100.0f);
            text_points.text = "" + (Mathf.Round(points));
            // Debug.Log((Mathf.Round(timer * 100.0f) / 100.0f));
        }
    }

    public void stopTimer(){
        isActive = false;
    }
}

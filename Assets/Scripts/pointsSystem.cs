using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointsSystem : MonoBehaviour
{
    // Variables that need to be defined in the Unity Editor.
    public float timer;
    public float points;
    public Text text_timer;
    public Text text_points;
    public Text text_username;

    // Do not change this variable, it is used to keep the timer running as long as the player has not finished yet.
    bool isActive = true;

    void Start() {
        timer = 0f;
        points = 10000f;
        isActive = true;
        text_username.text = "Username: " + PlayerPrefs.GetString("username");
    }

    void Update() {
        // Update onscreen timer/points every frame as long as the player has not hit the finish yet.
        if(isActive == true){
            timer += Time.deltaTime;
            points -= Time.deltaTime*100;
            text_timer.text = "" + (Mathf.Round(timer * 100.0f) / 100.0f);
            text_points.text = "" + (Mathf.Round(points));
        }
    }

    public void stopTimer(){
        isActive = false;
    }
}

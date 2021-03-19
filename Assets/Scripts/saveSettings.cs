using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveSettings : MonoBehaviour
{
    void Start() {
        // If username has not been set in the PlayerPrefs yet, set it to a random guest name.
        if(PlayerPrefs.GetString("username") == "" || PlayerPrefs.GetString("username") == null) {
            PlayerPrefs.SetString("username", "guest_"+Random.Range(0, 100000000));
        }
        
        // Put the new username into the Username input field.
        GameObject.Find("Username").GetComponent<InputField>().text = PlayerPrefs.GetString("username");
    }

    // Gets executed when the Username input field detects a change, meaning the user has chosen a custom username.
    public void GUI_settings_usernamechanged(){
        PlayerPrefs.SetString("username", GameObject.Find("Username").GetComponent<InputField>().text);
    }

}

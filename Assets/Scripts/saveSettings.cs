using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveSettings : MonoBehaviour
{

    Text text_username;

    void Start() {
        if(PlayerPrefs.GetString("username") == "" || PlayerPrefs.GetString("username") == null) {
            Debug.Log("username empty, creating a random one");
            PlayerPrefs.SetString("username", "guest_"+Random.Range(0, 100000000));
        }
        GameObject.Find("Username").GetComponent<InputField>().text = PlayerPrefs.GetString("username");
    }

    public void GUI_settings_usernamechanged(){
        PlayerPrefs.SetString("username", GameObject.Find("Username").GetComponent<InputField>().text);
        Debug.Log("Welcome "+PlayerPrefs.GetString("username"));
    }

}

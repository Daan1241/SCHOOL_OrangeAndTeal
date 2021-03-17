using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUI_controller : MonoBehaviour
{

    public void GUI_info_back(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
    public void GUI_howtoplay_back(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-2);
    }

    public void GUI_settings_back(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-3);
    }

    public void GUI_start_info(){
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void GUI_start_howtoplay(){
        Application.OpenURL("http://bluepixelanimations.nl/portfolio/?page_id=292");
        //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
    }

    public void GUI_start_settings(){
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+3);
    }

    public void GUI_start_settings_resetall(){
        PlayerPrefs.DeleteAll();
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void GUI_start_newgame(){
        PlayerPrefs.SetInt("MaxLevel", 0);
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+4);
    }

    public void GUI_start_continue(){
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+4 + PlayerPrefs.GetInt("MaxLevel"));
    }
    


    public void GUI_end_restart(){
        
        SceneManager.LoadScene(0);
    }



}

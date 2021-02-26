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

    public void GUI_start_info(){
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void GUI_start_howtoplay(){
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
    }


    public void GUI_start_newgame(){
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+3);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathFloor : MonoBehaviour
{

    public GameObject player;
    bool scaledown = false;
    float time;

    private void FixedUpdate(){
        if(scaledown){
        player.transform.localScale = Vector3.Lerp (player.transform.localScale, new Vector3 (.001f, .001f, .001f), 5.0f * Time.deltaTime);
        time = time + Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other) {
		if(other.name == "Player"){
	    Invoke("killPlayer", 2);
        scaledown = true;
        }
	}
	
	private void killPlayer(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}

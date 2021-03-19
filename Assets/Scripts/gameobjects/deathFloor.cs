using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathFloor : MonoBehaviour
{

    // This value needs to be set to the player in the Unity Editor
    public GameObject player;

    // Temporary values managed by the Unity Editor
    bool scaledown = false;
    float time;

    private void FixedUpdate(){

        // If scaledown = true, scale player down untill it becomes too small to see, using Lerp.
        if(scaledown){
        player.transform.localScale = Vector3.Lerp (player.transform.localScale, new Vector3 (.001f, .001f, .001f), 5.0f * Time.deltaTime);
        time = time + Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other) {
		if(other.name == "Player"){
            // Restart current level.
            Invoke("killPlayer", 2);
            scaledown = true; // Starts scalnig down untill the level gets reloaded 2 seconds later.
        }
	}
	
    // Restarts the current level.
	private void killPlayer(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}

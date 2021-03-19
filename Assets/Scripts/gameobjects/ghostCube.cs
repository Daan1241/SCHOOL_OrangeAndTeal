using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostCube : MonoBehaviour
{
	
	public GameObject player; // Set this value to the player in the Unity Editor
	public GameObject cracked; // Set this value to the ghostCube_cracked prefab.

	// Temporary values handled by the computer.
	float distBetweenPlayer;
	bool destroyed;
	
    void Start() {
		destroyed = false;
    }

	// When colliding with the player, remove this object and replace it with the cracked version of it (the ghostCube_cracked prefab).
	void OnCollisionEnter(Collision collision){
		if(destroyed == false && collision.gameObject.name == player.name){
		Destroy(this.gameObject);
		Instantiate(cracked, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
		destroyed = true;
		}
	}
}

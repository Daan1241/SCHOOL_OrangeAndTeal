using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostCube : MonoBehaviour
{
	
	public GameObject player;
	public GameObject cracked;
	float distBetweenPlayer;
	bool destroyed;
	
    void Start()
    {
		destroyed = false;
    }

	void OnCollisionEnter(Collision collision){
		if(destroyed == false && collision.gameObject.name == player.name){
		Destroy(this.gameObject);
		Instantiate(cracked, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
		destroyed = true;
		}
		
	}

	// Old code that changed alpha value depending on how far the player is from the object:

    // void FixedUpdate()
    // {
    //     distBetweenPlayer = Vector3.Distance(player.transform.position, transform.position)/2;
		
	// 	if(distBetweenPlayer <= 0){
	// 		distBetweenPlayer = 0;
	// 	} else if(distBetweenPlayer >= 1){
	// 		distBetweenPlayer = 1;
	// 	}


	// 	this.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0.1f, 0.1f, 0.1f, distBetweenPlayer));
	// 	this.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color(0.1f, 0.1f, 0.1f, distBetweenPlayer));
    // }

	
}

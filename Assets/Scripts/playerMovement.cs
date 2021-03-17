using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
	
	// Variables that can be modified trough the Unity Editor.
	public GameObject player;
	public GameObject camera;
	public GameObject collider;
	public AudioClip hit;
	public float volume;
	public float speed;
	public float jumpForce;

	// Temporary variables, do not modify
    AudioSource[] audioSources;
	Vector3 prevPos;
	float averageVelocity;
	Rigidbody rb;
	float moveInputH, moveInputV;
	
	
    void Start() {
        rb = player.GetComponent<Rigidbody>();
		audioSources = GetComponents<AudioSource>();
		// Start rolling ball sound, yet still unhearable because the volume will stay at 0 when the player is not moving
		audioSources[0].Play();
    }

    void FixedUpdate()
    {
		// Debug.Log("Max Level: "+PlayerPrefs.GetInt("MaxLevel"));
		
		averageVelocity = (rb.velocity.x + rb.velocity.z) / 2;
		if(averageVelocity < 0){
			averageVelocity = averageVelocity*-1f;
		} else {
			// do nothing lol
		}

		if(averageVelocity < 0){
			averageVelocity = averageVelocity * -1;
		}

		audioSources[0].volume = averageVelocity*volume;
		audioSources[0].pitch = averageVelocity*1.0001f;
		
		prevPos = this.transform.position;
        moveInputH = Input.GetAxisRaw("Horizontal");
		moveInputV = Input.GetAxisRaw("Vertical");
		
		rb.AddForce(Vector3.right * moveInputH * speed);
		rb.AddForce(Vector3.forward * moveInputV * speed);
		
		
		if(Input.GetKeyDown(KeyCode.Space)){
			rb.AddForce(Vector3.up * jumpForce); // wrong code, camera is slightly tilted, so using the up axis will make the jump act weird.
		}
    }

	void OnTriggerEnter(Collider other){
		  	if (other.tag == "wall"){
				audioSources[1].volume = averageVelocity*.25f;
				audioSources[1].pitch = averageVelocity*.25f;
        		audioSources[1].Play();
			}
			// Debug.Log(other.tag);
        }
	 
}

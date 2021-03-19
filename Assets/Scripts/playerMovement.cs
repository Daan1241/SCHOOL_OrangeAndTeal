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


	// Temporary variables, do not modify.
    AudioSource[] audioSources;
	Vector3 prevPos;
	float averageVelocity;
	Rigidbody rb;
	float moveInputH, moveInputV;
	
	
    void Start() {
		// Define player's rigidbody and audio source.
        rb = player.GetComponent<Rigidbody>();
		audioSources = GetComponents<AudioSource>();

		// Start rolling ball sound, yet still unhearable because the volume will stay at 0 when the player is not moving.
		audioSources[0].Play();

		// Check if player username is set, and if not, set to a guest username.
		if(PlayerPrefs.GetString("username") == "" || PlayerPrefs.GetString("username") == null) {
            Debug.Log("username empty, creating a random one");
            PlayerPrefs.SetString("username", "guest_"+Random.Range(0, 100000000));
        }
    }

    void FixedUpdate() {
		// Calculate average velocity every frame.
		averageVelocity = (rb.velocity.x + rb.velocity.z) / 2;
		if(averageVelocity < 0){
			averageVelocity = averageVelocity*-1f;
		}

		// Change player audiosource volume on every frame, depending on how fast the player is moving.
		audioSources[0].volume = averageVelocity*volume;
		audioSources[0].pitch = averageVelocity*1.0001f;
		
		// Controller support, get user input axises.
		prevPos = this.transform.position;
        moveInputH = Input.GetAxisRaw("Horizontal");
		moveInputV = Input.GetAxisRaw("Vertical");
		
		rb.AddForce(Vector3.right * moveInputH * speed);
		rb.AddForce(Vector3.forward * moveInputV * speed);
		
		// Code for potential future feature, allowing the player to jump [spacebar]. jumpForce can be set in the Unity Editor, but will be default at 0.
		if(Input.GetKeyDown(KeyCode.Space)){
			rb.AddForce(Vector3.up * jumpForce); 
		}
    }


	void OnTriggerEnter(Collider other){
			// Make hit sound when player hits a wall. Works only 50% of the time... :/
		  	if (other.tag == "wall"){
				audioSources[1].volume = averageVelocity*.25f;
				audioSources[1].pitch = averageVelocity*.25f;
        		audioSources[1].Play();
			}
        }
	 
}

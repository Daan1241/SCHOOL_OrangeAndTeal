using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
	
	public Rigidbody rb;
	public GameObject player;
	public GameObject camera;
	public GameObject collider;
	public AudioClip hit;
    AudioSource[] audioSources;
	Vector3 prevPos;
	float averageVelocity;
	
	
	float moveInputH, moveInputV;
	public float speed, jumpForce;
	
    void Start()
    {
		
        rb = player.GetComponent<Rigidbody>();
		audioSources = GetComponents<AudioSource>();
		audioSources[0].Play();
    }

    void FixedUpdate()
    {
		averageVelocity = (rb.velocity.x + rb.velocity.z) / 2;
		if(averageVelocity < 0){
			averageVelocity = averageVelocity*-1f;
		} else {
			// do nothing lol
		}

		if(averageVelocity <0){
			averageVelocity = averageVelocity * -1;
			}
		// Debug.Log(averageVelocity);
		audioSources[0].volume = averageVelocity;
		audioSources[0].pitch = averageVelocity*1.0001f;
		Debug.Log(averageVelocity*1.0001f);
		

			//Debug.Log((this.transform.position.x - prevPos.x) + " en " + (this.transform.position.x - prevPos.x));
		
		
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
			Debug.Log(other.tag);
        }
	 
}

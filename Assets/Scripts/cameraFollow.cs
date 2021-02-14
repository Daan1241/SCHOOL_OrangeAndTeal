using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
	
    // Variables that can be modified trough editor.
	public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Camera cam;
    public GameObject player;

    // Temporary variables, do not modify.
    Rigidbody player_rb;
    Transform target;


    // Initialize variables
    void Start(){
        target = player.transform;
        player_rb = player.GetComponent<Rigidbody>();
    }


    // Smoothly follow player.
    void FixedUpdate() {	
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }
}

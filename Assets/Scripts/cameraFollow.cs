using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
	
	Transform target;
	public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Camera cam;
    public GameObject player;
    Rigidbody player_rb;

    void Start(){
        target = player.transform;
        player_rb = player.GetComponent<Rigidbody>();

    }
	

    // Update is called once per frame
    void FixedUpdate()
    {	
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}

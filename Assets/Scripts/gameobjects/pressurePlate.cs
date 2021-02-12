﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlate : MonoBehaviour
{
    
	public GameObject player;
    public GameObject triggerObject;
	public string moveAxis;
    public float moveAxis_direction;

    float x, y, z, distBetweenPlayer;
    string triggered;
    Vector3 triggerObject_startPosition;
    
	
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        triggered = "start";
        triggerObject_startPosition = new Vector3(triggerObject.transform.position.x, triggerObject.transform.position.y, triggerObject.transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate(){
    distBetweenPlayer = 0.8f-Vector3.Distance(player.transform.position, transform.position); // Update height of pressure plate, depending on if player stands on it.
	
	if(distBetweenPlayer >= 0){ // Player is close enaugh for valid trigger.
		transform.position = new Vector3(x, y-distBetweenPlayer/8, z);
        if(triggered == "start"){
            Debug.Log("TRIGGER PRESSUREPLATE!!!");
            triggered = "pressed";
        } else {
            // Do nothing, trigger has already been triggered
        }
	}

    if(triggered == "pressed"){
            if(moveAxis == "x" || moveAxis == "X"){
                if(triggerObject.transform.localScale.x == 1){
                triggerObject.transform.localScale = new Vector3(.95f, .95f, .95f);
                }
                if(triggerObject_startPosition.x - triggerObject.transform.position.x > -.9f){
                triggerObject.transform.position += new Vector3(.025f*moveAxis_direction , 0, 0);
                } else {
                    Debug.Log("pressureplate killed");
                    triggered = "dead";
                }
            } else if(moveAxis == "z" || moveAxis == "Z"){
                if(triggerObject.transform.localScale.z == 1){
                triggerObject.transform.localScale = new Vector3(.95f, .95f, .95f);
                }
                if(triggerObject_startPosition.z - triggerObject.transform.position.z > -.9f){
                triggerObject.transform.position += new Vector3(0, 0, .025f*moveAxis_direction);
                } else {
                    Debug.Log("pressureplate killed");
                    triggered = "dead";
                }
            }

            


            //triggered = "dead";
        }
    
    }
}
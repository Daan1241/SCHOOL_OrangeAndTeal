using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideCube : MonoBehaviour
{
	
	// Variables that can be set in the Unity Editor.
	[Tooltip("Brightness of the emissive color")]
	public float brightness;
	public Light childlight;
	public Color startColor;
	public Color endColor;
	public GameObject sound;
	public bool invert;

	 // Amount of units the slideCube has to move before triggering.
	[Tooltip("Amount of units the slideCube has to move before triggering.")]
	public float triggerTreshold;

	// Object that gets influenced when trigger is triggered.
	[Tooltip("Object that gets influenced when trigger is triggered.")]
	public GameObject triggerObject; 

	[Tooltip("How many of these objects are there in total, and which one is this one (number). This is used to define the pitch of the sound played when triggered, starting with 0")]
	public float objectIndex;
	
	// Temporary variables handled by the computer.
	float startPosZ, startPosX;
	Color color_slideCube;
	Color color;
	Material mymat;
	bool soundPlayed = false;
	float change;
	

	

    void Start() {
        startPosZ = transform.position.z;
        startPosX = transform.position.x;
		childlight = childlight.GetComponent<Light>();
		mymat = GetComponent<Renderer>().material;
    }


    void FixedUpdate() {
		// Sets the 'change' variable to the amount of units the slideCube has moved from its original posistion.
		if(invert == true){
			change = (transform.position.z-startPosZ)+(transform.position.x-startPosX) * -1f;
		}else {
			change = (transform.position.z-startPosZ)+(transform.position.x-startPosX);
		}
			// Sets variable color to the corresponding location in the orange/teal gradient. 
			color = Color.Lerp(startColor *brightness, endColor *brightness, change/triggerTreshold);
			mymat.SetColor("_EmissiveColor", color);
			childlight.color = color/250;

			// Plays piano tone when the slideCube has been moved into its meant position.
			if(change/triggerTreshold >= 1 && soundPlayed == false) {
				var audioData = sound.GetComponent<AudioSource>();
				switch(objectIndex){
					case 0: 
					audioData.pitch = .53f;
					break;
					case 1:
					audioData.pitch = .26f;
					break;
					case 2:
					audioData.pitch = .13f;
					break;
				}
        		audioData.Play(0);
				soundPlayed = true;
			}
    }
}

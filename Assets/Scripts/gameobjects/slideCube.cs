using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideCube : MonoBehaviour
{
	
	float startPosZ, startPosX;
	Color color_slideCube;
	//Color color_slideCubeLight;
	Color color;
	Material mymat;
	bool soundPlayed = false;
	float change;
	
	[Tooltip("Brightness of the emissive color")]
	public float brightness;
	public Light childlight;

	public Color startColor;
	public Color endColor;

	public GameObject sound;


	
	public bool invert;
	
	[Tooltip("Amount of units the slideCube has to move before triggering")]
	public float triggerTreshold; // Amount of units the slideCube has to move before triggering
	
	[Tooltip("Object that gets influenced when trigger is triggered.")]
	public GameObject triggerObject; // Object that gets influenced when trigger is triggered.

	[Tooltip("How many of these objects are there in total, and which one is this one (number). This is used to define the pitch of the sound played when triggered, starting with 0")]
	public float objectIndex;
	
	

    void Start()
    {
		// startColor = new Color(0f, 130f, 191f, 0);
		// endColor = new Color(255f, 53f, 0f, 0);
        startPosZ = transform.position.z;
        startPosX = transform.position.x;
		
		
		childlight = childlight.GetComponent<Light>();

		
		mymat = GetComponent<Renderer>().material;
		
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		
		
		changeColor();
		mymat.SetColor("_EmissiveColor", color);
		
        
          
    }
	
	void changeColor(){
		if(invert == true){
			change = (transform.position.z-startPosZ)+(transform.position.x-startPosX) * -1f;
		}else {
			change = (transform.position.z-startPosZ)+(transform.position.x-startPosX);
		}
			
			color = Color.Lerp(startColor *brightness, endColor *brightness, change/triggerTreshold);
			//mymat.shader = Shader.Find("HDRenderPipeline/LitTessellation"); 
			mymat.SetColor("_EmissiveColor", color);
			childlight.color = color/250;
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

			// color_slideCubeLight = Color.Lerp(new Color(0f, 130f, 191f, 0) /100, new Color(255f, 53f, 0f, 0) /100, change/triggerTreshold);
			// childlight.color = color_slideCubeLight;
	
	}
	
	
}

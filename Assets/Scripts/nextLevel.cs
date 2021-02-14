using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
	
	// Will be entered in Unity Editor
	public GameObject player;
	public GameObject playerHeart;
	public GameObject endTarget;
	public Light light;
	public float brightness;
	public Color startColor;
	public Color endColor;

	// Temporary variables, do not give any value. Default: false.
	bool scaleDown;
	bool changeColor;

	// Pre-made variables, do not give any value. Will be initialized at Start().
	Rigidbody playerRb;
	Material material;
	Material playerHeartMaterial;
	Color color_pressurePlate;
	Color color_pressurePlateLight;
	float time;


    void Start()
    {
        scaleDown = false;
		changeColor = false;
		playerRb = player.GetComponent<Rigidbody>();
		material = GetComponent<Renderer>().material;
		playerHeartMaterial = playerHeart.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(scaleDown == true){
			if(player.transform.localScale.x > 0.001f){
			player.transform.localScale = Vector3.Lerp (player.transform.localScale, new Vector3 (.5f, .5f, .5f), 5.0f * Time.deltaTime);
			}
		
		if(playerRb.useGravity == true)
				playerRb.useGravity = false;
			   playerRb.MovePosition (Vector3.Lerp (player.transform.position, endTarget.transform.position, 5.0f * Time.deltaTime));
		}
		
		if(changeColor == true){
			
			time = time + Time.deltaTime;
			 color_pressurePlate = Color.Lerp(startColor*brightness*10000, endColor*brightness*10000, time);
			 material.SetColor("_EmissiveColor", color_pressurePlate);

			color_pressurePlateLight = Color.Lerp(startColor* brightness/10000000, endColor * brightness/10000000, time);
			 light.color = color_pressurePlateLight;

			 Color color_playerHeart = Color.Lerp(startColor *brightness*10000, endColor *brightness*10000, time);
			 playerHeartMaterial.SetColor("_EmissiveColor", color_playerHeart);
		}
    }
	
	 private void OnTriggerEnter(Collider other)
    {
		//Invoke("nextlevel", 2);
		scaleDown = true;
		changeColor = true;
    }
	
	private void nextlevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	
}

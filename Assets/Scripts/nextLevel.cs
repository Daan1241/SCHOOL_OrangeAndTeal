using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
	
	public GameObject player;
	public GameObject playerHeart;
	public GameObject endTarget;
	public Light light;
	private bool scaleDown;
	private bool changeColor;
	public Rigidbody playerRb;
	Material material;
	Material playerHeartMaterial;
	float time;
    // Start is called before the first frame update
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
			 Color color_pressurePlate;
			 color_pressurePlate = Color.Lerp(new Color(0f, 130f, 191f, 0) *5, new Color(255f, 53f, 0f, 0) *5, time);
			 material.SetColor("_EmissiveColor", color_pressurePlate);
			 light.color = Color.Lerp(new Color(0f, 0.13f, 0.191f, 0), new Color(255f, 53f, 0f, 0) / 50, time);

			 Color color_playerHeart = Color.Lerp(new Color(0f, 130f, 191f, 0) *5, new Color(255f, 53f, 0f, 0) *5, time);
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

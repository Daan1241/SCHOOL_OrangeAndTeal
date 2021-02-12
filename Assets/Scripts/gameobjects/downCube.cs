using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downCube : MonoBehaviour
{
    
	private bool startGoDown;
	public float timeScale;
	float time, startX, startY, startZ;
    void Start()
    {
        startGoDown = false;
		startX = transform.position.x;
		startY = transform.position.y;
		startZ = transform.position.z;
    }
	
	private void OnTriggerEnter(Collider other)
    {
		startGoDown = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if(startGoDown == true){
			time = time + Time.deltaTime;
			transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x, startY-1.2f, transform.position.z), time*timeScale);
			transform.localScale = Vector3.Lerp (transform.localScale, new Vector3 (0, 0, 0), time*timeScale);
		}
    }
}

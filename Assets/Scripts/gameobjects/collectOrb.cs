using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectOrb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("loaded orb");
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Player"){ 
                GameObject.Find("Canvas").GetComponent<pointsSystem>().points += 1000;
                Destroy(gameObject);
                Debug.Log("destroy orb!!!");
        }
        
        
    }
}

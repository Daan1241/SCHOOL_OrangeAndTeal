using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectOrb : MonoBehaviour
{

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Player"){
                // Give player 1000 points for finding the orb.
                GameObject.Find("Canvas").GetComponent<pointsSystem>().points += 1000;

                // Destroy object, since it has been picked up by player
                Destroy(gameObject);
        }
        
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleUp : MonoBehaviour
{
    // This values needs to be set to the player in the Unity Editor.
    public GameObject player;

    // Scaling up factor of the player. For example, 2 will result in playersize*2, meaning it will double the size. Same for 4, resulting in 4 times the original size. Etc, etc.
    [Tooltip("Scaling up factor of the player. For example, 2 will result in playersize*2, meaning it will double the size. Same for 4, resulting in 4 times the original size. Etc, etc.")]
    public float scaleUpFactor;

    // Temporary values handles by the computer.
    Vector3 startPlayerSize;
    Vector3 currentPlayerSize;
    float realPlayerSize;
    float timer = 0;

    void Start() {
        // Save original player size into a Vector3.
        startPlayerSize = new Vector3(
            player.transform.localScale.x,
            player.transform.localScale.y,
            player.transform.localScale.z
        );
    }

    void OnCollisionStay(Collision collision) {
        // If the object collides with player, scale player up using Lerp.
        if(collision.gameObject.name == player.name){
            timer += Time.deltaTime;

                if(player.transform.localScale.x <= startPlayerSize.x){
                    player.transform.localScale = Vector3.Lerp(player.transform.localScale, player.transform.localScale * scaleUpFactor, timer/50);
                }
        }
    }
    

    void OnCollisionExit(Collision collision) {
        // Reset timer once player leaves the objects collission zone.
        timer = 0;
    }
    
}

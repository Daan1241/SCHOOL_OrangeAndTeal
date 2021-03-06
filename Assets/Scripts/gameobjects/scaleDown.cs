using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleDown : MonoBehaviour
{
    
    public GameObject player;

    [Tooltip("Scaling down factor of the player. For example, 2 will result in playersize/2, meaning it will half the size. Same for 4, resulting in a quarter of the original size. Etc, etc.")]
    public float scaleDownFactor;

    Vector3 startPlayerSize;
    Vector3 currentPlayerSize;
    float realPlayerSize;
    float timer = 0;

    void Start() {
        Debug.Log("scaleDown.cs loaded.");
        startPlayerSize = new Vector3(
            player.transform.localScale.x,
            player.transform.localScale.y,
            player.transform.localScale.z
        );
    }

    void Update() {
    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log("Enter");
    }

    void OnCollisionStay(Collision collision) {
        if(collision.gameObject.name == player.name){
            timer += Time.deltaTime;

                if(player.transform.localScale.x >= startPlayerSize.x/scaleDownFactor){
                    player.transform.localScale = Vector3.Lerp(player.transform.localScale, player.transform.localScale / scaleDownFactor, timer/50);
                }
        }
    }
    

    void OnCollisionExit(Collision collision) {
        Debug.Log("Exit");
        timer = 0;
    }
    
}

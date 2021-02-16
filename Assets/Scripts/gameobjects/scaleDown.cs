using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleDown : MonoBehaviour
{
    
    public GameObject player;
    public float playerScale_start;
    public float playerScale_end;

    float currentPlayerSize;

    void Start() {
        Debug.Log("scaleDown.cs loaded.");
    }

    void Update() {
        
    }

    void OnCollisionEnter(Collision collision) {
        currentPlayerSize = player.transform.localScale.x;
    }
    void OnCollisionExit(Collision collision) {
        Debug.Log("Exit");
    }
    void OnCollisionStay(Collision collision) {
        Debug.Log("Stay");
    }
}

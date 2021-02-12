using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldGenerator : MonoBehaviour
{
    public GameObject wall;
    public GameObject slideCube;

    public float worldSize;

    // Start is called before the first frame update
    void Start()
    {
        worldSize = 16;
        generateLevel(1);
        
    }

    void generateLevel(float seed){
        Debug.Log("Seed: "+seed);
        // World size: 16x
        // Usable world size: 14x14
        //
        // 1. Generate 16x16 border
        for(float x = 0; x < worldSize; x++){
            for(float z = 0; z < worldSize; z++){
                if(x > 0 && x < worldSize-1 && z > 0 && z < worldSize-1){ // inside level
                
                    // if(Random.Range(0f, 1f) <.1f){
                    //     Instantiate(slideCube, new Vector3(x, 0.5f, z), Quaternion.identity);
                    // }

                } else { // generate wall
                    Instantiate(wall, new Vector3(x, 0.5f, z), Quaternion.identity);

                }
            

            Debug.Log("loop: "+x);
            }
        }
    }
}
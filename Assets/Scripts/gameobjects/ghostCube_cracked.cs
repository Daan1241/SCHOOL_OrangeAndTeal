using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostCube_cracked : MonoBehaviour
{

    bool explode = false;
    // Update is called once per frame
    void Update()
    {
            foreach (Transform child in transform)
            {
                if(explode == false){
                    Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
                    foreach (Collider hit in colliders){
                            Rigidbody rb = hit.GetComponent<Rigidbody>();
                            if (rb != null)
                                rb.AddExplosionForce(5f, transform.position, 1f, 3.0F);
                        }
                    explode = true;
                }
                if(child.transform.localScale.x < .0f){
                    Destroy(child.gameObject);
                    Destroy(this.gameObject);
                } else{
                child.transform.localScale -= new Vector3(Time.deltaTime*.25f, Time.deltaTime*.25f, Time.deltaTime*.25f);
                }
            }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraavityChanger : MonoBehaviour
{
    public float isGravity;
    Rigidbody2D gravityZone;
	// Use this for initialization
	void Awake ()
    {
        gravityZone = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Player")
        {
            Physics.gravity = new Vector3(0, -50f, 0);
        }
        
    }


    private void OnTriggerExit2D(Collider2D other)
    {

            if (other.tag == "Player")
            {
                Physics.gravity = new Vector3(0, -9.8f, 0);
            }
        
    }
}

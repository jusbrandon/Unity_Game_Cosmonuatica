using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    Rigidbody2D myRB;
    public static float rocketSpeed;
	// Use this for initialization
	void Awake () {
        myRB = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {

    }

    public void removeForce()
    {
        myRB.velocity = new Vector2(0, 0);
    }
}

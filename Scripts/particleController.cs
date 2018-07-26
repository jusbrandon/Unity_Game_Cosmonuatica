using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleController : MonoBehaviour {
    public float particleLife;
    private float particleStart;
	// Use this for initialization
	void Start () {
        particleStart = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > particleStart + particleLife)
        {
            Destroy(gameObject);
        }
	}
}

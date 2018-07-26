using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public float aliveTime;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, aliveTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

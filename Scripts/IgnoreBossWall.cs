using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreBossWall : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Shootable"), LayerMask.NameToLayer("BossWall"));
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

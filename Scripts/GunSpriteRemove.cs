using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpriteRemove : MonoBehaviour {
    private float aliveTime = 0.25f;
    private float deathTime;

	// Use this for initialization
	void Start () {
        deathTime = Time.time + aliveTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > deathTime)
        {
            Destroy(gameObject);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaHit : MonoBehaviour {
    public int weaponDmg;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
            hurtEnemy.addDamage(weaponDmg);
        }
    }
}

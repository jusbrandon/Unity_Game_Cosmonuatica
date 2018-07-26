using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHit : MonoBehaviour {

    public static float weaponDamage;
    ProjectileController myPC;
    public GameObject explosionEffect;


    // Use this for initialization
    void Awake () {
        myPC = GetComponentInParent<ProjectileController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            //Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if(other.tag == "Enemy")
            {
                EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
            if(other.tag == "Wall")
            {
                HiddenWalls hurtWall = other.gameObject.GetComponent<HiddenWalls>();
                hurtWall.addDamage(weaponDamage);
            }
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            //Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (other.tag == "Enemy")
        {
            //HiddenWalls hurtWall = other.gameObject.GetComponent<HiddenWalls>();
            //hurtWall.addDamage(weaponDamage);
            EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
            hurtEnemy.addDamage(weaponDamage);
        }
    }


}

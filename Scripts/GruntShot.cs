using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntShot : MonoBehaviour {
    public float attackInterval;
    private float nextAttack;
    public GameObject shot;
    public GameObject gunTip;
	// Use this for initialization
	void Start () {
        nextAttack = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && Time.time > nextAttack)
        {
            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + attackInterval;
                GameObject m1 = (GameObject)Instantiate(shot, gunTip.transform.position, Quaternion.Euler(0, 0, 0));
                m1.GetComponent<Rigidbody2D>().velocity = new Vector2(GameObject.Find("Konstantine").transform.position.x - gunTip.transform.position.x, GameObject.Find("Konstantine").transform.position.y - gunTip.transform.position.y).normalized * 50;

            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(Time.time > nextAttack)
            {
                nextAttack = Time.time + attackInterval;
                GameObject m1 = (GameObject)Instantiate(shot, gunTip.transform.position, Quaternion.Euler(0, 0, 0));
                m1.GetComponent<Rigidbody2D>().velocity = new Vector2(GameObject.Find("Konstantine").transform.position.x - gunTip.transform.position.x, GameObject.Find("Konstantine").transform.position.y - gunTip.transform.position.y).normalized * 50;

            }
        }
    }
}

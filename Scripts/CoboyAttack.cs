using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoboyAttack : MonoBehaviour {
    public float attackInterval;
    private float nextAttack;
    public GameObject enemyMissile;
    public GameObject gunTip;
	// Use this for initialization
	void Start () {
        nextAttack = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        int num1 = Random.Range(0, 2);
        int num2 = Random.Range(0, 2);
        int num3 = Random.Range(0, 2);
        int num4 = Random.Range(0, 2);
        int num5 = Random.Range(0, 2);
        if (other.tag == "Player")
        {
            if(Time.time > nextAttack)
            {
                nextAttack = Time.time + attackInterval;
                if (num1 == 0)
                {
                    GameObject m1 = (GameObject)Instantiate(enemyMissile, gunTip.transform.position, Quaternion.Euler(0, 0, 0));
                    m1.GetComponent<Rigidbody2D>().velocity = new Vector2(GameObject.Find("Konstantine").transform.position.x - gunTip.transform.position.x, GameObject.Find("Konstantine").transform.position.y - gunTip.transform.position.y).normalized * 5;
                }
                if(num2 == 0)
                {
                    GameObject m2 = (GameObject)Instantiate(enemyMissile, gunTip.transform.position, Quaternion.Euler(0, 0, 0));
                    m2.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<PlayerController>().transform.position.x - gunTip.transform.position.x, GetComponent<PlayerController>().transform.position.y - gunTip.transform.position.y + .15f).normalized * 5;
                }
                if(num3 == 0)
                {
                    GameObject m3 = (GameObject)Instantiate(enemyMissile, gunTip.transform.position, Quaternion.Euler(0, 0, 0));
                    m3.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<PlayerController>().transform.position.x - gunTip.transform.position.x, GetComponent<PlayerController>().transform.position.y - gunTip.transform.position.y - .15f).normalized * 5;
                }
                if(num4 == 0)
                {
                    GameObject m4 = (GameObject)Instantiate(enemyMissile, gunTip.transform.position, Quaternion.Euler(0, 0, 0));
                    m4.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<PlayerController>().transform.position.x - gunTip.transform.position.x, GetComponent<PlayerController>().transform.position.y - gunTip.transform.position.y + .3f).normalized * 5;
                }
                if(num5 == 0)
                {
                    GameObject m5 = (GameObject)Instantiate(enemyMissile, gunTip.transform.position, Quaternion.Euler(0, 0, 0));
                    m5.GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<PlayerController>().transform.position.x - gunTip.transform.position.x, GetComponent<PlayerController>().transform.position.y - gunTip.transform.position.y - .3f).normalized * 5;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        int num1 = Random.Range(0, 2);
        int num2 = Random.Range(0, 2);
        int num3 = Random.Range(0, 2);
        int num4 = Random.Range(0, 2);
        int num5 = Random.Range(0, 2);
        if (other.tag == "Player")
        {
            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + attackInterval;
                if(num1 == 0)
                {
                    GameObject m1 = (GameObject)Instantiate(enemyMissile, gunTip.transform.position, Quaternion.Euler(0, 0, 0));
                    m1.GetComponent<Rigidbody2D>().velocity = new Vector2(GameObject.Find("Konstantine").transform.position.x - gunTip.transform.position.x, GameObject.Find("Konstantine").transform.position.y - gunTip.transform.position.y).normalized * 50;
                }
                if(num2 ==0)
                {
                    GameObject m2 = (GameObject)Instantiate(enemyMissile, gunTip.transform.position, Quaternion.Euler(0, 0, 0));
                    m2.GetComponent<Rigidbody2D>().velocity = new Vector2(GameObject.Find("Konstantine").transform.position.x - gunTip.transform.position.x, GameObject.Find("Konstantine").transform.position.y - gunTip.transform.position.y + 5f).normalized * 50;                
                }
                if(num3 == 0)
                {
                    GameObject m3 = (GameObject)Instantiate(enemyMissile, gunTip.transform.position, Quaternion.Euler(0, 0, 0));
                    m3.GetComponent<Rigidbody2D>().velocity = new Vector2(GameObject.Find("Konstantine").transform.position.x - gunTip.transform.position.x, GameObject.Find("Konstantine").transform.position.y - gunTip.transform.position.y - 5f).normalized * 50;
                }
                if(num4 == 0)
                {
                    GameObject m4 = (GameObject)Instantiate(enemyMissile, gunTip.transform.position, Quaternion.Euler(0, 0, 0));
                    m4.GetComponent<Rigidbody2D>().velocity = new Vector2(GameObject.Find("Konstantine").transform.position.x - gunTip.transform.position.x, GameObject.Find("Konstantine").transform.position.y - gunTip.transform.position.y + 10f).normalized * 50;
                }
                if(num5 == 0)
                {
                    GameObject m5 = (GameObject)Instantiate(enemyMissile, gunTip.transform.position, Quaternion.Euler(0, 0, 0));
                    m5.GetComponent<Rigidbody2D>().velocity = new Vector2(GameObject.Find("Konstantine").transform.position.x - gunTip.transform.position.x, GameObject.Find("Konstantine").transform.position.y - gunTip.transform.position.y - 10f).normalized * 50;

                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGroundPound : MonoBehaviour {

    Animation bossAnim;
    public float attackInterval;
    private float nextAttack;
    public float dmg;
    public float delay;
    private IEnumerator coroutine;

    // Use this for initialization
    void Start () {
        bossAnim = GetComponent<Animation>();
        nextAttack = 0;
        coroutine = waitAndAttack();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && Time.time > nextAttack)
        {
            // start bossAnim
            nextAttack = Time.time + attackInterval;
            StartCoroutine(coroutine);
            other.GetComponent<playerHealth>().addDamage(dmg);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Time.time > nextAttack)
        {
            //start bossAnim
            nextAttack = Time.time + attackInterval;
            StartCoroutine(coroutine);
            other.GetComponent<playerHealth>().addDamage(dmg);
        }
    }

    private IEnumerator waitAndAttack()
    {
        yield return new WaitForSeconds(delay);
    }
}

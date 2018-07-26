using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour {

    public float damage;
	public float damageRate;
	public float pushBackForce;
    bool isAttack = false;
    int RandomNumber = 0;
    float nextDamage;
    Animator myAnim;

	void Start ()
	{
        myAnim = GetComponent<Animator>();
        nextDamage = 0f;
 

	}
	

	void Update () 
	{

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RandomNumber = Random.Range(1, 3);
            myAnim.SetInteger("RandomInt", RandomNumber);
            isAttack = true;
            myAnim.SetBool("isAttacking", isAttack);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isAttack = false;
            myAnim.SetBool("isAttacking", isAttack);
        }
    }
    void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag =="Player" && nextDamage < Time.time)
		{
			playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth> ();
			thePlayerHealth.addDamage (damage);
			nextDamage = Time.time + damageRate;
			pushBack (other.transform);
		}
        
     
	}
		
	void pushBack(Transform pushedObject)
	{
        Vector2 pushDirection = new Vector3((pushedObject.parent.transform.localPosition.x - gameObject.transform.localPosition.x), (pushedObject.position.y - transform.position.y),0).normalized;
		pushDirection *= pushBackForce;
		Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D> ();
		pushRB.velocity = pushDirection;
		pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
        pushRB.gameObject.transform.SetPositionAndRotation(new Vector3(pushedObject.parent.transform.localPosition.x - gameObject.transform.localPosition.x, 0, 0), Quaternion.Euler(0, 0, 0));
	}
}

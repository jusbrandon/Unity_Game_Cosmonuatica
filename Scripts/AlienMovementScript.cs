using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovementScript : MonoBehaviour
{


    Animator enemyAnimator;
    public float enemySpeed;

    //facing
    public GameObject enemyGraphic;
    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 1f;
    float nextFlipChance = 0f;




    //attacking
    public float chargeTime;
    float startChargeTime;
    bool charging;
    Rigidbody2D enemyRB;

    // Use this for initialization
    void Awake()
    {

        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        canFlip = true;
        if (other.tag == "Player")
        {
            if (facingRight && other.transform.position.x < transform.position.x)
            {
                flipFacing();
            }
            else if (!facingRight && other.transform.position.x > transform.position.x)
            {
                flipFacing();
            }
            canFlip = false;
            charging = true;
            startChargeTime = Time.time + chargeTime;
        }


    }

    private void OnTriggerStay2D(Collider2D other)
    {
        canFlip = true;
        if (other.tag == "Player")
        {
            if (facingRight && other.transform.position.x < transform.position.x)
            {
                flipFacing();
            }
            else if (!facingRight && other.transform.position.x > transform.position.x)
            {
                flipFacing();
            }
            if (startChargeTime < Time.time)
            {
                if (!facingRight)
                {
                    enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
                }
                else
                {
                    enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);

                }
                charging = true;
                enemyAnimator.SetBool("isCharging", charging);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canFlip = true;
        if (other.tag == "Player")
        {
            canFlip = true;
            charging = false;
            enemyRB.velocity = new Vector2(0f, 0f);
            enemyAnimator.SetBool("isCharging", charging);
        }
    }

    void flipFacing()
    {
        canFlip = true;
        if (!canFlip)
        {
            return;
        }
        float facingX = enemyRB.transform.localScale.x;
        facingX *= -1f;
        enemyRB.transform.localScale = new Vector3(facingX, enemyRB.transform.localScale.y, enemyRB.transform.localScale.z);
        facingRight = !facingRight;
    }
}

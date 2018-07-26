using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    
    //jetpack movement
    float jetNext;
    private float jetRate = 1.5f;
    public float multiplier;
    public float diagnalBoost;
    public float speed = 120000;
    public float bulletSpeed;
    //rocket shoes
    float rocketNext;
    private float rocketRate = 2f;

    //movement variables    
    public float maxSpeed;
    
    //jumping variable
    bool grounded = false;
    bool shooting = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;
    //Gravity Variables
    public float zeroGravMoveForce = 0f;
    private float moveForce = 0f;
    public bool inZeroGravityZone = false;
    private float origGravityScale = 0f;
    public string zeroGravTag = "";
    bool isGlide = false;
    bool isGlideShoot = false;
    private float origLinearDrag = 0f;
    public float zeroGravLinearDrag = 0f;
    private float origAngularDrag = 0f;
    public float zeroGravAngularDrag = 0f;


    public GameObject gun;
    public GameObject shotty;
    public GameObject katana;
    public GameObject gunSpace;

    //Animation variables
    bool isLeftDash = false;
	bool isRightDash = false;
	bool isJump = false;

    Rigidbody2D rb2d;
    public float dashDelay;
    public float dashStart;
    //for shooting
    public Transform gunTip;
    public GameObject bullet;
    private float fireRate = 0.35f;
    float nextFire = 0f;
    public ParticleSystem rocketAnim;
    Animator myAnim;
    public static bool facingRight;
	// Use this for initialization
	void Start ()
    {
        
        RocketHit.weaponDamage = 10;
        gun.SetActive(true);
        rb2d = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;

        //gravity script
        origGravityScale = rb2d.gravityScale;
        origLinearDrag = rb2d.drag;
        origAngularDrag = rb2d.angularDrag;

	}

    void Update()
    {
        ////////Gravity Script /////////////////
        moveForce = inZeroGravityZone ? zeroGravMoveForce : maxSpeed;
        rb2d.gravityScale = inZeroGravityZone ? 0f : origGravityScale;
        rb2d.drag = inZeroGravityZone ? zeroGravLinearDrag : origLinearDrag;
        rb2d.angularDrag = inZeroGravityZone ? zeroGravAngularDrag : origAngularDrag;

        if (Input.GetButton("Jump") && !inZeroGravityZone && grounded )
        {
            rb2d.AddForce(Vector2.up * jumpHeight);

        }
        /////////////////////////////////////////
		isJump = false;
		myAnim.SetBool ("isJump", isJump);
        //rocketAnim.IsAlive(false);
        if (grounded && Input.GetAxis("Jump")>0 )
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
			isJump = true;
			myAnim.SetBool ("isJump", isJump);
            rb2d.velocity = (new Vector2(0, jumpHeight));
        }

        // player shooting
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            shooting = true;
            //myAnim.SetBool("isShooting", shooting);
            isGlideShoot = true;
           //myAnim.SetBool("isGlideShoot", isGlideShoot);
          
            fireRocket();

        }
        else if (Input.GetAxisRaw("Jump")>0)
        {
            useJetpack();
        }

        else
        {
            isGlideShoot = false;
            myAnim.SetBool("isGlideShoot", isGlideShoot);
            shooting = false;
            //myAnim.SetBool("isShooting", shooting);
        }

        //switch weapons
        if (Input.GetKeyDown("1") || Input.GetKeyDown("2") || Input.GetKeyDown("3"))
        {
            myAnim.SetInteger("isSwitch", 1);

        }
        else
        {
            myAnim.SetInteger("isSwitch", 0);
        }
        if (Input.GetKeyDown("1"))
        {
            //myAnim.SetInteger("isSwitch", 1);
            gun.SetActive(true);
            shotty.SetActive(false);
            katana.SetActive(false);
            if (SceneManager.GetActiveScene().name == "Stage1")
            {
                bulletSpeed = 15;
            }
            else
            {
                bulletSpeed = 40;
            }


            RocketHit.weaponDamage = 10;
        }
        else if (Input.GetKeyDown("2"))
        {
            
            shotty.SetActive(true);
            gun.SetActive(false);
            katana.SetActive(false);
            if (SceneManager.GetActiveScene().name == "Stage1")
            {
                bulletSpeed = 8;
            }
            else
            {
                bulletSpeed = 25;
            }
            RocketHit.weaponDamage = 20;

        }
        else if (Input.GetKeyDown("3"))
        {
            
            shotty.SetActive(false);
            gun.SetActive(false);
            katana.SetActive(true);

        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //check if we are grounded if no then we are falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
		//Reset Anim parameters------------------------------
		isRightDash = false;
		myAnim.SetBool ("isRightDash", isRightDash);
		isLeftDash = false;
		myAnim.SetBool ("isLeftDash", isLeftDash);
		//----------------------------------------------------

	
        myAnim.SetFloat("verticalSpeed", rb2d.velocity.y);

        float move = Input.GetAxis("Horizontal");

        myAnim.SetFloat("speed", Mathf.Abs(move));

        rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);

        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }
        //player rocketing
        if (Input.GetButtonDown("Rocket Left"))
        {
			
            dashStart = Time.time;
           // myAnim.SetTrigger("isLeftDash");
            useRocketShoesLeft();
            
        }
        if (Input.GetButtonDown("Rocket Right"))
        {

            dashStart = Time.time;
           // myAnim.SetTrigger("isLeftDash");
            useRocketShoesRight();
        }

        //Gravity
        float h = Input.GetAxisRaw("Horizontal") * moveForce;
        float v = inZeroGravityZone ? Input.GetAxisRaw("Vertical") * moveForce : 0f;
        rb2d.AddForce(new Vector2(h, v));
        //Cheats
        /*if (Input.GetButtonDown("CheatLeft"))
        {
            dashStart = Time.time;
            CheatBoostLeft();
        }
        if (Input.GetButtonDown("CheatRight"))
        {
            dashStart = Time.time;
            CheatBoostRight();
        }*/
    }
  
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    void fireRocket()
    {
        if(katana.activeInHierarchy == false)
        {
            var input = (Input.mousePosition);
            var screenPositionInput = Camera.main.ScreenToWorldPoint(new Vector3(input.x, input.y, -Camera.main.transform.position.z));
            /*var gun = GetComponent<PlayerController>().gunTip.transform.position;
            var screenPositionGun = Camera.main.ScreenToWorldPoint(new Vector3(gun.x, gun.y, -Camera.main.transform.position.z));
            Vector2 direction = new Vector2(screenPositionInput.x - screenPositionGun.x, screenPositionInput.y - screenPositionGun.y).normalized;
            myRB.velocity = (direction * rocketSpeed);*/
            //myRB.position = new Vector3(screenPositionInput.x, screenPositionInput.y, -Camera.main.transform.position.z);
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                if (facingRight)
                {
                    if (screenPositionInput.x > rb2d.position.x)
                    {
                        GameObject missile = (GameObject)(Instantiate(bullet, new Vector3(gunTip.transform.position.x, gunTip.transform.position.y, 0), Quaternion.Euler(0, 0, 0)));
                        missile.GetComponent<Rigidbody2D>().velocity = new Vector3(screenPositionInput.x - gunTip.position.x, screenPositionInput.y - gunTip.position.y, 0).normalized * bulletSpeed;
                        //Instantiate(gun, new Vector3(gunSpace.transform.position.x, gunSpace.transform.position.y, 0), Quaternion.Euler(0, 0, 0));
                    }
                }
                else if (!facingRight)
                {
                    if (screenPositionInput.x < rb2d.position.x)
                    {
                        GameObject missile = (GameObject)(Instantiate(bullet, new Vector3(gunTip.transform.position.x, gunTip.transform.position.y, 0), Quaternion.Euler(0, 0, 0)));
                        missile.GetComponent<Rigidbody2D>().velocity = new Vector3(screenPositionInput.x - gunTip.position.x, screenPositionInput.y - gunTip.position.y, 0).normalized * bulletSpeed;
                        //Instantiate(gun, new Vector3(gunSpace.transform.position.x, gunSpace.transform.position.y, 0), Quaternion.Euler(0, 180, 0));
                    }
                }
            }
        }
    }

    void useJetpack()
    {
        if(Time.time > jetNext && grounded == false)
        {
            myAnim.SetTrigger("GlideJump");
            jetNext = Time.time + jetRate;
            rb2d.velocity = (new Vector2(0f, multiplier));
            //
        }            
    }

    void useRocketShoesLeft()
    {
        if(Time.time > rocketNext)
        {
            isLeftDash = true;
            myAnim.SetBool("isLeftDash", isLeftDash);
            rocketNext = Time.time + rocketRate;
                
            rb2d.velocity = new Vector2(-1f * diagnalBoost,1f);
                
                
            Instantiate(rocketAnim, new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 0), Quaternion.Euler(0, 0, 0));
            
        }
    }

    void useRocketShoesRight()
    {
        if (Time.time > rocketNext)
        {
            isRightDash = true;
            myAnim.SetBool("isRightDash", isRightDash);
            rocketNext = Time.time + rocketRate;

            rb2d.velocity = new Vector2(1f * diagnalBoost,1f);
            Instantiate(rocketAnim, new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 0), Quaternion.Euler(0, 0, 0));
            
        }
    }

  //GravityZone Scripts ////////////////////////////////
   void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == zeroGravTag)
        {
            isGlide = true;
            myAnim.SetBool("isGlide", isGlide);
            inZeroGravityZone = true;
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == zeroGravTag)
        {
            isGlide = true;
            myAnim.SetBool("isGlide", isGlide);
            inZeroGravityZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == zeroGravTag)
        {
            isGlide = false;
            myAnim.SetBool("isGlide", isGlide);
            inZeroGravityZone = false;
        }
    }
    //////////////////////////////////////
    //Cheats
    /*void CheatBoostLeft()
    {
      
     
            isLeftDash = true;
            myAnim.SetBool("isLeftDash", isLeftDash);
           

            rb2d.velocity = new Vector2(-1f * diagnalBoost, 1f);


            Instantiate(rocketAnim, new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 0), Quaternion.Euler(0, 0, 0));

       
    }

    void CheatBoostRight()
    {
       
            isRightDash = true;
            myAnim.SetBool("isRightDash", isRightDash);
        

            rb2d.velocity = new Vector2(1f * diagnalBoost, 1f);
            Instantiate(rocketAnim, new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 0), Quaternion.Euler(0, 0, 0));

        
    }*/
}

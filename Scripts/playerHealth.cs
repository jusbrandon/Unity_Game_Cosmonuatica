using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{

    public float fullHealth;
    public GameObject deathFX;
    float currentHealth;
    public AudioClip playerHurt;
    public Text gameOverScreen;
   
    PlayerController controlMovement;

    public restartGame theGameManager;

    Animator myAnim;
    bool isHurt = false;

    //AudioSource playerAS;


    
    //HUD Varibles
    public Slider healthSlider;
    public Image damageScreen;
    public Text winGameScreen;
  
  

    bool damaged = false;
    Color damagedColour = new Color(1f, 0f, 0f, 1f);
    float smoothColour = 2f;
	void Start ()
    {
        currentHealth = fullHealth;

        controlMovement = GetComponent<PlayerController>();
        
        //HUD initizilation 
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;

        //playerAS = GetComponent<AudioSource>();
        myAnim = GetComponent<Animator>();

    }


    void Update()
    {
        if (damaged)
        {
            isHurt = true;
            myAnim.SetBool("isHurt", isHurt);
            damageScreen.color = damagedColour;

        }
        else
        {
            isHurt = false;
            myAnim.SetBool("isHurt", isHurt);
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColour * Time.deltaTime);
        }
        damaged = false;

    }
   public void addDamage(float damage)
   {
 
        
        if (damage <= 0)
        {
            return;
        }

         
            currentHealth -= damage;
         
            //playerAS.clip = playerHurt;
            //playerAS.Play();
            //playerAS.PlayOneShot(playerHurt);

            healthSlider.value = currentHealth;
            damaged = true;
        
        if (currentHealth<=0)
        {
            makeDead();
        }
    }

    public void makeDead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);

        Animator gameOverAnimator = gameOverScreen.GetComponent<Animator>();
        gameOverAnimator.SetTrigger("gameOver");
        GameOverMenu.dead = 1;
        theGameManager.restartTheGame();
    }

    public void winGame()
    {
        //Destroy(gameObject);
        //theGameManager.restartTheGame();
        

    }
}

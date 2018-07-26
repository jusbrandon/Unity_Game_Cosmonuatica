using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float enemyMaxHealth;
    float currentHealth;
    public GameObject enemyDeathFX;
    public Slider enemySlider;
    
    //audio
    public AudioClip enemyHurt;
    public AudioClip enemyDeath;
    private AudioSource enemyAS;

    void Start()
    {
        enemyAS = GetComponent<AudioSource>();
        currentHealth = enemyMaxHealth;
        enemySlider.maxValue = currentHealth;
        enemySlider.value = currentHealth;
        
    }


	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void addDamage(float damage)
    {
        enemySlider.gameObject.SetActive(true);
        currentHealth -= damage;
        enemySlider.value = currentHealth;


        if(Random.Range(0, 10) >= 7)
        {
            enemyAS.clip = enemyHurt;
            enemyAS.Play();
        }
        
       /* if(currentHealth <= 15)
        {
            enemyAS.clip = enemyDeath;
            enemyAS.Play();
        }*/

        if (currentHealth <= 0)
        {

            makeDead();
            
        }
    }

    void makeDead()
    {
        Destroy(gameObject);
        //Instantiate(enemyDeathFX, transform.position, transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenWalls : MonoBehaviour {

    public float WallMaxHealth;
    float currentHealth;
    public GameObject WallDeathFX;
    public Slider WallSlider;
   
    
 
    

    void Start()
    {
        
        currentHealth = WallMaxHealth;
        WallSlider.maxValue = currentHealth;
        WallSlider.value = currentHealth;

    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage)
    {
        WallSlider.gameObject.SetActive(true);
        currentHealth -= damage;
        WallSlider.value = currentHealth;





        if (currentHealth <= 0)
        {
            RevealHiddenFloor.isHidden = 1;
            makeDead();
        }
    }

    void makeDead()
    {
        Destroy(gameObject);
        Instantiate(WallDeathFX, transform.position, transform.rotation);
    }
}


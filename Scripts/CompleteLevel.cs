using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CompleteLevel : MonoBehaviour {


    //audio
    private AudioClip endingSound;
    public AudioSource endingSource;
    public Text winText;

	// Use this for initialization
	void Start () {
        endingSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //endingSound = endingSource.clip;
            //endingSource.Play();

            //playerHealth playerWins = other.gameObject.GetComponent<playerHealth>();
            //Animator winGameAnimator = winText.GetComponent<Animator>();
            //winGameAnimator.SetTrigger("isWin");
            //playerWins.winGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
 
}

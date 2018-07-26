using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{
    public GameObject GameOverUI;
    private bool GameOver = false;
    public static int dead = 0;
	// Use this for initialization
	void Start ()
    {
        GameOverUI.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (dead == 1)
        {

            GameOverUI.SetActive(true);
            Time.timeScale = 0;
       
        }
 

	}
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        dead = 0;
    }
    public void Quit()
    {
        Application.Quit();

    }
}

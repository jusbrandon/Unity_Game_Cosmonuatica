using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartGame : MonoBehaviour
{
    public float restartTime;
    bool restartNow = false;
    float resetTime;

	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		if(restartNow && resetTime <= Time.time)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
	}
    public void restartTheGame()
    {
        restartNow = true;
        resetTime = Time.time + restartTime;
    }
}

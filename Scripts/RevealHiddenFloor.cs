using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealHiddenFloor : MonoBehaviour
{
    public GameObject RevealFloor;
    public static int isHidden;
	// Use this for initialization
	void Start ()
    {
        RevealFloor.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(isHidden == 1)
        {
            RevealFloor.SetActive(true);
        }
        if (isHidden != 1)
        {
            RevealFloor.SetActive(false);
        }
	}
}

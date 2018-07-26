using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{

    public Camera camera;

    Vector3 mousePos;
    Vector3 screenPos;
    Vector2 dir;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - camera.transform.position.z));


        //transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        if(PlayerController.facingRight == true)
        {
            transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePos.y - transform.position.y), (mousePos.x - transform.position.x)) * Mathf.Rad2Deg);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePos.y - transform.position.y), (mousePos.x - transform.position.x)) * Mathf.Rad2Deg - 180);
        }
        
    }
}

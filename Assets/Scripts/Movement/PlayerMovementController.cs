using Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    //public PlayerView ViewPrefub;
    public float moveSpeed;

    

    void TouchMove()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.x > 1)
            {
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            }

            else if (mousePos.x < -1)
            {
                transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            }
        }      
    }

    void Update()
    {
        TouchMove();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject player;
    
    double halfScreen = Screen.width / 2.0;

    private void ReadInput()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            
            if (touchPosition.x < halfScreen)
            {
                MoveLeft();
            }
            else if (touchPosition.x > halfScreen)
            {
                MoveRight();               
            }
        }
        
         
    }

    void FixedUpdate()
    {
        MoveLeft();
        MoveRight();
    }

    private void MoveLeft()
    { 
        player.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
    private void MoveRight()
    {
        player.transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void Update()
    {
        ReadInput();
    }
}

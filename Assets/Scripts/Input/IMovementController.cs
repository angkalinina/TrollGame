using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System;

namespace InputSystem
{
    public class IMovementController : MonoBehaviour
    {
        private GameObject player;

        void Start()
        {
            
            

            if (transform.root.GetComponent<Canvas>() != null)
            {
                transform.root.GetComponent<Canvas>();
            }
            else if (transform.root.GetComponentInChildren<Canvas>() != null)
            {
                transform.root.GetComponentInChildren<Canvas>();
            }
            else
            {
                Debug.LogError("Required at lest one canvas");
                this.enabled = false;
                return;
            }

            
        }

        void Update()
        {
           if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                    Vector2 touchPosition = Input.GetTouch(0).position;
                    double halfScreen = Screen.width / 2.0;
                    
                    if (touchPosition.x < halfScreen)
                    {
                        player.transform.Translate(Vector3.left * 5 * Time.deltaTime);
                    }
                    else if (touchPosition.x > halfScreen)
                    {
                        player.transform.Translate(Vector3.right * 5 * Time.deltaTime);
                    }
                }
        }
    }
}

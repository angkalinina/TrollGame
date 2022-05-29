using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System;

namespace InputSystem
{
    public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [Header("Settings of JK")]
        public float Radio; //the ratio of the circumference of the joystick
        public float SmoothTime;

        [Header("Transforms of JK")]
        public RectTransform StickRect; //The middle joystick UI
        public RectTransform BGReference;

        private Vector3 JoystickArea;
        private Vector3 currentVelocity;
        private bool isFree = false;
        private int lastId = -2;

        private Canvas JK_Canvas;

        private float smoothTime { get { return 1 - SmoothTime; } }

        public float Horizontal
        {
            get
            {
                return (StickRect.position.x - JoystickArea.x) / Radio;
            }
        }

        public float Vertical
        {
            get
            {
                return (StickRect.position.y - JoystickArea.y) / Radio;
            }
        }

        void Start()
        {
            if (transform.root.GetComponent<Canvas>() != null)
            {
                JK_Canvas = transform.root.GetComponent<Canvas>();
            }
            else if (transform.root.GetComponentInChildren<Canvas>() != null)
            {
                JK_Canvas = transform.root.GetComponentInChildren<Canvas>();
            }
            else
            {
                Debug.LogError("Required at lest one canvas for joystick work.!");
                this.enabled = false;
                return;
            }

        }


        void Update()
        {
            JoystickArea = BGReference.position;

            if (!isFree)
                return;

            StickRect.position = Vector3.SmoothDamp(StickRect.position, JoystickArea, ref currentVelocity, smoothTime);

            if (Vector3.Distance(StickRect.position, JoystickArea) < .1f)
            {
                isFree = false;
                StickRect.position = JoystickArea;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {

            if (eventData.pointerId == lastId)
            {
                isFree = false;
                Vector3 position = JoystickUtility.TouchPosition(JK_Canvas, GetTouchID);

                if (Vector2.Distance(JoystickArea, position) < Radio)
                {
                    StickRect.position = position;
                }
                else
                {
                    StickRect.position = JoystickArea + (position - JoystickArea).normalized * Radio;
                }
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (lastId == -2)
            {
                lastId = eventData.pointerId;
                OnDrag(eventData);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isFree = true;
            currentVelocity = Vector3.zero;

            if (eventData.pointerId == lastId)
            {
                lastId = -2;
            }

        }

        public int GetTouchID
        {
            get
            {

                for (int i = 0; i < Input.touches.Length; i++)
                {
                    if (Input.touches[i].fingerId == lastId)
                    {
                        return i;
                    }
                }
                return -1;
            }
        }
    }
}

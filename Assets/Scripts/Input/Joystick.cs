using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System;


public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [Header("Settings of JK")]
    [Range (0, 5)]
    public float Radio; //the ratio of the circumference of the joystick
    public float SmoothTime; //return to default position speed
    public float OnPressScale; // return to default position speed

    [Header("Color of JK")]
    public Color UnpressedColor; //set color of unpressed 
    public Color PressColor;
    public float Duration = 1;

    [Header("Transforms of JK")]
    public RectTransform StickRect; //The middle joystick UI
    public RectTransform BGReference;
    private Image stickImage;
    private Image BGImage;

    private Vector3 DeathArea;
    private Vector3 currentVelocity;
    private bool isFree = false;
    private int lastId = -2;

    private Canvas m_Canvas;
    private float difference;
    private Vector3 PressScaleVector;

    void Start()
    {
       

        if (transform.root.GetComponent<Canvas>() != null)
        {
            m_Canvas = transform.root.GetComponent<Canvas>();
        }
        else if (transform.root.GetComponentInChildren<Canvas>() != null)
        {
            m_Canvas = transform.root.GetComponentInChildren<Canvas>();
        }
        else
        {
            Debug.LogError("Required at lest one canvas for joystick work.!");
            this.enabled = false;
            return;
        }

        //Get the default area of joystick
        DeathArea = BGReference.position;
        difference = BGReference.position.magnitude;
        PressScaleVector = new Vector3(OnPressScale, OnPressScale, OnPressScale);
        
        if (GetComponent<Image>() != null)
        {
            BGImage = GetComponent<Image>();
            stickImage = StickRect.GetComponent<Image>();
            BGImage.CrossFadeColor(UnpressedColor, Duration, true, true);
            stickImage.CrossFadeColor(UnpressedColor, Duration, true, true);
        }
    }

    
    void Update()
    {
        DeathArea = BGReference.position;
        //If this not free (not touched) then not need continue
        if (!isFree)
            return;

        //Return to default position with a smooth movement
        StickRect.position = Vector3.SmoothDamp(StickRect.position, DeathArea, ref currentVelocity, smoothTime);

        //When is in default position, we not need continue update this
        if (Vector3.Distance(StickRect.position, DeathArea) < .1f)
        {
            isFree = false;
            StickRect.position = DeathArea;
        }
    }



    public void OnDrag(PointerEventData eventData)
    {
        //If this touch id is the first touch in the event
        if (eventData.pointerId == lastId)
        {
            isFree = false;

            //Get Position of current touch
            Vector3 position = JoystickUtility.TouchPosition(m_Canvas, GetTouchID);

            //Rotate into the area circumferential of joystick
            if (Vector2.Distance(DeathArea, position) < Radio)
            {
               StickRect.position = position;
            }
           else
            {
                StickRect.position = DeathArea + (position - DeathArea).normalized * Radio;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Detect if is the default touchID

        if (lastId == -2)
        {
            //then get the current id of the current touch.
            //this for avoid that other touch can take effect in the drag position event.
            //we only need get the position of this touch
            
            lastId = eventData.pointerId;
            //StopAllCoroutines();
            //StartCoroutine(ScaleJoysctick(true));
            OnDrag(eventData);
            if (BGImage != null)
            {
                BGImage.CrossFadeColor(PressColor, Duration, true, true);
                stickImage.CrossFadeColor(PressColor, Duration, true, true);
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isFree = true;
        currentVelocity = Vector3.zero;
        //leave the default id again
        if (eventData.pointerId == lastId)
        {
            //-2 due -1 is the first touch id
            lastId = -2;
            //StopAllCoroutines();
            //StartCoroutine(ScaleJoysctick(false));
            if (BGImage != null)
            {
                BGImage.CrossFadeColor(UnpressedColor, Duration, true, true);
                stickImage.CrossFadeColor(UnpressedColor, Duration, true, true);
            }
        }

    }

    //IEnumerator ScaleJoysctick(bool increase)
    //{
    //    float _time = 0;

      //  while (_time < Duration)
       // {
      //      Vector3 v = StickRect.localScale;
       //     if (increase)
        //    {
        //        v = Vector3.Lerp(StickRect.localScale, PressScaleVector, (_time / Duration));
         //   }
         //   else
         //   {
         //       v = Vector3.Lerp(StickRect.localScale, Vector3.one, (_time / Duration));
         //   }
         //   StickRect.localScale = v;
         //   _time += Time.deltaTime;
         //   yield return null;
       // }
   // }

    public int GetTouchID
    {
        get
        {
            //find in all touches
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

    private float radio { get { return (Radio * 5 + Mathf.Abs((difference - BGReference.position.magnitude))); } }
    private float smoothTime { get { return (1 - (SmoothTime)); } }

    
    /// Value Horizontal of the Joystick
    /// Get this for get the horizontal value of joystick
    
    public float Horizontal
    {
        get
        {
            return (StickRect.position.x - DeathArea.x) / Radio;
        }
    }

  
    /// Value Vertical of the Joystick
    /// Get this for get the vertical value of joystick

    public float Vertical
    {
        get
        {
            return (StickRect.position.y - DeathArea.y) / Radio;
        }
    }
}

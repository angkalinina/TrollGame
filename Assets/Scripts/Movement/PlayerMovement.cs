using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _moveSpeed;

    private Animator animator;
    private string currentAnimaton;

    private bool isAttackPressed;
    private bool isAttacking;

    const string Player_IDLE = "Player_idle";
    const string Player_WALKING_RIGHT = "Player_walking_right";
    const string Player_WALKING_LEFT = "Player_walking_left";
    const string Player_RUNNING = "Player_running";
    const string Player_AIMING = "Player_AIMING";
    const string Player_ATTACK = "Player_attack";


    const string Player_TALKING = "Player_talking";
    const string Player_THINKING = "Player_thinking";
    const string Player_TRIUMPHANT = "Player_triumphant";
    const string Player_GRIEVING = "Player_grieving";
    const string Player_MAD = "Player_mad";



    [Header("Borders")]
    public float BorderMinX; //minimum border for x
    public float BorderMaxX; //maximum border for x
    public float BorderMinY; //minimum border for y
    public float BorderMaxY; //maximum border for y

    [SerializeField] private float padding;

    void Start()
    {
        moveBorders();
        animator = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _joystick.Horizontal * _moveSpeed, 0);
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.y, _joystick.Vertical * _moveSpeed, 0);
        Move();

        //if (isAttackPressed)
        //{
        //isAttackPressed = false;
        //if (!isAttacking)
        //{
        //ChangeAnimationState(Player_ATTACK);
        //}
         
            //private void Update()
            //{
            // if
            //{
            //isAttackPressed = true;
            //}
            }

            private void Move()

            {

                var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * _moveSpeed;

                var newPosX = Mathf.Clamp(transform.position.x + deltaX, BorderMinX, BorderMaxX);

                var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * _moveSpeed;

                var newPosY = Mathf.Clamp(transform.position.y + deltaY, BorderMinY, BorderMaxY);

                transform.position = new Vector2(newPosX, newPosY);
            }

            void ChangeAnimationState(string newAnimation)
            {
                if (currentAnimaton == newAnimation) return;

                animator.Play(newAnimation);
                currentAnimaton = newAnimation;
            }

            private void moveBorders()

            {

                Camera gameCamera = Camera.main;

                BorderMinX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;

                BorderMaxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

                BorderMinY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;

                BorderMaxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

            }

        }
    



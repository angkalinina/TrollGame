using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _moveSpeed;


    [Header("Borders")]
    public float BorderMinX; //minimum border for x
    public float BorderMaxX; //maximum border for x
    public float BorderMinY; //minimum border for y
    public float BorderMaxY; //maximum border for y

    [SerializeField] private float padding;

    private void Start()
    {
        moveBorders();

    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _joystick.Horizontal * _moveSpeed, 0);
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.y, _joystick.Vertical * _moveSpeed, 0);
        Move();

    }

    private void Move()

    {

        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * _moveSpeed;

        var newPosX = Mathf.Clamp(transform.position.x + deltaX, BorderMinX, BorderMaxX);

        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * _moveSpeed;

        var newPosY = Mathf.Clamp(transform.position.y + deltaY, BorderMinY, BorderMaxY);

        transform.position = new Vector2(newPosX, newPosY);



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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Character Value
    [Header("Character Value")]
    public float speed = 12f;
    //public float gravity = -9.18f;
    //public float jumpHeight = 3f;
    #endregion
    //public Transform groundCheck;
    //public float groundDistance = 0.4f;
    //public LayerMask groundMask;
    #region Player Controller
    private CharacterController _controller;
    #endregion
    #region Joystick Value
    [Header("Character Joystick")]
    public FixedJoystick joystick;
    private float _joystickXPos;
    private float _joystickYPos;
    #endregion
    Vector3 velocity;
    bool isGrounded;
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance,groundMask);

        //if (isGrounded && velocity.y<0)
        //{
        //    velocity.y = -2f;
        //}
        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");
        SetCharacterControlData();
        Move();

        //if (Input.GetButtonDown("Jump") && isGrounded)
        //{
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        //}

        //velocity.y += gravity * Time.deltaTime;

        //_controller.Move(velocity * Time.deltaTime);
    }
    private void SetCharacterControlData()
    {
        _joystickXPos = joystick.Horizontal;
        _joystickYPos = joystick.Vertical;
    }
    private void Move()
    {
        Vector3 move = transform.right * _joystickXPos + transform.forward * _joystickYPos;
        _controller.Move(move * speed * Time.deltaTime);
    }
}

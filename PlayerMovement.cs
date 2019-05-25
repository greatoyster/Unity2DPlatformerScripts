using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 400f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public float leftBound = -1f;
    public float rightBound = 1f;
 
    // Update is called once per frame
    void Update()
    {
        horizontalMove= Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump")) 
        {
            jump = true;
        }
        if (Input.GetButtonDown("Crouch")) 
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }



    }
    void FixedUpdate()
    {
        if ((transform.position.x < rightBound) && (transform.position.x > leftBound))
        {
            controller.Move(horizontalMove * runSpeed * Time.deltaTime, false, jump);
        }
        else if ((transform.position.x >= rightBound) && (horizontalMove < 0))
        {
            controller.Move(horizontalMove * runSpeed * Time.deltaTime, false, jump);
        }
        else if ((transform.position.x <= leftBound) && (horizontalMove > 0))
        {
            controller.Move(horizontalMove * runSpeed * Time.deltaTime, false, jump);
        }
        else
        {
            controller.Move(0f, false, jump);
        }
        jump = false;

    }
}

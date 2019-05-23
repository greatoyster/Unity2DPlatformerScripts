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
        controller.Move(horizontalMove *runSpeed* Time.deltaTime, false, jump);
        jump = false;

    }
}

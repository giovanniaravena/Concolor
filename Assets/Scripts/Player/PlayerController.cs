using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        //agacharse
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump); //move, crouch, jump
        if (horizontalMove==0) 
            animator.SetTrigger("PumaWait_Anim");
        else
            animator.SetTrigger("PumaRun_Anim");
        jump = false;
    }

   
}

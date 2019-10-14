using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator; 

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    //private enum AnimationState{Run,Jump,Crouch,Wait};
   // AnimationState animState;
    

    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move(){
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Puma_Speed_Anim", Mathf.Abs(horizontalMove));

        //if (Input.GetKeyDown(KeyCode.UpArrow))
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;            
            animator.SetBool("Puma_IsJumping_Anim",true);
            Debug.Log("salta");
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
    public void OnLanding(){
        animator.SetBool("Puma_IsJumping_Anim",false); 
        Debug.Log("toca suelo y para de saltar");
        //jump = false;
    }
    public void OnCrouching(bool isCrouching){
        animator.SetBool("Puma_IsCrouching_Anim", isCrouching);
        Debug.Log("Agazapado: "+isCrouching);
    }

   
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump); //move, crouch, jump
        jump = false;
        //Debug.Log("controller.Move: "+);
        
        //if(crouch)
        //    animator.SetTrigger("PumaCrouch_Anim");
        //else if(jump)
        //    animator.SetTrigger("PumaJump_Anim");
   //     if (horizontalMove==0) 
 //           animator.SetTrigger("PumaWait_Anim");
  //      else
    //        animator.SetTrigger("PumaRun_Anim");

        /*
        switch (animState)
        {
            case AnimationState.Run: 
            brake;

            default:
        }
        */
    }

     

   
}

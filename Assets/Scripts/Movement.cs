using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public  CharacterController2D controller ;
    public Animator animator;
    public float runS = 20f;
    float h_move = 0f;
    bool jump = false;

    void Update()
    {
        h_move = Input.GetAxisRaw("Horizontal") * runS;
        animator.SetFloat("Speed", Mathf.Abs(h_move));

        if(Input.GetButtonDown("Jump"))
        {
            animator.SetBool("Is_Jump",true);
            jump = true;
        }

    }
    void FixedUpdate ()
    {
        controller.Move(h_move * Time.fixedDeltaTime, jump);
        jump = false;
    }
    public void ToLand()
    {
        animator.SetBool("Is_Jump", false);
    }
}

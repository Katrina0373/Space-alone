using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public  CharacterController2D controller ;
    public float runS = 20f;
    float h_move = 0f;
    bool jump = false;

    void Update()
    {
        h_move = Input.GetAxisRaw("Horizontal") * runS;

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        //if (controller.isLadder) controller.LadderMode(h_move);
    }
    void FixedUpdate ()
    {
        controller.Move(h_move * Time.fixedDeltaTime, jump);
        jump = false;
    }
}

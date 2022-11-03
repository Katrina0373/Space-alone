using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public  CharacterController2D controller ;
    public float runS = 20f;
    float h_move = 0f;
    bool jump = false;


    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        h_move = Input.GetAxisRaw("Horizontal") * runS;

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }
    void FixedUpdate ()
    {
        controller.Move(h_move * Time.fixedDeltaTime, jump);
        jump = false;
    }
}

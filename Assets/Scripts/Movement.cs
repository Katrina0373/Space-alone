using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public  CharacterController2D controller ;
    public Animator animator;
    public float runS = 20f;
    [SerializeField] public static float MaxEnergy = 100;
    public float Energy = MaxEnergy;
    public string Vinyl_n = "a";
    float h_move = 0f;
    bool jump = false;
    bool Dash = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Vinyl")
        {
            Vinyl_n = collision.gameObject.name;
        }
    }
    void Update()
    {
        h_move = Input.GetAxisRaw("Horizontal") * runS;
        animator.SetFloat("Speed", Mathf.Abs(h_move));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Is_Jump", true);
        }
        if (Input.GetButtonDown("Dash") && Vinyl_n == "Dash" &&  Energy >= 10)
        {
            Dash = true;
            Energy = Energy - 10;
        }
    }
    void FixedUpdate ()
    {
        controller.Move(h_move * Time.fixedDeltaTime, jump, Dash);
        jump = false;
        Dash = false;
    }
    public void Landing()
    {
        animator.SetBool("Is_Jump", false);
    }
    /*
     *  void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Vinyl")
        {
            Taken = true;
        }
    }
    if(Vinyl_n != Vinyl_nt)
        {
            Vinyl_nt = Vinyl_n;
        }
     */
    //GetComponent<Vinyl>().Vinyl_cart = collision.gameObject.name;
}

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
    public bool Dash = false;
    [SerializeField] EnergyBar bar;
    

    private void Start()
    {
        bar.SetMaxEnergy(MaxEnergy);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Vinyl")
        {
            Vinyl_n = collision.gameObject.name;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Charger")
        {
            Energy = MaxEnergy;
            bar.setEnergy(Energy);
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
        if (Input.GetButtonDown("Dash") && Vinyl_n == "Dash" && Energy >= 10)
        {
            Dash = true;
            Energy = controller.energy(Energy);
            bar.setEnergy(Energy);
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
    
}

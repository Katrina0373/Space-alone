using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runS = 20f;
    [SerializeField] public static float MaxEnergy = 100;
    public float Energy = MaxEnergy;
    public string Vinyl_n = "a";
    float h_move = 0f;
    bool jump = false;
    //[SerializeField] AudioSource runningSound;
    [SerializeField] EnergyBar bar;


    private void Start()
    {
        bar.SetMaxEnergy(MaxEnergy);
        if (Physics2D.gravity.y > 0)
            Physics2D.gravity = new Vector2(0, -9.81f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Vinyl")
        {
            Vinyl_n = collision.gameObject.name;
            JustInt mob = collision.gameObject.GetComponent<JustInt>();
            controller.energyForDush = mob.EnergyCost;
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

        /*if (Mathf.Abs(h_move) > 0f && controller.m_Grounded)
        {
            if (!runningSound.isPlaying)
                runningSound.Play();
        }
        else runningSound.Stop();*/

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Is_Jump", true);
        }
        if (Input.GetButtonDown("Dash") && Energy >= controller.energyForDush && Vinyl_n != "a")
        {
            Energy = controller.energy(Energy, Vinyl_n);
            bar.setEnergy(Energy);
            controller.UsAb = true;
        }

    }
    void FixedUpdate()
    {
        controller.Move(h_move * Time.fixedDeltaTime, jump, Vinyl_n); ;
        jump = false;
    }
    public void Landing()
    {
        animator.SetBool("Is_Jump", false);
    }
}
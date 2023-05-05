using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 4000f;// —ила прыжка 
    [SerializeField] private float Dash_force = 30000f; 
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;   // ѕлавность движени€
    [SerializeField] private LayerMask m_WhatIsGround;                          // маска определ€юща€ то что €вл€етс€ проходимой поверхностью
    [SerializeField] private Transform m_GroundCheck;                           // сохран€ет информацию о том соприкосаетс€ ли персонаж с поверхностью или находитс€ в воздух
    [SerializeField] private Transform m_HeadCheck;
    [SerializeField] private Transform cont;
    [SerializeField] private bool Up = false;
    [SerializeField] private float speedLadder = 5f;
    public int energyForDush;
    const float k_GroundedRadius = .2f; 
    public bool m_Grounded;
    public bool cooldown = true;
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // определить сторону в которую смотрит персонаж
    private Vector3 m_Velocity = Vector3.zero;
    public bool UsAb = false;
    bool is_Climbing = false;
    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;
    public static CharacterController2D Instance { get; set; } // синглтон, чтобы обращатьс€ к пол€м и методам класса, не создава€ его экземпл€р

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }


    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    private void FixedUpdate()
    {
        if(is_Climbing) 
        {
            if (Input.GetAxisRaw("Vertical") == 1)
            {
                m_Rigidbody2D.gravityScale = 0;
                m_Rigidbody2D.MovePosition(m_Rigidbody2D.position + new Vector2(0f, 1f) * speedLadder * Time.deltaTime);
            }
            else if(Input.GetAxisRaw("Vertical") == -1)
            {
                m_Rigidbody2D.gravityScale = 0;
                m_Rigidbody2D.MovePosition(m_Rigidbody2D.position - new Vector2(0f, 1f) * speedLadder * Time.deltaTime);
            }
        }
        else
        {
            if(!Up)
            {
                Physics2D.gravity = new Vector2(0, -9.8f);
            }
            else
            {
                Physics2D.gravity = new Vector2(0, 9.8f);
            }
            bool wasGrounded = m_Grounded;
            m_Grounded = false;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;
                    if (!wasGrounded)
                        OnLandEvent.Invoke();
                }
            }
        }
        
        
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GameController")
        {
            is_Climbing = true;
            m_Rigidbody2D.gravityScale = 0;
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GameController")
        {
            is_Climbing = false;
            m_Rigidbody2D.gravityScale = 3;
        }
    }
    public void Move(float move, bool jump, string Vinyl)
    {



        cooldown = true;
        // определение скорость перемещени€
        Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);

        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        // разворот игрока в сторону перемещени€
        if (move > 0 && !m_FacingRight)
        {

            Flip();
        }

        else if (move < 0 && m_FacingRight)
        {

            Flip();
        }
        // прыжок
        if (m_Grounded && jump && !Up)
        {
            // добавление силы по вертикали
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            
        }
        else if (m_Grounded && jump && Up)
        {
            // добавление силы по вертикали
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, -m_JumpForce));

        }
        if ( cooldown && UsAb)
        {
            switch (Vinyl, m_Grounded)
            {
                case ("Dash", false):
                    {
                        if (m_FacingRight)
                        {
                            m_Rigidbody2D.AddForce(new Vector2(Dash_force, 0f));

                        }
                        else
                        {
                            m_Rigidbody2D.AddForce(new Vector2(-Dash_force, 0f));
                        }
                        cooldown = false;
                        UsAb = false;
                        break;
                    }
                case ("SwitchGravity", true):
                    {
                        if (!Up)
                        {
                            m_FacingRight = !m_FacingRight;
                            transform.eulerAngles = new Vector3(0, 0, 180f);
                            transform.position = new Vector3(transform.position.x, transform.position.y + 3, 0);
                            Up = true;
                            
                           /* cont = m_GroundCheck.transform;
                            m_GroundCheck = m_HeadCheck.transform;
                            m_HeadCheck = cont.transform;
                            m_JumpForce *= -1;*/
                        }
                        else
                        {
                            m_FacingRight = !m_FacingRight;
                            transform.eulerAngles = Vector3.zero;
                            transform.position = new Vector3(transform.position.x, transform.position.y - 3, 0);
                            Up = false;
                            /*Transform x = m_HeadCheck.transform;
                            m_HeadCheck = m_GroundCheck.transform;
                            m_GroundCheck = x.transform;
                            m_JumpForce *= -1;*/
                        }
                        cooldown = false;
                        break;
                    }
                default:
                    break;

            }
            
            UsAb = false;
        }

    }
    public float energy(float e, string Vinyl)
    {
        if (cooldown && Vinyl == "Dash" && !m_Grounded)
        {
            e -= energyForDush;
        }
        else if (cooldown && Vinyl == "SwitchGravity" && m_Grounded)
        {
            e -= energyForDush;
        }
        return e;
    }

    private void Flip()
    {
        // поворот игрока влево,вправо
        m_FacingRight = !m_FacingRight;

     
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    
   
}




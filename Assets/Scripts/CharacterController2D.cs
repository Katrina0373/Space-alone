using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;// —ила прыжка 
    [SerializeField] private float Dash_force = 400f; 
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;   // ѕлавность движени€
    [SerializeField] private LayerMask m_WhatIsGround;                          // маска определ€юща€ то что €вл€етс€ проходимой поверхностью
    [SerializeField] private Transform m_GroundCheck;                           // сохран€ет информацию о том соприкосаетс€ ли персонаж с поверхностью или находитс€ в воздух

    const float k_GroundedRadius = .2f; 
    private bool m_Grounded;            
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // определить сторону в которую смотрит персонаж
    private Vector3 m_Velocity = Vector3.zero;
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

    
    public void Move(float move, bool jump, bool Dash)
    {
     

        
        if (m_Grounded)
        {

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
        }
        // прыжок
        if (m_Grounded && jump)
        {
            // добавление силы по вертикали
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }

        if (m_Grounded == false && Dash )
        {
            if ( m_FacingRight)
            {
                m_Rigidbody2D.AddForce(new Vector2(Dash_force, 0f));
            }
            else
            {
                m_Rigidbody2D.AddForce(new Vector2(-Dash_force, 0f));
            }
        }
        
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




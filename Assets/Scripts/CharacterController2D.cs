using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;                          // ���� ������ 
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;   // ��������� ��������
    [SerializeField] private LayerMask m_WhatIsGround;                          // ����� ������������ �� ��� �������� ���������� ������������
    [SerializeField] private Transform m_GroundCheck;                           // ��������� ���������� � ��� ������������� �� �������� � ������������ ��� ��������� � ������

    const float k_GroundedRadius = .2f; 
    private bool m_Grounded;            
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // ���������� ������� � ������� ������� ��������
    private Vector3 m_Velocity = Vector3.zero;

    //��� �� ��� ��������
    /*public string ladderTag = "GameController"; // ��� �������
    private Vector3 upLadder, downLadder, ladderPos, direction;
    public bool isLadder;
    public float speed = 0.1f; // �������� �������� �� ��������? � ����� ��� ����� ��� ��������
    */
    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;
    public static CharacterController2D Instance { get; set; } // ��������, ����� ���������� � ����� � ������� ������, �� �������� ��� ���������

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


    public void Move(float move, bool jump)
    {
     

        
        if (m_Grounded)
        {

            // ����������� �������� �����������
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
           
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // �������� ������ � ������� �����������
            if (move > 0 && !m_FacingRight)
            {
          
                Flip();
            }
         
            else if (move < 0 && m_FacingRight)
            {
        
                Flip();
            }
        }
        // ������
        if (m_Grounded && jump)
        {
            // ���������� ���� �� ���������
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }

        
    }


    private void Flip()
    {
        // ������� ������ �����,������
        m_FacingRight = !m_FacingRight;

     
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

//����, � �������� ��� �������� ��������, �� ����� ������� � ����� ������������ �����, ������� �������������� � ������� ����������
//��� ��� � movement.cs ���� �������
//������ ����� ���-�� � ���������� ��������
    
    /*void OnTriggerStay2D(Collider2D other) //��������� � ������ ��� ������� ��������� ���������� �� ����� � ���������
    {
        if (other.tag == ladderTag && !isLadder)
        {
            Ladder ladder = other.GetComponent<Ladder>();
            upLadder = ladder.up.position;
            downLadder = ladder.down.position;
            ladderPos = other.transform.position;
            isLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == ladderTag)
        {
            isLadder = false;
            m_Rigidbody2D.isKinematic = false;
        }
    }

    public void LadderMode(float vertical)     //�������� �� ��������
    {
        if (transform.position.y < upLadder.y && vertical > 0)
        {
            m_Rigidbody2D.isKinematic = true;
        }
        else if (transform.position.y > downLadder.y && vertical < 0 && transform.position.y > upLadder.y)
        {
            m_Rigidbody2D.isKinematic = true;
        }
        else if (vertical < 0 && m_Grounded && transform.position.y < upLadder.y)
        {
            m_Rigidbody2D.isKinematic = false;
        }

        if (m_Rigidbody2D.isKinematic)
        {
            transform.Translate(new Vector2(0, speed * vertical * Time.fixedDeltaTime)); // �������� �� ��������
            float xPos = Mathf.Lerp(transform.position.x, ladderPos.x, 10 * Time.deltaTime);
            transform.position = new Vector2(xPos, transform.position.y); // ������� ������������ �� ������ ��������
        }
    }*/
}




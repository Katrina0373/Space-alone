using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    [SerializeField] public float speed = 20f;                   
    [SerializeField] public Rigidbody2D Circle1;
    [SerializeField] public Transform bams_check;
    [SerializeField] private LayerMask m_WhatIsObject;
    [SerializeField] private float Max_dist = 7;
    [SerializeField] private GameObject Starter;
    
    float dist = 0;
    Vector3 spawnPos;

    const float bams_rad = .2f;
    private bool m_bams;
    // Start is called before the first frame update
    void Start()
    {
        Circle1.velocity = transform.right * speed;
        Vector3 spawnPos = transform.position;
    }


    /*void BamsIntoTrigger (Collider2D bams)
    {
        if()
    }*/
    private void FixedUpdate()
    {
    dist = Vector3.Distance(spawnPos, transform.position);
    bool wasbams = m_bams;
        m_bams = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(bams_check.position, bams_rad, m_WhatIsObject);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_bams = true;
                if (!wasbams)
                {
                    //GetComponent<Collider>().GetComponent<Telephatic>().Taken_t();
                    Destroy(gameObject);
                }
            }
        }
        if (dist >= Max_dist)
            Destroy(gameObject);
    }
}




/*
 * private void FixedUpdate()
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
 */
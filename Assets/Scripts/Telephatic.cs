using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telephatic : MonoBehaviour

{
   /* [SerializeField] public Transform bams_check;
    [SerializeField] private LayerMask m_WhatIsObject;
    [SerializeField] public Transform teleport;

    const float bams_rad = 2f;
    public bool taken;
    // Start is called before the first frame update
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(bams_check.position, bams_rad, m_WhatIsObject);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                while (Input.GetButtonDown("Fire1"))
                    transform.position = teleport.position;
            }
        }
        /*
        void teleport_t(bool taken)
        {
            if (taken)
            {
                while 
                taken = false;
            }
        }
        */
    
   /*public void Taken_t()
    {
        taken = true;
    }
    */
}

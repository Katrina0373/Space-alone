using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roter : MonoBehaviour
{
    [SerializeField] private float offset = 100;
    [SerializeField] private Transform RayStart;
    [SerializeField] private GameObject CatcherSprite;
    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float Rott = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, Rott + offset);

        if ( Input.GetButtonDown("Fire1"))
        {
            Catch();
        }

        void Catch()
        {
            Instantiate(CatcherSprite, RayStart.position, RayStart.rotation);
        }
    }
}

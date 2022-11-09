using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
       if (collision.gameObject == CharacterController2D.Instance.gameObject)
           Destroy(player);
    }
}

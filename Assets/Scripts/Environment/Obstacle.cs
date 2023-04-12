using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Obstacle : MonoBehaviour
{
    [SerializeField] private DeathScreen screen;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "AstroStay")
        {
            Destroy(collision.gameObject);
            GameObject.Find("pause").GetComponent<pause_menu>().PlayerDeath(" насажен на шипы");
        }
        else if (collision.gameObject.tag.Equals("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Movement sup = collision.gameObject.GetComponent<Movement>();
            if (sup.Vinyl_n == "Dash")
            {
                Destroy(this.gameObject);
            }
            else { Destroy(collision.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    
    protected bool isCollisioln = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isCollisioln = true;
        if (collision.gameObject.tag.Equals("Player"))
        {
            /*Movement sup = collision.gameObject.GetComponent<Movement>();
            if (sup.Vinyl_n == "Dash")
            {
                Destroy(this.gameObject);
            }
            else
            {*/
                Destroy(collision.gameObject);
            GameObject.Find("pause").GetComponent<pause_menu>().PlayerDeath("убит монстром");
            //}
        }
    }
}

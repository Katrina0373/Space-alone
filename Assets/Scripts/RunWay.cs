using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunWay : MonoBehaviour
{
    public Button on;
    public float speed = 5f;
    public GameObject stop;

    private void Update()
    {
        if (on.IsPress && transform.position.x < stop.transform.position.x)
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.transform.parent = this.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.transform.parent = null;
    }
}

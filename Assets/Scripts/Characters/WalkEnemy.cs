using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class WalkEnemy:Enemy
{
    public float speed = 2f;
    public float diapason = 1f;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(c_Move());
    }

    IEnumerator c_Move()
    {
        var min = transform.position.x - diapason;
        var max = transform.position.x + diapason;

        var direction = Mathf.Sign(speed);

        while (true)
        {
            if (transform.position.x > max && direction > 0.0f)
            {
                direction = -direction;
            }
            else if (transform.position.x < min && direction < 0.0f)
            {
                direction = -direction;
            }

            rb2d.velocity = new Vector2(speed * direction, rb2d.velocity.y);

            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkEnemy : Enemy
{
    [SerializeField] float speed = 3.5f;
    [SerializeField] bool isLeft = false;
    private Vector3 dir;

    private void Start()
    {
        dir = transform.right;
        if (isLeft) dir *= -1f;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position +
            transform.up * 0.1f + transform.right * dir.x * 0.7f, 0.1f);

        if (colliders.Length > 0) dir *= -1f;
        transform.position = Vector3.MoveTowards(transform.position, 
            transform.position + dir, Time.deltaTime);
    }
}

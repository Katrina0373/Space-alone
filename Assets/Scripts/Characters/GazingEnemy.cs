using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazingEnemy : Enemy
{
    [SerializeField] GameObject player;
    [SerializeField] float speed = 30.0f;
    [SerializeField] int triggerDistance = 4;

    private void Update()
    {
        if (player == null)
            return;
        float direction = player.transform.position.x - transform.position.x;

        if (Mathf.Abs(direction) < triggerDistance)
        {
            Vector3 pos = transform.position;
            pos.x += Mathf.Sign(direction) * speed * Time.deltaTime;
            transform.position = pos;
        }
    }
}

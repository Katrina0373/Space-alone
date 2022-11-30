using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entering : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public Ladder ladder;

    private void Start()
    {
        boxCollider = ladder.GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            boxCollider.enabled = true;
    }
}

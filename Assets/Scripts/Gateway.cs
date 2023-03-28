using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gateway : Door
{
    protected override void Opening()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
    }
}

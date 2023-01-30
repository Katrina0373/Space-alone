using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private bool isPress = false;
    public SpriteRenderer spriteRenderer;
    public Sprite up;
    public Sprite down;

    public bool IsPress() { return isPress; }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        isPress = true;
        spriteRenderer.sprite = down;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        isPress = false;
        spriteRenderer.sprite = up;
    }
}

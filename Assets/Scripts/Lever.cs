using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Lever : Button
{
    public SpriteRenderer spriteRenderer;
    public Sprite leverDownSprite;
    public Sprite leverUpSprite;
    bool forSprite = false;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (Input.GetKeyDown(KeyCode.E) && collider.gameObject.tag == "Player")
        {
            isPress = !isPress;
            forSprite = !forSprite;
            if (forSprite) spriteRenderer.sprite = leverDownSprite;
            else spriteRenderer.sprite = leverUpSprite;
        }
    }
}

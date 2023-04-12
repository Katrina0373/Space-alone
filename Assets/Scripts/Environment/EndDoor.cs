using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndDoor : Door
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite openDoorSprite;

    protected override void Opening()
    {
        spriteRenderer.sprite = openDoorSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && IsOpen)
        {
            GameObject.Find("pause").GetComponent<pause_menu>().Success();
        }
    }
}

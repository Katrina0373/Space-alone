using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//скрипт для двери на следующий уровень
public class Door : MonoBehaviour
{   [SerializeField] bool IsOpen;          //открыта или нет
    [SerializeField] Button[] buttons;     //массив кнопок, которые нужно активировать, чтобы открыть дверь
    [SerializeField] GameObject player;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite openDoorSprite;

    void FixedUpdate()
    {
        if (!IsOpen)
        {
            foreach (var x in buttons)
            {
                if (!x.isPress)
                {
                    IsOpen = false;
                    break;
                }
                IsOpen = true;
            }
        }
        else
        {
            spriteRenderer.sprite = openDoorSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && IsOpen)
        {
            SceneManager.LoadScene(0);
        }
    }
}

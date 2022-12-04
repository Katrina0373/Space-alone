using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//скрипт для двери на следующий уровень
public class Door : MonoBehaviour
{
    public Button[] buttons;     //массив кнопок, которых нужно активировать, чтобы открыть дверь
    private bool IsOpen = false; //открыта или нет
    public GameObject player;
    public SpriteRenderer spriteRenderer;
    public Sprite openDoorSprite;

    void FixedUpdate()
    {
        if (!IsOpen)
        {
            foreach (var x in buttons)
            {
                if (!x.IsPress)
                    break;
                IsOpen = x.IsPress;
            }
        }
        else
            spriteRenderer.sprite = openDoorSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && IsOpen)
        {
            Destroy(collision.gameObject); //проверка работоспособности
                                           //на самом деле тут анимация и переход на седующий уровень
        }
    }




}

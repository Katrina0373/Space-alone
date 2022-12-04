using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//простая кнопка
public class Button : MonoBehaviour
{
    public bool IsPress = false; // нажата или нет
    public SpriteRenderer spriteRenderer;
    public Sprite leverDownSprite;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (Input.GetKeyDown(KeyCode.E) && collider.gameObject.tag == "Player")
        {
            //anim
            IsPress = !IsPress; //переделаем потом на IsPress = !IsPress чтобы можно было выключать
        }
    }
}

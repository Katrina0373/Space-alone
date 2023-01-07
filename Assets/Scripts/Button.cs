using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������� ������
public class Button : MonoBehaviour
{
    public bool IsPress; // ������ ��� ���
    public SpriteRenderer spriteRenderer;
    public Sprite leverDownSprite;
    public Sprite leverUpSprite;
    bool forSprite = false;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (Input.GetKeyDown(KeyCode.E) && collider.gameObject.tag == "Player")
        {
            IsPress = !IsPress;
            forSprite = !forSprite;
            if (forSprite) spriteRenderer.sprite = leverDownSprite;
            else spriteRenderer.sprite = leverUpSprite;
        }
    }
}

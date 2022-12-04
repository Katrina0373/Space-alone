using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������� ������
public class Button : MonoBehaviour
{
    public bool IsPress = false; // ������ ��� ���
    public SpriteRenderer spriteRenderer;
    public Sprite leverDownSprite;
    public Sprite leverUpSprite;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (Input.GetKeyDown(KeyCode.E) && collider.gameObject.tag == "Player")
        {
            //anim
            IsPress = !IsPress; //���������� ����� �� IsPress = !IsPress ����� ����� ���� ���������
            if (IsPress) spriteRenderer.sprite = leverDownSprite;
            else spriteRenderer.sprite = leverUpSprite;
        }
    }
}

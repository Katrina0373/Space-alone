using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������� ������
public class Button : MonoBehaviour
{
    public bool IsPress = false; // ������ ��� ���

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (Input.GetKeyDown(KeyCode.E) && collider.gameObject.tag == "Player")
        {
            //anim
            IsPress = !IsPress; //���������� ����� �� IsPress = !IsPress ����� ����� ���� ���������
        }
    }
}

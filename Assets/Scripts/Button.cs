using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������� ������
public class Button : MonoBehaviour
{
    public bool IsPress = false; // ������ ��� ���
    public GameObject player;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (Input.GetKeyDown(KeyCode.E) && collider.gameObject.tag == "Player" && !IsPress)
        {
            //anim
            IsPress = true; //���������� ����� �� IsPress = !IsPress ����� ����� ���� ���������
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ ��� ����� �� ��������� �������
public class Door : MonoBehaviour
{
    public Button[] buttons;     //������ ������, ������� ����� ������������, ����� ������� �����
    private bool IsOpen = false; //������� ��� ���
    public GameObject player;

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && IsOpen)
        {
            Destroy(collision.gameObject); //�������� �����������������
                                           //�� ����� ���� ��� �������� � ������� �� �������� �������
        }
    }




}

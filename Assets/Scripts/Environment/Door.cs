using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ ��� ����� ������������� �����
public class Door : MonoBehaviour
{   public bool IsOpen;          //������� ��� ���
    public Pushbutton[] buttons;     //������ ������, ������� ����� ������������, ����� ������� �����
    

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
            Opening();
        }
    }

    protected virtual void Opening() { }
    
}

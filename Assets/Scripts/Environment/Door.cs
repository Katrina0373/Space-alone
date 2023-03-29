using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//скрипт для любой открывающейся штуки
public class Door : MonoBehaviour
{   public bool IsOpen;          //открыта или нет
    public Pushbutton[] buttons;     //массив кнопок, которые нужно активировать, чтобы открыть дверь
    

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

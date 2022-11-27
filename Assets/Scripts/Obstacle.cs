using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//шипы полностью уничтожают игрока
public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "AstroStay")
            Destroy(collision.gameObject);
            //заупскается уровень заново
    }
}

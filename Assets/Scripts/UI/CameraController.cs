using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private int lastX;
    private Transform player;
    public Vector2 offset = new Vector2(2f, 1f);    //смещение камеры
    public float damping = 1.5f;                    //плавность движения
    public bool faceLeft;                           //если персонаж изначально смотрит влево, то надо поставить галолчку

    private void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(faceLeft);
    }

    public void FindPlayer(bool playerFaceLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        
        if (playerFaceLeft)
            transform.position = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
        
        else
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);
            faceLeft = currentX < lastX;
            lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target;
            if (faceLeft)
                target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
            else
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
            transform.position = currentPosition;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICamera : MonoBehaviour
{
    public Transform player;
    public float xPos = 0;
    public float yPos = 0.1f;
    public float zPos = -10f;

    void Start()
    {
        transform.position = new Vector3(player.position.x + xPos, player.position.y + yPos, zPos);
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x + xPos, player.position.y + yPos, zPos);
    }
}

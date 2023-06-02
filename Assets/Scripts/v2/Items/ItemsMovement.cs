using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsMovement : MonoBehaviour
{
    public float verticalSpeed = 2f; // Velocidad vertical del objeto
    public float amplitude = 0.1f; // Amplitud del flote

    private Vector3 startPosition;

    void Start()
    {
        // Guardar la posición inicial del objeto
        startPosition = transform.position;
    }

    void Update()
    {
        // Actualizar la posición vertical en función del tiempo y la velocidad vertical
        float time = Time.time;
        float verticalOffset = amplitude * Mathf.Sin(verticalSpeed * time);
        transform.position = startPosition + new Vector3(0f, verticalOffset, 0f);
    }

    public void ResetPosition()
    {
        // Restaurar la posición original del objeto
        transform.position = startPosition;
    }
}

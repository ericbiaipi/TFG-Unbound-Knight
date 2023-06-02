using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName; // El nombre del Enemigo, usado para estadisticas de cantidad de Kills

    public float healthPoints; // Cantidad de Puntos de vida de nuestro enemigo
    public float defense; // Cantidad de Puntos de defensa de nuestro enemigo
    public float speed; // velocidad al caminar

    public float knockbackForceX; // fuerza que se aplicará horizontalmente al recibir golpe
    public float knockbackForceY; // fuerza que se aplicará verticalmente al recibir golpe

    public float damageToGive; // Daño que hará al jugador
}

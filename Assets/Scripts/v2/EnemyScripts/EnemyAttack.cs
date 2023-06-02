using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject weapon;
    public Animator animator;
    public float timeToShoot;
    public float shootCooldown;
    public float detectionRange = 1; // Rango de detección del jugador

    private Transform player; // Referencia al transform del jugador

    void Start()
    {
        shootCooldown = timeToShoot;
        player = GameObject.FindGameObjectWithTag("Player").transform; // Buscar el jugador por la etiqueta "Player"
    }

    void Update()
    {
        
        shootCooldown -= Time.deltaTime;

        Shoot();
    }


    public void Shoot()
    {
        // Comprobar si el jugador está dentro del rango de detección
        if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {

            if (shootCooldown < 0)
            {
                animator.SetBool("Attack", true);
            }

            shootCooldown = timeToShoot;
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }






    /*public float damageToPlayer = 10f; // Daño que inflige el enemigo al jugador
    public float detectionRange = 1f; // Rango de detección del jugador
    public Animator animator;
    public GameObject weapon;

    private bool canDamage = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        weapon.SetActive(false);
    }

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRange);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                AttackPlayer();
                break;
            }
        }
    }

    private void AttackPlayer()
    {
        animator.SetBool("Attack", true); // Establecer el parámetro de animación "IsAttacking" a true
        weapon.SetActive(true); // Activar el collider del arma
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canDamage)
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.health -= damageToPlayer;
                StartCoroutine(ResetDamage());
            }
        }
    }

    IEnumerator ResetDamage()
    {
        canDamage = false;
        yield return new WaitForSeconds(1f); // Tiempo de espera antes de que el enemigo pueda dañar al jugador nuevamente
        canDamage = true;
        animator.SetBool("Attack", false); // Establecer el parámetro de animación "IsAttacking" a false
        weapon.SetActive(false); // Desactivar el collider del arma
    }*/
}

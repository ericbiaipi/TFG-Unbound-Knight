using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public bool isDamaged;

    SpriteRenderer sprite;
    Blink material;
    Enemy enemy;
    Rigidbody2D rb;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        enemy = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon") && !isDamaged)
        {
            // Quitamos un punto de vida al enemigo
            enemy.healthPoints -= 1f;
            AudioManager.instance.PlayAudio(AudioManager.instance.hit);

            // KnockBacks
            if (collision.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            }
            else
            {
                rb.AddForce(new Vector2(-enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            }

            StartCoroutine(Damager());
            
            
            if (enemy.healthPoints <= 0)
            {
                AudioManager.instance.PlayAudio(AudioManager.instance.enemyDead);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Damager()
    {
        // Colocamos el Bool IsDamaged como True, para que no se pueda golpear más al enemigo.
        isDamaged = true;
        // Cambiamos el material al blanco y esperamos 0.5f segundos
        sprite.material = material.blink;
        yield return new WaitForSeconds(0.5f);
        // Abrimos la opción para que se pueda volver a dañar al enemigo y colocarmos el material original.
        isDamaged = false;
        sprite.material = material.original;
    }


}

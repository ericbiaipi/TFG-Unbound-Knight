using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    bool isInmune;
    public float inmunityTime;

    SpriteRenderer sprite;
    Blink material;

    public float knockbackForceX;
    public float knockbackForceY;
    Rigidbody2D rb;

    public Image healthImg;

    public GameObject gameOverImg;
    public GameObject winImg;

    public static PlayerHealth instace;

    void Start()
    {
        gameOverImg.SetActive(false);
        winImg.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        health = maxHealth;
    }

    void Update()
    {
        healthImg.fillAmount = health / 100;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (BankAccount.instance.bank >= 4500)
        {
            ShowVictoryScreen();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isInmune)
        {
            health -= collision.GetComponent<Enemy>().damageToGive;

            StartCoroutine(Inmunity());

            if (collision.transform.position.x > transform.position.x)
            {
                rb.AddForce(new Vector2(-knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }
            else
            {
                rb.AddForce(new Vector2(knockbackForceX, knockbackForceY), ForceMode2D.Force);

            }

            if (health <= 0)
            {
                // Aparecer pantalla de Game Over.  
                Time.timeScale = 0;
                gameOverImg.SetActive(true);
                AudioManager.instance.backgroundMusic.Stop();
                AudioManager.instance.PlayAudio(AudioManager.instance.gameOver);

            }
        }
    }


    void ShowVictoryScreen()
    {
        // Aparecer pantalla de victoria.
        Time.timeScale = 0;
        winImg.SetActive(true);
        AudioManager.instance.backgroundMusic.Stop();
        //AudioManager.instance.PlayAudio(AudioManager.instance.victory);
    }



    IEnumerator Inmunity()
    {

        isInmune = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(inmunityTime);
        sprite.material = material.original;
        isInmune = false;
    }
}
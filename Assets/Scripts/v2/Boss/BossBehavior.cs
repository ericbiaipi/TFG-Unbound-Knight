using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBehavior : MonoBehaviour
{
    public float bossHealth, currentHealth;
    public Image healthImg;

    public bool isDead = false;

    void Start()
    {
        
    }


    void Update()
    {
        if (currentHealth <= 0)
        {
            isDead = true;
        }
        DamageBoss();
        BossScale();
    }

    // Metodo para que la barra de vida vaya bajando segun su vida
    public void DamageBoss()
    {
        currentHealth = GetComponent<Enemy>().healthPoints;
        healthImg.fillAmount = currentHealth / bossHealth;
    }

    // Metodo para que el BOSS nos mire
    public void BossScale() 
    {
        if (transform.position.x > PlayerController.instance.transform.position.x)
        {
            transform.localScale = new Vector3(-3, 3, 3);   // Que mire hacia la izquierda
        }
        else 
        {
            transform.localScale = new Vector3(3, 3, 3);    // Que mire hacia la derecha
        }
    }


    private void OnDestroy()
    {
        Animator animator = GetComponent<Animator>();
        {
            animator.SetBool("IsDead", isDead);
        }

        BossUI.instance.BossDectivator();
    }

}

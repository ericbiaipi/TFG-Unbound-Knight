using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUI : MonoBehaviour
{
    public GameObject bossPanel;
    public GameObject muros;

    public static BossUI instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } 
    }

    void Start()
    {
        bossPanel.SetActive(false);
        muros.SetActive(false);
    }

    public void BossActivator()
    { 
        bossPanel.SetActive(true);
        muros.SetActive(true);
    }

    public void BossDectivator()
    {
        bossPanel.SetActive(false);
        muros.SetActive(false);
        StartCoroutine(BossDefeated());
    }

    // Cuando el boss muere se desactiva el movimiento del Player por tres segundos
    IEnumerator BossDefeated()
    {
        var velocity = PlayerController.instance.GetComponent<Rigidbody2D>().velocity;

        Vector2 orginalSpeed = velocity;
        velocity = new Vector2(0, velocity.y);

        PlayerController.instance.enabled = false;
        yield return new WaitForSeconds(3);
        PlayerController.instance.enabled = true;

        velocity = orginalSpeed;
    }
}

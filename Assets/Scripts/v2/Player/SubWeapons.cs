using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeapons : MonoBehaviour
{
    public int arrowCost;
    public GameObject arrow;

    void Update()
    {
        UseSubWeapon();
    }

    public void UseSubWeapon()
    { 
        if(Input.GetButtonDown("Fire2") && arrowCost <= SubItems.instance.subItemsAmount)
        {
            SubItems.instance.SubItem(-arrowCost);
            AudioManager.instance.PlayAudio(AudioManager.instance.arrow);
            GameObject subItem = Instantiate(arrow, transform.position, Quaternion.Euler(0,0,-135));

            // Detectamos hacia donde mira el jugador para que la flecha salga a la misma direccion
            if (transform.localScale.x < 0)
            {
                subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(-800f, 0f), ForceMode2D.Force); // Velocidad hacia la izquierda
                subItem.transform.localScale = new Vector2(-0.25f,-0.25f);  // Tamaño de la flecha al mirar hacia la izquierda
            }
            else
            {
                subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(800f, 0f), ForceMode2D.Force); // Velocidad hacia la derecha
            }
        }
    }
}

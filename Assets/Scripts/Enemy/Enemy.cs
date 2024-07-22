using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Iinimigo recebeu" + damage + "de dano. Vida restante: " + health);

        if (health < 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Inimigo morreu");
        Destroy(gameObject);

    }
    
}

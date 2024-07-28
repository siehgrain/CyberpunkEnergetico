using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashDamage : MonoBehaviour
{
    public PlayerStats playerStats;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyP"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(playerStats.DashDamage);
            }
        }
        if (other.CompareTag("EnemyM"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(playerStats.DashDamage);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}

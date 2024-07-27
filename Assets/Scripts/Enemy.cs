using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float Dano = 10;
    public GameObject itemToDrop;
    public int chanceToDrop;
    public float attackRange = 2f;
    public float attackInterval = 1f;
    private float nextAttackTime = 0f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackInterval;
        }
    }
    void Attack()
    {
        // Encontrar players dentro do alcance
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                Debug.Log("Acertou " + collider.name);
                // Aplicar dano ao player
                PlayerDamage player = collider.GetComponent<PlayerDamage>();
                if (player != null)
                {
                }
            }
        }
    }

    void Die()
    {
        int randomNumber = Random.Range(0, 100);
        if (randomNumber <= chanceToDrop)
        {
            Instantiate(itemToDrop, transform.position, Quaternion.identity);
        }
        gameObject.SetActive(false);
    }
}

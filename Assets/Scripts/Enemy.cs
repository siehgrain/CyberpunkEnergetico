using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float Dano = 10f;
    public GameObject itemToDrop;
    public int chanceToDrop;
    public float attackRange = 2f;
    public float attackInterval = 1f;
    private float nextAttackTime = 0f;

    WaveEnemy Spawner;

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
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                Debug.Log("Acertou " + collider.name);
                PlayerDamage player = collider.GetComponent<PlayerDamage>();
                if (player != null)
                {
                    player.TakeDamage(Dano);
                }
            }
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    public void SetSpawner(WaveEnemy _spawner)
    {
        Spawner = _spawner;
    }

    void Die()
    {
        int randomNumber = Random.Range(0, 100);
        if (randomNumber <= chanceToDrop)
        {
            Instantiate(itemToDrop, transform.position, Quaternion.identity);
        }
        if (Spawner != null) Spawner.currentMonster.Remove(this.gameObject);
        Spawner.currentMonster.Remove(this.gameObject);
        Destroy(gameObject);
    }
}

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public int attackDamage = 10;
    public float attackInterval = 1f;
    public float attackRange = 2f;
    public string playerTag = "Player"; // Tag do player
    public GameObject itemToDrop;
    public int chanceToDrop;

    private float nextAttackTime = 0f;

    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackInterval;
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        int randomNumber = Random.Range(0, 100);
        if (randomNumber <= chanceToDrop)
        {
            Instantiate(itemToDrop, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    void Attack()
    {
        // Encontrar players dentro do alcance
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag(playerTag))
            {
                Debug.Log("Acertou " + collider.name);
                // Aplicar dano ao player
                PlayerDamage player = collider.GetComponent<PlayerDamage>();
                if (player != null)
                {
                    player.TakeDamage(attackDamage);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Desenhar uma esfera no editor para visualizar o alcance do ataque
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
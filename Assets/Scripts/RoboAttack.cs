using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoboAttack : MonoBehaviour
{
    public float attackRate = 1f;
    public float damage = 10;
    public int projectileCount = 1;
    public float projectileSpeed = 10f;
    public GameObject projectilePrefab;
    public PlayerStats playerStats;

    private float attackCooldown = 0f;

    void Start()
    {
        StartCoroutine(AttackRoutine());
        damage = playerStats.Dano;
        projectileCount = playerStats.Projeteis;
        attackRate = playerStats.Recarga;
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (attackCooldown <= 0f)
            {
                Attack();
                attackCooldown = 1f / attackRate;
            }
            else
            {
                attackCooldown -= Time.deltaTime;
            }

            yield return null;
        }
    }

    void Attack()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        mousePosition.z = 10;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 direction = (worldMousePosition - transform.position).normalized;
        direction.y = 0;

        for (int i = 0; i < projectileCount; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Projectile projScript = projectile.GetComponent<Projectile>();
            if (projScript != null)
            {
                projScript.SetDirection(direction, (int)damage, projectileSpeed);
            }
        }
    }
}

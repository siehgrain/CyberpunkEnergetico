using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class PlayerDamage : MonoBehaviour
{
    public float attackInterval = 1f; // Intervalo entre ataques em segundos
    public float attackRange = 2f; // Distância de ataque
    public int attackDamage = 10; // Dano do ataque
    public string enemyTag = "Enemy"; // Tag dos inimigos
    public Animator animator; // Referência ao Animator
    public Slider healthSlider; // Referência ao Slider de vida
    private float nextAttackTime = 0f;
    private float health = 100f; // Vida inicial do player

    private void Start()
    {
        animator = GetComponent<Animator>();
        healthSlider.value = health;
        healthSlider.maxValue = health;
    }

    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackInterval;
        }

        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthSlider.value = health;
    }

    void Attack()
    {
        // Iniciar a animação de ataque
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        // Encontrar inimigos dentro do alcance
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag(enemyTag))
            {
                Debug.Log("Acertou " + collider.name);
                // Aplicar dano ao inimigo
                Enemy enemy = collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(attackDamage);
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


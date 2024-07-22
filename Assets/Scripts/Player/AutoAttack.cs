using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    public float attackInterval = 1f; // Intervalo entre ataques em segundos
    public float attackRange = 2f; // Distância de ataque
    public int attackDamage = 10; // Dano do ataque
    public string enemyTag = "Enemy"; // Tag dos inimigos
    public Animator animator; // Referência ao Animator

    private float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackInterval;
        }
    }

    void Attack()
    {
        // Iniciar a animação de ataque
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        // Encontrar a posição do mouse no mundo do jogo
        Vector3 mousePosition = GetMouseWorldPosition();
        Vector3 direction = (mousePosition - transform.position).normalized;
        Vector3 attackPosition = transform.position + direction * attackRange;

        // Encontrar inimigos dentro do alcance
        Collider[] hitColliders = Physics.OverlapSphere(attackPosition, attackRange);

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

    Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            return hitInfo.point;
        }
        return Vector3.zero;
    }

    void OnDrawGizmosSelected()
    {
        // Desenhar uma esfera no editor para visualizar o alcance do ataque
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

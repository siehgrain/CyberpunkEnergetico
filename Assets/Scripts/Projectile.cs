using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 direction;
    private int damage;
    private float speed;
    private float lifetime = 3f; // Tempo de vida do proj�til em segundos
    private float lifetimeCounter;
    public GameObject explosion;

    void OnEnable()
    {
        lifetimeCounter = lifetime; // Resetar o tempo de vida quando o proj�til � ativado
    }

    public void SetDirection(Vector3 direction, int damage, float speed)
    {
        this.direction = direction;
        this.damage = damage;
        this.speed = speed;
    }

    void Update()
    {
        // Move o proj�til na dire��o especificada
        float distanceThisFrame = speed * Time.deltaTime;
        transform.Translate(direction * distanceThisFrame, Space.World);

        // Diminui o contador de tempo de vida
        lifetimeCounter -= Time.deltaTime;
        if (lifetimeCounter <= 0f)
        {
            Destroy(gameObject); // Remove o proj�til se o tempo de vida acabar
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica se o proj�til colidiu com um inimigo
        if (other.CompareTag("EnemyP"))
        {
            // Obt�m o componente do inimigo e aplica o dano
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                FindObjectOfType<Jukebox>().PlayOneShoot("Robo hitP");
            }
            Instantiate(explosion,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        if (other.CompareTag("EnemyM"))
        {
            // Obt�m o componente do inimigo e aplica o dano
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                FindObjectOfType<Jukebox>().PlayOneShoot("Robo hitM");
            }
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

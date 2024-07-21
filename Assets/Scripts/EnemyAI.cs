using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public string playerTag = "Player"; // Tag para encontrar o jogador
    public float followDistance = 10f; // Dist�ncia m�xima para seguir o jogador

    private Transform player; // Transform do jogador
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        // Obt�m o componente NavMeshAgent
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Encontra o jogador na cena usando a tag
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Jogador n�o encontrado com a tag: " + playerTag);
        }
    }

    void Update()
    {
        if (player == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= followDistance)
        {
            navMeshAgent.SetDestination(player.position);
        }
        else
        {
            navMeshAgent.ResetPath(); // Para o movimento quando o jogador est� fora da dist�ncia de seguimento
        }
    }
}

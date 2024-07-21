using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public string playerTag = "Player"; // Tag para encontrar o jogador
    public float followDistance = 10f; // Distância máxima para seguir o jogador

    private Transform player; // Transform do jogador
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        // Obtém o componente NavMeshAgent
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Encontra o jogador na cena usando a tag
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Jogador não encontrado com a tag: " + playerTag);
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
            navMeshAgent.ResetPath(); // Para o movimento quando o jogador está fora da distância de seguimento
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboFollow : MonoBehaviour
{
    public Transform player;    // Refer�ncia ao jogador
    public float followDistance = 5.0f;    // Dist�ncia m�nima para seguir o jogador
    public float stopDistance = 2.0f;    // Dist�ncia m�nima para parar de seguir o jogador

    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= followDistance && distance > stopDistance)
        {
            navMeshAgent.SetDestination(player.position);
        }
        else if (distance <= stopDistance)
        {
            navMeshAgent.ResetPath(); // Para de seguir o jogador
        }
    }
}

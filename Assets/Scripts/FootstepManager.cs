using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour
{

    // Intervalo de tempo entre passos
    public float stepInterval = 0.5f;

    // Contador de tempo para controlar os passos
    private float stepTimer;

    private void Start()
    {

        // Inicializar o timer
        stepTimer = stepInterval;
    }

    private void Update()
    {
        // Verifica se o jogador está se movendo
        if (IsMoving())
        {
            // Decrementa o timer
            stepTimer -= Time.deltaTime;

            // Se o timer chegar a zero, toca o som de passos
            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = stepInterval;
            }
        }
        else
        {
            // Reinicializa o timer se o jogador parar de se mover
            stepTimer = stepInterval;
        }
    }

    private bool IsMoving()
    {
        // Exemplo simples: verificar se há input de movimento (pode ser adaptado conforme seu sistema de movimento)
        return Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
    }

    private void PlayFootstep()
    {
        FindObjectOfType<Jukebox>().PlayOneShoot("PlayerFootstep");
    }
}

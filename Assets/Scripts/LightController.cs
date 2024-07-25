using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light playerLight; // A referência à luz do jogador
    public float decreaseRate = 5f; // Taxa de diminuição do ângulo externo do spot
    public float minSpotAngle = 0f; // Ângulo mínimo do spot
    public float maxSpotAngle = 179f; // Ângulo máximo do spot
    private float previousSpotAngle;
    public GameObject player; // Referência ao jogador
    public GameObject deathEffect; // Efeito visual de morte

    void Start()
    {
        if (playerLight == null)
        {
            playerLight = GetComponent<Light>();
        }

        // Define o ângulo do spot como a vida máxima do jogador
        playerLight.spotAngle = maxSpotAngle;

        previousSpotAngle = playerLight.spotAngle;
    }

    void Update()
    {
        DecreaseFieldOfViewOverTime();
    }

    private void DecreaseFieldOfViewOverTime()
    {
        // Verifica se o ângulo do spot ainda é maior que o mínimo permitido
        if (playerLight.spotAngle > minSpotAngle)
        {
            // Diminui o ângulo do spot com base na taxa de diminuição e no tempo
            float newSpotAngle = playerLight.spotAngle - decreaseRate * Time.deltaTime;
            playerLight.spotAngle = Mathf.Max(newSpotAngle, minSpotAngle);

            if (Mathf.Abs(playerLight.spotAngle - previousSpotAngle) > 0.01f) // Atualiza apenas se a diferença for significativa
            {
                previousSpotAngle = playerLight.spotAngle;
            }

            // Verifica se o ângulo do spot chegou ao mínimo, indicando morte
            if (playerLight.spotAngle <= minSpotAngle)
            {
                Die();
            }
        }
    }

    public void IncreaseFieldOfView(float amount)
    {
        float newSpotAngle = Mathf.Min(playerLight.spotAngle + amount, maxSpotAngle);
        if (Mathf.Abs(newSpotAngle - playerLight.spotAngle) > 0.01f) // Atualiza apenas se a diferença for significativa
        {
            playerLight.spotAngle = newSpotAngle;
            previousSpotAngle = playerLight.spotAngle;
        }
    }

    public void DecreaseFieldOfView(float amount)
    {
        if (playerLight.spotAngle > minSpotAngle)
        {
            float newSpotAngle = playerLight.spotAngle - amount;
            playerLight.spotAngle = Mathf.Max(newSpotAngle, minSpotAngle);

            if (Mathf.Abs(newSpotAngle - playerLight.spotAngle) > 0.01f) // Atualiza apenas se a diferença for significativa
            {
                playerLight.spotAngle = newSpotAngle;
                previousSpotAngle = playerLight.spotAngle;
            }

            // Verifica se o ângulo do spot chegou ao mínimo, indicando morte
            if (playerLight.spotAngle <= minSpotAngle)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        // Aqui você pode adicionar lógica de morte do jogador, como exibir um efeito e desativar o jogador
        if (deathEffect != null)
        {
            Instantiate(deathEffect, player.transform.position, Quaternion.identity);
        }
        // Desativa o jogador
        player.SetActive(false);
        // Adicione aqui qualquer outra lógica necessária para a morte do jogador
    }
}

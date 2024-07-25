using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light playerLight; // A refer�ncia � luz do jogador
    public float decreaseRate = 5f; // Taxa de diminui��o do �ngulo externo do spot
    public float minSpotAngle = 0f; // �ngulo m�nimo do spot
    public float maxSpotAngle = 179f; // �ngulo m�ximo do spot
    private float previousSpotAngle;
    public GameObject player; // Refer�ncia ao jogador
    public GameObject deathEffect; // Efeito visual de morte

    void Start()
    {
        if (playerLight == null)
        {
            playerLight = GetComponent<Light>();
        }

        // Define o �ngulo do spot como a vida m�xima do jogador
        playerLight.spotAngle = maxSpotAngle;

        previousSpotAngle = playerLight.spotAngle;
    }

    void Update()
    {
        DecreaseFieldOfViewOverTime();
    }

    private void DecreaseFieldOfViewOverTime()
    {
        // Verifica se o �ngulo do spot ainda � maior que o m�nimo permitido
        if (playerLight.spotAngle > minSpotAngle)
        {
            // Diminui o �ngulo do spot com base na taxa de diminui��o e no tempo
            float newSpotAngle = playerLight.spotAngle - decreaseRate * Time.deltaTime;
            playerLight.spotAngle = Mathf.Max(newSpotAngle, minSpotAngle);

            if (Mathf.Abs(playerLight.spotAngle - previousSpotAngle) > 0.01f) // Atualiza apenas se a diferen�a for significativa
            {
                previousSpotAngle = playerLight.spotAngle;
            }

            // Verifica se o �ngulo do spot chegou ao m�nimo, indicando morte
            if (playerLight.spotAngle <= minSpotAngle)
            {
                Die();
            }
        }
    }

    public void IncreaseFieldOfView(float amount)
    {
        float newSpotAngle = Mathf.Min(playerLight.spotAngle + amount, maxSpotAngle);
        if (Mathf.Abs(newSpotAngle - playerLight.spotAngle) > 0.01f) // Atualiza apenas se a diferen�a for significativa
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

            if (Mathf.Abs(newSpotAngle - playerLight.spotAngle) > 0.01f) // Atualiza apenas se a diferen�a for significativa
            {
                playerLight.spotAngle = newSpotAngle;
                previousSpotAngle = playerLight.spotAngle;
            }

            // Verifica se o �ngulo do spot chegou ao m�nimo, indicando morte
            if (playerLight.spotAngle <= minSpotAngle)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        // Aqui voc� pode adicionar l�gica de morte do jogador, como exibir um efeito e desativar o jogador
        if (deathEffect != null)
        {
            Instantiate(deathEffect, player.transform.position, Quaternion.identity);
        }
        // Desativa o jogador
        player.SetActive(false);
        // Adicione aqui qualquer outra l�gica necess�ria para a morte do jogador
    }
}

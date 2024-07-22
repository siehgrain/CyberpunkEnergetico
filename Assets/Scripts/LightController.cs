using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light playerLight; // A refer�ncia � luz do jogador
    public float decreaseRate = 0.1f; // Taxa de diminui��o do raio da luz
    public float minLightRange = 1f; // Raio m�nimo da luz
    public float maxLightRange = 10f; // Raio m�ximo da luz

    private float previousLightRange;

    void Start()
    {
        if (playerLight == null)
        {
            playerLight = GetComponent<Light>();
        }

        previousLightRange = playerLight.range;
    }

    void Update()
    {
        // Verifica se o raio da luz ainda � maior que o m�nimo permitido
        if (playerLight.range > minLightRange)
        {
            // Diminui o raio da luz com base na taxa de diminui��o e no tempo
            float newLightRange = playerLight.range - decreaseRate * Time.deltaTime;
            playerLight.range = Mathf.Max(newLightRange, minLightRange);

            if (Mathf.Abs(playerLight.range - previousLightRange) > 0.01f) // Atualiza apenas se a diferen�a for significativa
            {
                previousLightRange = playerLight.range;
            }
        }
    }

    public void IncreaseVision(float amount)
    {
        float newLightRange = Mathf.Min(playerLight.range + amount, maxLightRange);
        if (Mathf.Abs(newLightRange - playerLight.range) > 0.01f) // Atualiza apenas se a diferen�a for significativa
        {
            playerLight.range = newLightRange;
            previousLightRange = playerLight.range;
        }
    }
}

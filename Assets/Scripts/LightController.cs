using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light playerLight; // A referência à luz do jogador
    public float decreaseRate = 0.1f; // Taxa de diminuição do raio da luz
    public float minLightRange = 1f; // Raio mínimo da luz
    public float maxLightRange = 10f; // Raio máximo da luz

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
        // Verifica se o raio da luz ainda é maior que o mínimo permitido
        if (playerLight.range > minLightRange)
        {
            // Diminui o raio da luz com base na taxa de diminuição e no tempo
            float newLightRange = playerLight.range - decreaseRate * Time.deltaTime;
            playerLight.range = Mathf.Max(newLightRange, minLightRange);

            if (Mathf.Abs(playerLight.range - previousLightRange) > 0.01f) // Atualiza apenas se a diferença for significativa
            {
                previousLightRange = playerLight.range;
            }
        }
    }

    public void IncreaseVision(float amount)
    {
        float newLightRange = Mathf.Min(playerLight.range + amount, maxLightRange);
        if (Mathf.Abs(newLightRange - playerLight.range) > 0.01f) // Atualiza apenas se a diferença for significativa
        {
            playerLight.range = newLightRange;
            previousLightRange = playerLight.range;
        }
    }
}

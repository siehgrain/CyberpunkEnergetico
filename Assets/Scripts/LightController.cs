using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light playerLight; // A referência à luz do jogador
    public float decreaseRate = 0.1f; // Taxa de diminuição do raio da luz
    public float minLightRange = 1f; // Raio mínimo da luz
    public float maxLightRange = 10f; // Raio máximo da luz

    void Start()
    {
        if (playerLight == null)
        {
            playerLight = GetComponent<Light>();
        }
    }

    void Update()
    {
        // Verifica se o raio da luz ainda é maior que o mínimo permitido
        if (playerLight.range > minLightRange)
        {
            // Diminui o raio da luz com base na taxa de diminuição e no tempo
            playerLight.range -= decreaseRate * Time.deltaTime;
        }
    }

    // Função para aumentar o campo de visão
    public void IncreaseVision(float amount)
    {
        playerLight.range = Mathf.Min(playerLight.range + amount, maxLightRange);
    }
}

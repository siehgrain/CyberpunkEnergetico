using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light playerLight; // A refer�ncia � luz do jogador
    public float decreaseRate = 0.1f; // Taxa de diminui��o do raio da luz
    public float minLightRange = 1f; // Raio m�nimo da luz
    public float maxLightRange = 10f; // Raio m�ximo da luz

    void Start()
    {
        if (playerLight == null)
        {
            playerLight = GetComponent<Light>();
        }
    }

    void Update()
    {
        // Verifica se o raio da luz ainda � maior que o m�nimo permitido
        if (playerLight.range > minLightRange)
        {
            // Diminui o raio da luz com base na taxa de diminui��o e no tempo
            playerLight.range -= decreaseRate * Time.deltaTime;
        }
    }

    // Fun��o para aumentar o campo de vis�o
    public void IncreaseVision(float amount)
    {
        playerLight.range = Mathf.Min(playerLight.range + amount, maxLightRange);
    }
}

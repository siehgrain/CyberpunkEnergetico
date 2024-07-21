using FischlWorks_FogWar;
using UnityEngine;
using static FischlWorks_FogWar.csFogWar;

public class LightController : MonoBehaviour
{
    public Light playerLight; // A refer�ncia � luz do jogador
    public float decreaseRate = 0.1f; // Taxa de diminui��o do raio da luz
    public float minLightRange = 1f; // Raio m�nimo da luz
    public float maxLightRange = 10f; // Raio m�ximo da luz
    public csFogWar fogOfWarController; // A refer�ncia ao controlador do Fog of War

    void Start()
    {
        if (playerLight == null)
        {
            playerLight = GetComponent<Light>();
        }

        if (fogOfWarController == null)
        {
            fogOfWarController = FindObjectOfType<csFogWar>();
        }
    }

    void Update()
    {
        // Verifica se o raio da luz ainda � maior que o m�nimo permitido
        if (playerLight.range > minLightRange)
        {
            // Diminui o raio da luz com base na taxa de diminui��o e no tempo
            playerLight.range -= decreaseRate * Time.deltaTime;
            UpdateSightRange();
        }
    }
    public void IncreaseVision(float amount)
    {
        playerLight.range = Mathf.Min(playerLight.range + amount, maxLightRange);
        UpdateSightRange();
    }

    private void UpdateSightRange()
    {
        if (fogOfWarController != null)
        {
            fogOfWarController.SetSightRange(0, Mathf.RoundToInt(playerLight.range / 1));
        }
    }
}

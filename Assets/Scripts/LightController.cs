using FischlWorks_FogWar;
using UnityEngine;
using static FischlWorks_FogWar.csFogWar;

public class LightController : MonoBehaviour
{
    public Light playerLight; // A referência à luz do jogador
    public float decreaseRate = 0.1f; // Taxa de diminuição do raio da luz
    public float minLightRange = 1f; // Raio mínimo da luz
    public float maxLightRange = 10f; // Raio máximo da luz
    public csFogWar fogOfWarController; // A referência ao controlador do Fog of War

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
        // Verifica se o raio da luz ainda é maior que o mínimo permitido
        if (playerLight.range > minLightRange)
        {
            // Diminui o raio da luz com base na taxa de diminuição e no tempo
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

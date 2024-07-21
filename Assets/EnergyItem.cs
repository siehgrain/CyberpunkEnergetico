using UnityEngine;

public class EnergyItem : MonoBehaviour
{
    public float visionIncreaseAmount = 2f; // Quantidade de aumento da vis�o

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o jogador colidiu com o item de energia
        if (other.CompareTag("Player"))
        {
            LightController lightController = other.GetComponent<LightController>();
            if (lightController != null)
            {
                lightController.IncreaseVision(visionIncreaseAmount);
            }
            // Destroi o item de energia ap�s ser coletado
            Destroy(gameObject);
        }
    }
}

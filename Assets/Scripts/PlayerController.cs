using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public LightController lightController; // Referência ao LightController
    public PlayerStats playerStats;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Disable();
    }

    private void Start()
    {
        if (lightController != null && playerStats != null)
        {
            // Define maxSpotAngle no LightController com base na vida máxima do jogador
            lightController.maxSpotAngle = playerStats.Vida;
            lightController.playerLight.spotAngle = lightController.maxSpotAngle;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Tomou Dano");
            DecreaseFieldOfView(playerStats.Defesa - collision.gameObject.GetComponent<Enemy>().Dano);
        }
    }

    private void DecreaseFieldOfView(float amount)
    {
        if (lightController != null)
        {
            lightController.DecreaseFieldOfView(amount);
        }
    }

    private void IncreaseFieldOfView(float amount)
    {
        if (lightController != null)
        {
            lightController.IncreaseFieldOfView(amount);
        }
    }
}

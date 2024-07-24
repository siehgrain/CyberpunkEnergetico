using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public LightController lightController; // Referência ao LightController

    private PlayerInputActions playerInputActions;
    private Vector2 mouseScreenPosition;
    public float DanoRecebido;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        //playerInputActions.Player.Look.performed += OnLookPerformed;
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Disable();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DecreaseFieldOfView(DanoRecebido);
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
            lightController.IncreaseFieldOfView(amount); // Valor para aumentar
        }
    }
}

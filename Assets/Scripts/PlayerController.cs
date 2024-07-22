using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Light fieldOfViewLight; // Luz que representa o campo de vis�o do jogador
    public float decreaseAmount = 1f; // Quanto diminuir o campo de vis�o
    public float minFieldOfView = 5f; // Valor m�nimo do campo de vis�o

    private PlayerInputActions playerInputActions;
    private Vector2 mouseScreenPosition;

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
            Debug.Log("Perdeu Vida");
            DecreaseFieldOfView();
            
        }
    }

    private void DecreaseFieldOfView()
    {
        if (fieldOfViewLight != null)
        {
            fieldOfViewLight.range = Mathf.Max(fieldOfViewLight.range - decreaseAmount, minFieldOfView);
        }
    }
}

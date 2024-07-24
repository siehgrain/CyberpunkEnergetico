using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private PlayerInputActions controls; // Instância do asset de ações de entrada
    private Vector2 movementInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        controls = new PlayerInputActions(); // Inicializa o asset de ações de entrada
    }

    private void OnEnable()
    {
        controls.Player.Enable(); // Ativa o Action Map Player
        controls.Player.Move.performed += OnMove;
        controls.Player.Move.canceled += OnMove;
    }

    private void OnDisable()
    {
        controls.Player.Disable(); // Desativa o Action Map Player
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // Usando movimento em 3D
        Vector3 move = new Vector3(movementInput.x, 0f, movementInput.y);
        rb.velocity = move * moveSpeed;
    }
}
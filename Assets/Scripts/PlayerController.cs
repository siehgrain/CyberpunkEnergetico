using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Light fieldOfViewLight; // Luz que representa o campo de visão do jogador
    public float decreaseAmount = 1f; // Quanto diminuir o campo de visão
    public float minFieldOfView = 5f; // Valor mínimo do campo de visão
    public float rotationSpeed = 5000f; // Velocidade de rotação

    private PlayerInputActions playerInputActions;
    private Vector2 mouseScreenPosition;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Look.performed += OnLookPerformed;
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Disable();
    }

    private void Update()
    {
        RotateTowardsMouse();
    }

    private void OnLookPerformed(InputAction.CallbackContext context)
    {
        mouseScreenPosition = context.ReadValue<Vector2>();
    }

    private void RotateTowardsMouse()
    {
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        Vector3 direction = (mouseWorldPosition - transform.position).normalized;
        direction.y = 0; // Manter a rotação no plano horizontal

        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            return hitInfo.point;
        }
        return transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o objeto com o qual colidiu tem a tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DecreaseFieldOfView();
        }
    }

    private void DecreaseFieldOfView()
    {
        if (fieldOfViewLight != null)
        {
            // Diminui o alcance da luz representando o campo de visão
            fieldOfViewLight.range = Mathf.Max(fieldOfViewLight.range - decreaseAmount, minFieldOfView);
        }
    }
}

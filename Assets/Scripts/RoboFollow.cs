using UnityEngine;
using UnityEngine.InputSystem;

public class RoboFollow : MonoBehaviour
{
    public Transform targetTransform; // Transform público para definir no Inspector
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        var playerInput = new PlayerInputActions();
        playerInput.Player.Look.performed += ctx => OnLook(ctx);
        playerInput.Enable();
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        Vector2 mouseScreenPosition = context.ReadValue<Vector2>();
        Ray ray = mainCamera.ScreenPointToRay(mouseScreenPosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Obtém o ponto de impacto do raycast
            Vector3 targetPosition = hit.point;
            targetPosition.y = targetTransform.position.y; // Mantém a altura do transform

            // Faz o transform olhar para a posição do mouse
            targetTransform.LookAt(targetPosition);

            // Ajusta a rotação para manter apenas o eixo Y
            Vector3 eulerRotation = targetTransform.eulerAngles;
            eulerRotation.x = 0; // Mantém o eixo X fixo
            eulerRotation.z = 0; // Mantém o eixo Z fixo
            targetTransform.eulerAngles = eulerRotation;
        }
    }
}

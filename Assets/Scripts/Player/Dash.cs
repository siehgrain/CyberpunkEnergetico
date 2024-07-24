using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{
    public float dashDistance = 10f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 2f;

    private PlayerInputActions playerInputActions;
    private CharacterController characterController;
    private Vector3 dashDirection;
    private bool canDash = true;
    private bool isDashing = false;
    private float dashStartTime;
    public GameObject particle;
    public GameObject slash;

    // Adicione uma referência ao Animator
    private Animator animator;
    private static readonly int DashTrigger = Animator.StringToHash("Dash");

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();  // Obtenha o componente Animator

        playerInputActions.Player.Dash.performed += ctx => StartDash();
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
        if (isDashing)
        {
            float elapsed = Time.time - dashStartTime;
            if (elapsed < dashDuration)
            {
                characterController.Move(dashDirection * (dashDistance / dashDuration) * Time.deltaTime);
            }
            else
            {
                slash.SetActive(true);
                particle.SetActive(false);
                isDashing = false;
                Invoke(nameof(ResetDash), dashCooldown);
            }
        }
    }

    private void StartDash()
    {
        if (canDash)
        {
            particle.SetActive(true);
            dashDirection = transform.forward;
            dashStartTime = Time.time;
            isDashing = true;
            canDash = false;

            // Acione o trigger de animação
            if (animator != null)
            {
                animator.SetTrigger(DashTrigger);
            }
        }
    }

    private void ResetDash()
    {
        canDash = true;
        slash.SetActive(false);
    }
}

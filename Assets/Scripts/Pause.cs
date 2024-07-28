using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;
    private DefaultInputActions controls;
    public GameObject UpgradePanel;

    void Awake()
    {
        controls = new DefaultInputActions();
        controls.UI.Cancel.performed += ctx => TogglePause();
    }

    void OnEnable()
    {
        controls.UI.Enable();
    }

    void OnDisable()
    {
        controls.UI.Disable();
    }

    void TogglePause()
    {
        if (UpgradePanel.activeSelf == false && FindObjectOfType<LightController>().IsAlive)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}

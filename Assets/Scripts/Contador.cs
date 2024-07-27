using System;
using TMPro;
using UnityEngine;

public class Contador : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Referência para o Text UI
    public GameObject objectToDisable; // Referência para o GameObject a ser desativado
    private DateTime startTime;
    private TimeSpan countdownTime = TimeSpan.FromSeconds(30);
    private bool isCounting = false; // Adicionado para verificar se a contagem está ativa

    void OnEnable()
    {
        ResetTimer();
    }

    void Start()
    {
        // Inicializa o contador apenas se ele não estiver sendo reiniciado por OnEnable
        if (!isCounting)
        {
            ResetTimer();
        }
    }

    void Update()
    {
        if (isCounting)
        {
            TimeSpan elapsedTime = DateTime.Now - startTime;

            if (elapsedTime <= countdownTime)
            {
                UpdateTimerUI(countdownTime - elapsedTime);
            }
            else
            {
                UpdateTimerUI(TimeSpan.Zero);
                Debug.Log("Time has run out!");
                objectToDisable.SetActive(false); // Desativa o GameObject
                Time.timeScale = 1;
                isCounting = false; // Desativa a contagem
            }
        }
    }

    void ResetTimer()
    {
        startTime = DateTime.Now;
        isCounting = true; // Ativa a contagem
    }

    void UpdateTimerUI(TimeSpan remainingTime)
    {
        timerText.text = Mathf.CeilToInt((float)remainingTime.TotalSeconds).ToString();
    }
}

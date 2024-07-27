using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectedCard : MonoBehaviour
{
    public GameObject cardsPanel;
    public void CardSelected()
    {
        Time.timeScale = 1.0f;
        EventSystem.current.SetSelectedGameObject(null);
        cardsPanel.SetActive(false);
    }
}

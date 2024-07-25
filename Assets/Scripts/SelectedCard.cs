using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCard : MonoBehaviour
{
    public GameObject cardsPanel;
    public void CardSelected()
    {
        Time.timeScale = 1.0f;
        cardsPanel.SetActive(false);
    }
}

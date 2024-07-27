using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCollectable : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se a colisão foi com um objeto com a tag "Upgrade"
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<GameManager>().upgradePanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}

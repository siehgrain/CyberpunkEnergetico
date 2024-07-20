using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public LightController lightController; // Refer�ncia ao LightController
    public int health = 100;

    void TakeDamage(int damage)
    {
        health -= damage;
        lightController.TakeDamage(); // Chama o m�todo para diminuir a luz
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnergyItem"))
        {
            lightController.CollectEnergyItem(); // Chama o m�todo para aumentar a luz
            Destroy(other.gameObject); // Remove o item de energia
        }
    }
}

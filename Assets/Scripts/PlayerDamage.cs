using UnityEngine;
using UnityEngine.UI;


public class PlayerDamage : MonoBehaviour
{
    public Slider healthSlider;

    PlayerStats stats;

    private void Start()
    {
        healthSlider.value = stats.Vida;
        healthSlider.maxValue = stats.Vida;
    }
    void Update()
    {
        TakeDamage(10f);
    }

    public void TakeDamage(float damage)
    { 
        stats.Vida = damage - stats.Vida;
        healthSlider.value= stats.Vida;
    }
}

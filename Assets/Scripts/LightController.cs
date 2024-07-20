using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightController : MonoBehaviour
{
    [SerializeField] private Light2D playerLight; 
    [SerializeField] private float lightDecreaseRate = 0.1f; 
    [SerializeField] private float damageLightDecrease = 1.0f; 
    [SerializeField] private float energyItemIncrease = 2.0f; 
    [SerializeField] private float minLightRange = 1.0f; 
    [SerializeField] private float maxLightRange = 10.0f; 

    void Update()
    {
        playerLight.pointLightOuterRadius -= lightDecreaseRate * Time.deltaTime;
        playerLight.pointLightOuterRadius = Mathf.Clamp(playerLight.pointLightOuterRadius, minLightRange, maxLightRange);
    }

    public void TakeDamage()
    {
        playerLight.pointLightOuterRadius -= damageLightDecrease;
        playerLight.pointLightOuterRadius = Mathf.Clamp(playerLight.pointLightOuterRadius, minLightRange, maxLightRange);
    }

    public void CollectEnergyItem()
    {
        playerLight.pointLightOuterRadius += energyItemIncrease;
        playerLight.pointLightOuterRadius = Mathf.Clamp(playerLight.pointLightOuterRadius, minLightRange, maxLightRange);
    }
}

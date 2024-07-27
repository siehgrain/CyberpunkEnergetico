using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timeLevel;
    public TMP_Text txt;

    public static bool stopTime;

    void Update()
    {
        if (!stopTime)
        {
            timeLevel += Time.deltaTime;
            txt.text = timeLevel.ToString("TEMPO: 0");
        }
    }
}
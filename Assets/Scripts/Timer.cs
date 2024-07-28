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
            int minutes = Mathf.FloorToInt(timeLevel / 60F);
            int seconds = Mathf.FloorToInt(timeLevel % 60F);
            txt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}

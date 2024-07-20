using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    [Header("Debug")]
    public bool QuitButton;
    public virtual void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                        Application.Quit();
        #endif
    }
}

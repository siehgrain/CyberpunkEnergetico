using UnityEngine;
using UnityEngine.UI;

public class FullscreenToggle : MonoBehaviour
{
    private Toggle fullscreenToggle;

    private void Awake()
    {
        fullscreenToggle = GetComponent<Toggle>();
        // Load the fullscreen setting and set the toggle state accordingly
        bool isFullscreen = PlayerPrefs.GetInt("isFullscreen", 1) == 1;
        fullscreenToggle.isOn = isFullscreen;

        // Apply the saved fullscreen setting
        if (isFullscreen)
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        }
        else
        {
            Screen.SetResolution(960, 540, false);
        }

        // Add listener to the toggle to call Change method when the value changes
        fullscreenToggle.onValueChanged.AddListener(Change);
    }

    public void Change(bool isFullscreen)
    {
        if (isFullscreen)
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        }
        else
        {
            Screen.SetResolution(960, 540, false);
        }
        // Save the fullscreen setting
        PlayerPrefs.SetInt("isFullscreen", isFullscreen ? 1 : 0);
        PlayerPrefs.Save(); // Ensure changes are written to disk
    }
}

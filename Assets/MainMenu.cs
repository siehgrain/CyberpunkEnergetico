using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<Jukebox>().Play("Musica Menu");
    }
}

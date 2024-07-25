using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSave : MonoBehaviour
{

    [Header("Debug")]
    public bool DeleteAllButton;
    private void Start()
    {
        PlayerPrefs.DeleteAll();
    }
}

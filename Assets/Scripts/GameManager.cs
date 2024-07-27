using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UpgradeManager upgradeManager;
    public GameObject upgradePanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        FindObjectOfType<Jukebox>().Play("Musica Ação");
    }

    private void OnApplicationQuit()
    {
        if (upgradeManager != null)
        {
            upgradeManager.ResetUpgrades();
        }
    }
}

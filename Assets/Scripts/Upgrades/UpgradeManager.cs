using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Reflection;

public class UpgradeManager : MonoBehaviour
{
    public List<UpgradeDataSO> upgradeDataList;
    public List<UpgradeDataSO> selectedUpgrades;
    public PlayerStats playerStats;
    public List<TextMeshProUGUI> levelTexts;
    public List<TextMeshProUGUI> descriptionTexts;
    public List<Image> upgradeImages;
    public List<TextMeshProUGUI> NomeText;
    public List<Selectable> cards;
    public GameObject UpgradePanel;

    private Dictionary<string, int> upgradeProgress = new Dictionary<string, int>();

    void Start()
    {
        //SaveDefaultValues();
        FindObjectOfType<Jukebox>().Play("Musica Calma");
    }

    void SelectRandomUpgrades()
    {
        selectedUpgrades = new List<UpgradeDataSO>();
        List<int> usedIndexes = new List<int>();

        while (selectedUpgrades.Count < 3)
        {
            int randomIndex = Random.Range(0, upgradeDataList.Count);
            if (!usedIndexes.Contains(randomIndex))
            {
                selectedUpgrades.Add(upgradeDataList[randomIndex]);
                usedIndexes.Add(randomIndex);
            }
        }

        DisplayUpgradesToPlayer(selectedUpgrades);
    }

    void DisplayUpgradesToPlayer(List<UpgradeDataSO> upgrades)
    {
        FindObjectOfType<Jukebox>().SetMusicVolume("Musica Calma", 1);
        FindObjectOfType<Jukebox>().SetMusicVolume("Musica Ação", 0);
        for (int i = 0; i < upgrades.Count; i++)
        {
            if (i < levelTexts.Count && i < descriptionTexts.Count && i < upgradeImages.Count && i < cards.Count)
            {
                if (upgrades[i].Nivel == 1)
                {
                    levelTexts[i].text = "Novo";
                }
                else
                {
                    levelTexts[i].text = "NV.00" + upgrades[i].Nivel.ToString();
                }
                descriptionTexts[i].text = upgrades[i].Descrição;
                NomeText[i].text = upgrades[i].Nome;
                upgradeImages[i].sprite = upgrades[i].Imagem;

                string methodName = upgrades[i].Metodo;
                int index = i;
                int nivel = upgrades[i].Nivel;
                EventTrigger trigger = cards[i].GetComponent<EventTrigger>();
                if (trigger == null)
                {
                    trigger = cards[i].gameObject.AddComponent<EventTrigger>();
                }
                trigger.triggers.Clear();

                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerClick;
                entry.callback.AddListener((data) => { CallUpgradeMethod(methodName, nivel); });
                trigger.triggers.Add(entry);
            }
        }
    }

    void CallUpgradeMethod(string methodName, int nivel)
    {
        MethodInfo method = this.GetType().GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance);
        if (method != null)
        {
            method.Invoke(this, new object[] { nivel });
            Time.timeScale = 1;
            UpgradePanel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Método não encontrado: " + methodName);
            Time.timeScale = 1;
        }
    }
    private void OnEnable()
    {
        SelectRandomUpgrades();
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        FindObjectOfType<Jukebox>().SetMusicVolume("Musica Calma",0);
        FindObjectOfType<Jukebox>().SetMusicVolume("Musica Ação", 1);
    }

    //void SaveDefaultValues()
    //{
    //    foreach (var upgrade in upgradeDataList)
    //    {
    //        if (!PlayerPrefs.HasKey(upgrade.Nome))
    //        {
    //            PlayerPrefs.SetInt(upgrade.Nome, upgrade.Nivel);
    //        }
    //    }
    //    PlayerPrefs.Save();
    //}

    public void Dano(int Nivel)
    {
        playerStats.ApplyUpgrade("Dano", Nivel);
        upgradeDataList[0].Nivel++;
    }

    public void Dash(int Nivel)
    {
        playerStats.ApplyUpgrade("Dash", Nivel);
        upgradeDataList[1].Nivel++;
    }

    public void Recarga(int Nivel)
    {
        playerStats.ApplyUpgrade("Recarga", Nivel);
        upgradeDataList[2].Nivel++;
    }

    public void Defesa(int Nivel)
    {
        playerStats.ApplyUpgrade("Defesa", Nivel);
        upgradeDataList[3].Nivel++;
    }

    public void CorteEspiral(int Nivel)
    {
        playerStats.ApplyUpgrade("CorteEspiral", Nivel);
        upgradeDataList[4].Nivel++;
    }

    public void FlashBang(int Nivel)
    {
        playerStats.ApplyUpgrade("FlashBang", Nivel);
        upgradeDataList[5].Nivel++;
    }

    public void Coleta(int Nivel)
    {
        playerStats.ApplyUpgrade("Coleta", Nivel);
        upgradeDataList[6].Nivel++;
    }

    public void Projeteis(int Nivel)
    {
        playerStats.ApplyUpgrade("Projeteis", Nivel);
        upgradeDataList[7].Nivel++;
    }

    public void Velocidade(int Nivel)
    {
        playerStats.ApplyUpgrade("Velocidade", Nivel);
        upgradeDataList[8].Nivel++;
    }

    public void Vida(int Nivel)
    {
        playerStats.ApplyUpgrade("Vida", Nivel);
        upgradeDataList[9].Nivel++;
    }

    public void ResetUpgrades()
    {
        for (int i = 0; i < upgradeDataList.Count; i++)
        {
            upgradeDataList[i].Nivel = 1;
            Debug.Log("Reset lvl 1");
        }
    }
}

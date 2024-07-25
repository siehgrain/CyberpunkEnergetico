using System.Collections.Generic;
using UnityEngine;
using TMPro; // Importar TextMeshPro
using UnityEngine.UI; // Importar UI
using UnityEngine.EventSystems; // Importar EventSystems para interfaces de ponteiro
using System.Reflection;

public class UpgradeManager : MonoBehaviour
{
    public List<UpgradeDataSO> upgradeDataList;
    public List<UpgradeDataSO> selectedUpgrades;
    public PlayerStats playerStats;

    // Referências da UI para os cards de upgrade
    public List<TextMeshProUGUI> levelTexts; // TextMeshPro para o nível
    public List<TextMeshProUGUI> descriptionTexts; // TextMeshPro para a descrição
    public List<Image> upgradeImages; // Imagem da UI para o sprite
    public List<TextMeshProUGUI> NomeText; // TextMeshPro para o nível
    public List<Selectable> cards; // Selectables para os upgrades
    public GameObject UpgradePanel; // Selectables para os upgrades

    private Dictionary<string, int> upgradeProgress = new Dictionary<string, int>();

    void Start()
    {
        SelectRandomUpgrades();
        Time.timeScale = 0;
        //SaveDefaultValues();
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

        // Display selected upgrades to the player
        DisplayUpgradesToPlayer(selectedUpgrades);
    }

    void DisplayUpgradesToPlayer(List<UpgradeDataSO> upgrades)
    {
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
                trigger.triggers.Clear(); // Remove any existing triggers

                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerClick;
                entry.callback.AddListener((data) => { CallUpgradeMethod(methodName, nivel); });
                trigger.triggers.Add(entry);
            }
        }
    }

    void CallUpgradeMethod(string methodName, int nivel)
    {
        // Use reflection to call the method by name
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
    //void OnApplicationQuit()
    //{
    //    RestoreDefaultValues();
    //}
    //void RestoreDefaultValues()
    //{
    //    foreach (var upgrade in upgradeDataList)
    //    {
    //        if (PlayerPrefs.HasKey(upgrade.Nome))
    //        {
    //            upgrade.Nivel = PlayerPrefs.GetInt(upgrade.Nome);
    //        }
    //    }
    //}
}

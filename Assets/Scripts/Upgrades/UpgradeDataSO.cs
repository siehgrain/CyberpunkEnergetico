using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUpgradeData", menuName = "Upgrades/UpgradeData")]
public class UpgradeDataSO : ScriptableObject
{
    public string Nome;
    public int Nivel;
    public Sprite Imagem;
    public string Descrição;
    public string Metodo;
}

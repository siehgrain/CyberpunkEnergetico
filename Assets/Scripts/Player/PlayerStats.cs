using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats", order = 1)]
public class PlayerStats : ScriptableObject
{
    public float Vida;
    public float Dano;
    public float Velocidade;
    public int Projeteis;
    public float ColetaSize;
    public float FlashBangSize;
    public float CorteEspiral;
    public int Defesa;
    public float Recarga;
    public float DashRecarga;
    public int DashDamage;

    private float initialVida;
    private float initialDano;
    private float initialVelocidade;
    private int initialProjeteis;
    private float initialColetaSize;
    private float initialFlashBangSize;
    private float initialCorteEspiral;
    private int initialDefesa;
    private float initialRecarga;
    private float initialDashRecarga;
    private int initialDashDamage;

    private void OnEnable()
    {
        SaveInitialValues();
    }

    private void SaveInitialValues()
    {
        initialVida = Vida;
        initialDano = Dano;
        initialVelocidade = Velocidade;
        initialProjeteis = Projeteis;
        initialColetaSize = ColetaSize;
        initialFlashBangSize = FlashBangSize;
        initialCorteEspiral = CorteEspiral;
        initialDefesa = Defesa;
        initialRecarga = Recarga;
        initialDashRecarga = DashRecarga;
        initialDashDamage = DashDamage;
    }

    public void ApplyUpgrade(string upgradeType, int nivel)
    {
        switch (upgradeType)
        {
            case "Dano":
                Dano += nivel + 5;
                Debug.Log("Dano Total: " + Dano);
                break;
            case "Dash":
                DashRecarga += nivel;
                Debug.Log("Dash: " + DashRecarga);
                break;
            case "Recarga":
                Recarga += nivel;
                Debug.Log("Recarga: " + Recarga);
                break;
            case "Defesa":
                Defesa += nivel * 3;
                Debug.Log("Defesa: " + Defesa);
                break;
            case "CorteEspiral":
                CorteEspiral += nivel;
                Debug.Log("CorteEspiral: " + CorteEspiral);
                break;
            case "FlashBang":
                FlashBangSize += nivel;
                Debug.Log("FlashBang: " + FlashBangSize);
                break;
            case "Coleta":
                ColetaSize += nivel;
                Debug.Log("Coleta: " + ColetaSize);
                break;
            case "Projeteis":
                Projeteis += nivel;
                Debug.Log("Projeteis: " + Projeteis);
                break;
            case "Velocidade":
                Velocidade += nivel;
                Debug.Log("Velocidade: " + Velocidade);
                break;
            case "Vida":
                Vida += nivel + 10;
                Debug.Log("Vida: " + Vida);
                break;
            default:
                Debug.LogWarning("Tipo de upgrade não encontrado: " + upgradeType);
                break;
        }
    }

    public void ResetValues()
    {
        Vida = initialVida;
        Dano = initialDano;
        Velocidade = initialVelocidade;
        Projeteis = initialProjeteis;
        ColetaSize = initialColetaSize;
        FlashBangSize = initialFlashBangSize;
        CorteEspiral = initialCorteEspiral;
        Defesa = initialDefesa;
        Recarga = initialRecarga;
        DashRecarga = initialDashRecarga;
        DashDamage = initialDashDamage;
    }
}

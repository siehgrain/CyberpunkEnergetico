using UnityEngine;

public class FogOfWarController : MonoBehaviour
{
    public Light playerLight; // A referência à luz do jogador
    public Material fogOfWarMaterial; // O material do shader de Fog of War

    void Start()
    {
        if (playerLight == null)
        {
            playerLight = GetComponent<Light>();
        }
    }

    void Update()
    {
        // Atualiza a posição e o alcance da luz no material do shader de Fog of War
        Vector3 lightPosition = playerLight.transform.position;
        fogOfWarMaterial.SetVector("_FogCenter", new Vector4(lightPosition.x, lightPosition.y, lightPosition.z, 1));
        fogOfWarMaterial.SetFloat("_FogRange", playerLight.range);
    }
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Light fieldOfViewLight; // Luz que representa o campo de visão do jogador
    public float decreaseAmount = 1f; // Quanto diminuir o campo de visão
    public float minFieldOfView = 5f; // Valor mínimo do campo de visão

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o objeto com o qual colidiu tem a tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DecreaseFieldOfView();
        }
    }

    private void DecreaseFieldOfView()
    {
        if (fieldOfViewLight != null)
        {
            // Diminui o alcance da luz representando o campo de visão
            fieldOfViewLight.range = Mathf.Max(fieldOfViewLight.range - decreaseAmount, minFieldOfView);
        }
    }
}

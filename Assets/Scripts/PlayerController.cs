using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Light fieldOfViewLight; // Luz que representa o campo de vis�o do jogador
    public float decreaseAmount = 1f; // Quanto diminuir o campo de vis�o
    public float minFieldOfView = 5f; // Valor m�nimo do campo de vis�o

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
            // Diminui o alcance da luz representando o campo de vis�o
            fieldOfViewLight.range = Mathf.Max(fieldOfViewLight.range - decreaseAmount, minFieldOfView);
        }
    }
}

using UnityEngine;

public class ResetPositionY : MonoBehaviour
{
    void Start()
    {
        // Garantir que a posi��o Y seja 0 ao iniciar o jogo
        //Vector3 currentPosition = transform.position;
        //currentPosition.y = 0; // Definindo a posi��o Y para 0
        //transform.position = currentPosition; // Aplicando a nova posi��o

        // Caso esteja utilizando um RectTransform (para UI)
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 0);
    }
}

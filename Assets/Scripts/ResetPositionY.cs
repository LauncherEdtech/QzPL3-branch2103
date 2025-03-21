using UnityEngine;

public class ResetPositionY : MonoBehaviour
{
    void Start()
    {
        // Garantir que a posição Y seja 0 ao iniciar o jogo
        //Vector3 currentPosition = transform.position;
        //currentPosition.y = 0; // Definindo a posição Y para 0
        //transform.position = currentPosition; // Aplicando a nova posição

        // Caso esteja utilizando um RectTransform (para UI)
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 0);
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageChanger : MonoBehaviour
{
    // Referência para o componente Image no GameObject
    public Image imageComponent;

    // Referência para o componente TextMeshPro no GameObject
    public TextMeshProUGUI textComponent;

    // Array para armazenar as sprites que você deseja alternar
    public Sprite[] sprites;

    // Array para armazenar os textos correspondentes às imagens
    public string[] texts;

    public GameObject[] gameObjects;

    // Variável para determinar qual imagem mostrar
    private int imageIndex;

    void Start()
    {
        imageIndex = 1;
        // Inicialize a imagem e o texto conforme necessário
        UpdateImageAndText();
    }

    public void SetImage(int index)
    {
        // Define o índice da imagem e atualiza a imagem e o texto
        imageIndex = index;
        UpdateImageAndText();
    }

    void UpdateImageAndText()
    {
        // Verifica se o índice está dentro do intervalo válido
        if (imageIndex >= 1 && imageIndex <= sprites.Length)
        {
            imageComponent.sprite = sprites[imageIndex - 1];
            textComponent.text = texts[imageIndex - 1];
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(i == (imageIndex - 1));
            }
        }
        else
        {
            Debug.LogWarning("Índice de imagem inválido");
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class ImageLoader : MonoBehaviour
{
    public Image imageComponent;  // Referência para o componente Image da UI
    public string imagev;  // Variável para armazenar o link da imagem

    void Start()
    {
        UpdateImage();
    }

    void Update()
    {
        if (imagev != questions.imagev)  // Verifica se o link foi alterado
        {
            imagev = questions.imagev;
            UpdateImage();
        }
    }

    void UpdateImage()
    {
        if (!string.IsNullOrEmpty(imagev) && imagev.StartsWith("http"))
        {
            StartCoroutine(LoadImageFromURL(imagev));
        }
        else
        {
            // Se não for uma URL, pode-se adicionar lógica adicional (caso necessário)
             imageComponent.gameObject.SetActive(false);
        }
    }

    IEnumerator LoadImageFromURL(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Erro ao carregar imagem: " + request.error);
            yield break;
        }

        // Tenta carregar a imagem como textura
        Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        // Defina o sprite da imagem carregada
        imageComponent.sprite = sprite;

        // Ajuste o tamanho do Image para o tamanho da textura
        RectTransform rectTransform = imageComponent.GetComponent<RectTransform>();

        // Limite a largura da imagem para 740
        float maxWidth = 740f;
        float width = texture.width;
        float height = texture.height;

        if (width > maxWidth)
        {
            // Ajuste a largura para o limite e calcule a altura proporcional
            float aspectRatio = height / width;
            width = maxWidth;
            height = width * aspectRatio;
        }

        // Definir o tamanho ajustado
        rectTransform.sizeDelta = new Vector2(width, height);

        // Ativa a imagem
        imageComponent.gameObject.SetActive(true);
    }

}

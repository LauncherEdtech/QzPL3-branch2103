using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private WebCamTexture webCamTexture;

    public void startcamera()
    {
        if (WebCamTexture.devices.Length > 0)
        {
            // Abre a câmera principal (você pode ajustar o índice do dispositivo conforme necessário)
            webCamTexture = new WebCamTexture(WebCamTexture.devices[0].name);
            webCamTexture.Play();
        }
        else
        {
            Debug.LogError("Nenhuma câmera encontrada.");
        }
    }
        // Verifica se a câmera está disponível
  
    

    void Update()
    {
        // Você pode usar a textura da câmera em algum lugar, por exemplo, aplicando-a a um objeto
        if (webCamTexture != null && webCamTexture.isPlaying)
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.mainTexture = webCamTexture;
            }
        }
    }
}

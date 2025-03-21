using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private WebCamTexture webCamTexture;

    public void startcamera()
    {
        if (WebCamTexture.devices.Length > 0)
        {
            // Abre a c�mera principal (voc� pode ajustar o �ndice do dispositivo conforme necess�rio)
            webCamTexture = new WebCamTexture(WebCamTexture.devices[0].name);
            webCamTexture.Play();
        }
        else
        {
            Debug.LogError("Nenhuma c�mera encontrada.");
        }
    }
        // Verifica se a c�mera est� dispon�vel
  
    

    void Update()
    {
        // Voc� pode usar a textura da c�mera em algum lugar, por exemplo, aplicando-a a um objeto
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

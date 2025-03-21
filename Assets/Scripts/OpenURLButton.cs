using UnityEngine;

public class OpenURLButton : MonoBehaviour
{
    public string urlToOpen; // Insira o URL que você deseja abrir aqui.

    public void OpenURL()
    {
        Application.OpenURL(urlToOpen);
    }
}

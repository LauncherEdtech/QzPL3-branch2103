using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Nome da cena a ser carregada (pode ser configurado no Inspector)
    public string sceneName;

    // M�todo para carregar a cena
    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Nome da cena n�o foi definido!");
        }
    }
}

using UnityEngine;

public class ToggleObjects : MonoBehaviour
{
    // Array de GameObjects a serem ativados/desativados
    public GameObject[] objectsToToggle;

    // Fun��o p�blica para alternar o estado de ativa��o
    public void ToggleObjectsState()
    {
        foreach (GameObject obj in objectsToToggle)
        {
            // Alterna o estado de cada objeto
            obj.SetActive(!obj.activeSelf);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Certifique-se de que esta linha está incluída para acessar o componente Button

public class ButtonClickSimulator : MonoBehaviour
{
    public Button buttonB; // Referência ao botão B
    public Button buttonA; // Referência ao botão A

    void Start()
    {
        // Certifique-se de que o botão A tem um componente Button e adicione o listener
        if (buttonA != null)
        {
            buttonA.onClick.AddListener(OnButtonAClick);
        }
        else
        {
            Debug.LogError("Referência para o botão A não está configurada.");
        }
    }

    void OnButtonAClick()
    {
        // Aqui você pode colocar a lógica que deve ser executada quando o botão A é clicado
        Debug.Log("Botão A clicado.");

        // Verifica se o botão B é interativo antes de invocar o clique
        if (buttonB != null && buttonB.interactable)
        {
            buttonB.onClick.Invoke();
            Debug.Log("Clique no botão B simulado.");
        }
        else
        {
            Debug.LogError("Botão B não está configurado ou não é interativo.");
        }
    }
}

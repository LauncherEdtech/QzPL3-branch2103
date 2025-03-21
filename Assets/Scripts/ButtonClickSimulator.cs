using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Certifique-se de que esta linha est� inclu�da para acessar o componente Button

public class ButtonClickSimulator : MonoBehaviour
{
    public Button buttonB; // Refer�ncia ao bot�o B
    public Button buttonA; // Refer�ncia ao bot�o A

    void Start()
    {
        // Certifique-se de que o bot�o A tem um componente Button e adicione o listener
        if (buttonA != null)
        {
            buttonA.onClick.AddListener(OnButtonAClick);
        }
        else
        {
            Debug.LogError("Refer�ncia para o bot�o A n�o est� configurada.");
        }
    }

    void OnButtonAClick()
    {
        // Aqui voc� pode colocar a l�gica que deve ser executada quando o bot�o A � clicado
        Debug.Log("Bot�o A clicado.");

        // Verifica se o bot�o B � interativo antes de invocar o clique
        if (buttonB != null && buttonB.interactable)
        {
            buttonB.onClick.Invoke();
            Debug.Log("Clique no bot�o B simulado.");
        }
        else
        {
            Debug.LogError("Bot�o B n�o est� configurado ou n�o � interativo.");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIcontrolquestoes : MonoBehaviour
{
    public TMP_Dropdown tmpDropdown;

    public GameObject[] firstOptionGameObjects;
    public GameObject[] secondOptionGameObjects;
    public GameObject[] treOptionGameObjects;
    // Start is called before the first frame update
    void Start()
    {
        if (tmpDropdown != null)
        {
            // Adiciona a função OnDropdownValueChanged ao evento onValueChanged do TMP_Dropdown
            tmpDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        }

        // Inicializa o estado dos GameObjects com base na seleção atual
        OnDropdownValueChanged(tmpDropdown.value);
    }

    void OnDropdownValueChanged(int index)
    {

        // Obtém o texto da opção selecionada
        string selectedOption = tmpDropdown.options[index].text;

        // Faz algo com a opção selecionada
        Debug.Log("Opção selecionada: " + selectedOption);

        if (index == 0) // Primeira opção
        {
            SetActiveForGameObjects(firstOptionGameObjects, true);
        }
        else if (index == 1) // Segunda opção
        {
            SetActiveForGameObjects(secondOptionGameObjects, true);
            SetActiveForGameObjects(treOptionGameObjects, false);
        }
        else if (index == 2) // Segunda opção
        {
            SetActiveForGameObjects(treOptionGameObjects, true);
            SetActiveForGameObjects(secondOptionGameObjects, false);
        }
    }

    void SetActiveForGameObjects(GameObject[] gameObjects, bool isActive)
    {
        foreach (GameObject go in gameObjects)
        {
            if (go != null)
            {
                go.SetActive(isActive);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

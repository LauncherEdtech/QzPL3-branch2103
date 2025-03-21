using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Certifique-se de incluir este namespace se estiver usando TextMeshPro
using System;

public class TextSynchronizer : MonoBehaviour
{
    public TextMeshProUGUI textA;
    public TextMeshProUGUI textB;

    void Update()
    {
        if (textA != null && textB != null)
        {
            textB.text = textA.text;  // Sincroniza o texto de A para B
        }
    }
}


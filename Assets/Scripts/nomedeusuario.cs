using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class nomedeusuario : MonoBehaviour
{
    public TextMeshProUGUI userNameText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        userNameText.text = questions.nome.ToString();
    }
}

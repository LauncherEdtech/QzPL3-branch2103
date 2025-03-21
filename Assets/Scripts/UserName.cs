using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserName : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField phoneInput;
    public string celular;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        celular = PlayfabManager.celular;
        if (usernameInput.text == "")
        {
            usernameInput.text = questions.nome;
        }

        if (phoneInput.text == "")
        {
            phoneInput.text = PlayfabManager.celular;
        }
    }
}

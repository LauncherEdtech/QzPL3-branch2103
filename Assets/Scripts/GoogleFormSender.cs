using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoogleFormSender : MonoBehaviour
{
    public TMP_InputField nomeInput;
    public TMP_InputField telefoneInput;
    public TMP_InputField emailInput;


    // Substitua pela URL do seu Google Form
    private string formUrl = "https://docs.google.com/forms/d/e/1FAIpQLScODv72WiAm2QVNPYM1mqqT9Aw7XhFgP15Iy2DrrgdlGcl7vQ/formResponse";

    public void EnviarDados()
    {
        StartCoroutine(EnviarFormulario(nomeInput.text, telefoneInput.text, emailInput.text));
    }

    IEnumerator EnviarFormulario(string nome, string telefone, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.77756378", nome);     // Substitua pelo ID correto do campo "Nome"
        form.AddField("entry.235680497", email);    // Substitua pelo ID correto do campo "E-mail"
        form.AddField("entry.764494663", telefone); // Substitua pelo ID correto do campo "Telefone"
                                                    // form.AddField("entry.889533894", DataNascimento); // Substitua pelo ID correto do campo "Telefone"
                                                    // form.AddField("entry.1036221397", Faculdade); // Substitua pelo ID correto do campo "Telefone"


        using (UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Post(formUrl, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityEngine.Networking.UnityWebRequest.Result.Success)
            {
                Debug.Log("Dados enviados com sucesso!");
            }
            else
            {
                Debug.Log("Erro ao enviar dados: " + www.error);
            }
        }
    }
}

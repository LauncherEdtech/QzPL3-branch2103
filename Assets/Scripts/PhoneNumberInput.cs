using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class PhoneNumberInput : MonoBehaviour
{
    TMP_InputField inputField;

    private void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.onValueChanged.AddListener(ValidatePhoneNumber);
    }

    void ValidatePhoneNumber(string text)
    {
        // Remove todos os caracteres não numéricos do texto usando a função Where.
        string cleanedText = new string(text.ToCharArray().Where(char.IsDigit).ToArray());

        // Certifique-se de que há pelo menos 11 dígitos para corresponder ao padrão brasileiro.
        if (cleanedText.Length >= 11)
        {
            // Formate o número como (XX) XXXXX-XXXX.
            string formattedNumber = string.Format("({0}) {1}-{2}",
                cleanedText.Substring(0, 2),
                cleanedText.Substring(2, 5),
                cleanedText.Substring(7, 4));

            inputField.text = formattedNumber;
        }
        else
        {
            inputField.text = cleanedText; // Se a entrada não for válida, mostre o texto sem formatação.
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizUI : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI contextText;
    public Button[] answerButtons;
    public RawImage questionImage;
    public GameObject pane;

    // Define o tamanho m�ximo para a imagem
    public Vector2 maxImageSize = new Vector2(500, 500);

    public void UpdateQuestionUI(string question, string context, string[] alternatives, Texture2D image = null)
    {
        questionText.text = question;
        contextText.text = context;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i < alternatives.Length)
            {
                answerButtons[i].gameObject.SetActive(true);
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = alternatives[i];
            }
            else
            {
                answerButtons[i].gameObject.SetActive(false); // Esconde bot�es extras
            }
        }

        if (image != null)
        {
            questionImage.gameObject.SetActive(true);
            questionImage.texture = image;

            // Ajustar o tamanho do RawImage com base na propor��o
            float imageWidth = image.width;
            float imageHeight = image.height;

            // Calcular a propor��o para caber no tamanho m�ximo
            float scaleFactor = Mathf.Min(maxImageSize.x / imageWidth, maxImageSize.y / imageHeight);
            questionImage.rectTransform.sizeDelta = new Vector2(imageWidth * scaleFactor, imageHeight * scaleFactor);
        }
        else
        {
            questionImage.gameObject.SetActive(false); // Esconde a imagem se n�o houver
        }
    }
}

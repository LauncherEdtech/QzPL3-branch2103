using UnityEngine;
using UnityEngine.UI;

public class BotaoComSom : MonoBehaviour
{

    public AudioSource som3;

    private void Start()
    {

        som3.Stop();
    }



    public void TocarSom3()
    {
        if (controleui.audioonoff == false)
        {
            // Para qualquer som que esteja tocando
            som3.Stop();

            // Toca o terceiro som
            som3.Play();
        }
    }
}

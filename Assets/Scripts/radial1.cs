using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class radial1 : MonoBehaviour
{
    public int total;

    public int erros1;
    public static int erros;
    public TextMeshProUGUI erro;
    public TextMeshProUGUI matacerto;
    public TextMeshProUGUI lingacerto;
    public TextMeshProUGUI cienacerto;
    public TextMeshProUGUI cieherto;
    public TextMeshProUGUI inglcerto;

    public TextMeshProUGUI literaturacerto;
    public TextMeshProUGUI portuguescerto;
    public TextMeshProUGUI idiomasacerto;
    public TextMeshProUGUI artesacerto;
    public TextMeshProUGUI historiaacerto;
    public TextMeshProUGUI sociologiaacerto;
    public TextMeshProUGUI filosofiaacerto;
    public TextMeshProUGUI biologiaacerto;
    public TextMeshProUGUI fisicaacerto;
    public TextMeshProUGUI geografiaacerto;
    public TextMeshProUGUI quimicaacerto;
    public TextMeshProUGUI matematicaacerto;

    [SerializeField] Image image;

    [SerializeField] float speed;

    float currentValue;

    public float matbar;
    public Image adibar;
    public float matbarc;
    public float matbarcc;

    public float lingbar;
    public Image linbar;
    public float linbarc;
    public float linbarcc;

    public float ciebar;
    public Image cibar;
    public float ciebarc;
    public float ciebarcc;

    public float ciednbar;
    public Image ciedbar;
    public float ciednbarc;
    public float ciednbarcc;

    public float lingesbar;
    public Image linesbar;
    public float linesbarc;
    public float linesbarcc;

    public float literaturabar;
    public Image literaturaimgbar;
    public float literaturabarc;
    public float literaturabarcc;

    public float portuguesbar;
    public Image portuguesimgbar;
    public float portuguesbarc;
    public float portuguesbarcc;

    public float idiomasbar;
    public Image idiomasimgbar;
    public float idiomasbarc;
    public float idiomasbarcc;

    public float artesbar;
    public Image artesimgbar;
    public float artesbarc;
    public float artesbarcc;

    public float historiabar;
    public Image historiaimgbar;
    public float historiabarc;
    public float historiabarcc;

    public float sociologiabar;
    public Image sociologiaimgbar;
    public float sociologiabarc;
    public float sociologiabarcc;

    public float filosofiabar;
    public Image filosofiaimgbar;
    public float filosofiabarc;
    public float filosofiabarcc;

    public float biologiabar;
    public Image biologiaimgbar;
    public float biologiabarc;
    public float biologiabarcc;

    public float fisicabar;
    public Image fisicaimgbar;
    public float fisicabarc;
    public float fisicabarcc;

    public float geografiabar;
    public Image geografiaimgbar;
    public float geografiabarc;
    public float geografiabarcc;

    public float quimicabar;
    public Image quimicaimgbar;
    public float quimicabarc;
    public float quimicabarcc;

    public float matematicabar;
    public Image matematicaimgbar;
    public float matematicabarc;
    public float matematicabarcc;
    void Update()
    {




        matbarc = Matematic.erros;
        matbarcc = Matematic.controlequestion;

        linbarc = linguagens.erros;
        linbarcc = linguagens.controlequestion;

        ciebarc = ciehumanas.erros;
        ciebarcc = ciehumanas.controlequestion;

        ciednbarc = ciedanatureza.erros;
        ciednbarcc = ciedanatureza.controlequestion;

        if (questions.inglespanhol == 1)
        {
            linesbarc = espanhol.erros;
            linesbarcc = espanhol.controlequestion;
        }
        else
        {
            linesbarc = ingles.erros;
            linesbarcc = ingles.controlequestion;
        }
        literaturabarc = linguagens.erros;
        literaturabarcc = linguagens.controlequestion;

        portuguesbarc = portugues.erros;
        portuguesbarcc = portugues.controlequestion;


        idiomasbarc = Idiomas.erros;
        idiomasbarcc = Idiomas.controlequestion;

        artesbarc = artes.erros;
        artesbarcc = artes.controlequestion;

        historiabarc = historia.erros;
        historiabarcc = historia.controlequestion;

        sociologiabarc = sociologia.erros;
        sociologiabarcc = sociologia.controlequestion;

        filosofiabarc = filosofia.erros;
        filosofiabarcc = filosofia.controlequestion;

        fisicabarc = fisica.erros;
        fisicabarcc = fisica.controlequestion;

        geografiabarc = geografia.erros;
        geografiabarcc = geografia.controlequestion;

        quimicabarc = Quimica.erros;
        quimicabarcc = Quimica.controlequestion;

        matematicabarc = Matematic.erros;
        matematicabarcc = Matematic.controlequestion;

        matbar = matbarc / matbarcc;
        lingbar = linbarc / linbarcc;
        ciebar = ciebarc / ciebarcc;
        ciednbar = ciednbarc / ciednbarcc;
        lingesbar = linesbarc / linesbarcc;

        literaturabar = literaturabarc / literaturabarcc;
        portuguesbar = portuguesbarc / portuguesbarcc;

        //erro.text = "Erros: " + erros.ToString();
        erro.text = erros.ToString();
        matacerto.text = "Erros: " + Matematic.erros.ToString();
        lingacerto.text = "Erros: " + linguagens.erros.ToString();
        cienacerto.text = "Erros: " + ciedanatureza.erros.ToString();
        cieherto.text = "Erros: " + ciehumanas.erros.ToString();

        literaturacerto.text = literatura.erros.ToString();
        portuguescerto.text = portugues.erros.ToString();

        idiomasacerto.text = Idiomas.erros.ToString();
        artesacerto.text = artes.erros.ToString();
        historiaacerto.text = historia.erros.ToString();
        sociologiaacerto.text = sociologia.erros.ToString();
        filosofiaacerto.text = filosofia.erros.ToString();
        biologiaacerto.text = biologia.erros.ToString();
        fisicaacerto.text = fisica.erros.ToString();
        geografiaacerto.text = geografia.erros.ToString();
        quimicaacerto.text = Quimica.erros.ToString();
        matematicaacerto.text = Matematic.erros.ToString();

        if (questions.inglespanhol == 1)
        {
            inglcerto.text = "Erros: " + espanhol.erros.ToString();
        }
        else
        {
            inglcerto.text = "Erros: " + ingles.erros.ToString();
        }

        erros = Matematic.erros + Matematic.erros + linguagens.erros + ciedanatureza.erros + ciehumanas.erros + ingles.erros + espanhol.erros + literatura.erros + geografia.erros + portugues.erros + Idiomas.erros + artes.erros + historia.erros + sociologia.erros + filosofia.erros + biologia.erros + fisica.erros + Quimica.erros;
        

        total = Matematic.controlequestion + Matematic.controlequestion + linguagens.controlequestion + ciedanatureza.controlequestion + ciehumanas.controlequestion + ingles.controlequestion + espanhol.controlequestion + literatura.controlequestion + geografia.controlequestion + portugues.controlequestion + Idiomas.controlequestion + artes.controlequestion + historia.controlequestion + sociologia.controlequestion + filosofia.controlequestion + biologia.controlequestion + fisica.controlequestion + Quimica.controlequestion;
        

        if (currentValue < 100)
        {
            currentValue = radial.acertos + erros;

        }
        else 
        {
        
        }
        image.fillAmount = currentValue / (radial.acertos + erros);

        adibar.fillAmount = matbar;
        linbar.fillAmount = lingbar;
        cibar.fillAmount = ciebar;
        ciedbar.fillAmount = ciednbar;
        linesbar.fillAmount = lingesbar;
        //literaturaimgbar.fillAmount = (literatura.acertos + literatura.erros) / (literatura.acertos + literatura.erros);
    }
}

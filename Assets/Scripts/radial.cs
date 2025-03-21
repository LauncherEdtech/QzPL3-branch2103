using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class radial : MonoBehaviour
{
    public TextMeshProUGUI totaltxt;
    //
    public TextMeshProUGUI porcentagemProgressoGeral;
    public float porcentagemProgressoGeralfl;
    //
    public TextMeshProUGUI mat;
    public TextMeshProUGUI ling;
    public TextMeshProUGUI cien;
    public TextMeshProUGUI cieh;
    public TextMeshProUGUI ingesp;

    public TextMeshProUGUI literat;
    public TextMeshProUGUI portugue;
    public TextMeshProUGUI idioma;
    public TextMeshProUGUI arte;
    public TextMeshProUGUI histori;
    public TextMeshProUGUI sociologi;
    public TextMeshProUGUI filosofi;
    public TextMeshProUGUI biologi;
    public TextMeshProUGUI fisic;
    public TextMeshProUGUI geografi;
    public TextMeshProUGUI quimic;
    public TextMeshProUGUI matematic;

    public static int total;
    public float teste;
    public float teste1;
    public float teste2;

    public static int pttotal;
    public float ptteste;
    public float ptteste1;
    public float ptteste2;

    public static int idiomastotal;
    public float idiomasteste;
    public float idiomasteste1;
    public float idiomasteste2;

    public static int artestotal;
    public float artesteste;
    public float artesteste1;
    public float artesteste2;

    public static int historiatotal;
    public float historiateste;
    public float historiateste1;
    public float historiateste2;

    public static int sociologiatotal;
    public float sociologiateste;
    public float sociologiateste1;
    public float sociologiateste2;

    public static int filosofiatotal;
    public float filosofiateste;
    public float filosofiateste1;
    public float filosofiateste2;

    public static int biologiatotal;
    public float biologiateste;
    public float biologiateste1;
    public float biologiateste2;

    public static int fisicatotal;
    public float fisicateste;
    public float fisicateste1;
    public float fisicateste2;

    public static int geografiatotal;
    public float geografiateste;
    public float geografiateste1;
    public float geografiateste2;

    public static int quimicatotal;
    public float quimicateste;
    public float quimicateste1;
    public float quimicateste2;

    public static int matematicatotal;
    public float matematicateste;
    public float matematicateste1;
    public float matematicateste2;

    public int acertos1;
    public static int acertos;
    public TextMeshProUGUI acerto;
    public TextMeshProUGUI matacerto;
    public TextMeshProUGUI lingacerto;
    public TextMeshProUGUI cienacerto;
    public TextMeshProUGUI cieherto;
    public TextMeshProUGUI inglcerto;

    public TextMeshProUGUI literatcerto;
    public TextMeshProUGUI portuguecerto;
    public TextMeshProUGUI idiomascerto;
    public TextMeshProUGUI artescerto;
    public TextMeshProUGUI historiacerto;
    public TextMeshProUGUI sociologiacerto;
    public TextMeshProUGUI filosofiacerto;
    public TextMeshProUGUI biologiacerto;
    public TextMeshProUGUI fisicacerto;
    public TextMeshProUGUI geografiacerto;
    public TextMeshProUGUI quimicacerto;
    public TextMeshProUGUI matematicacerto;

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
    public float porcentagemAcertos;
    public TextMeshProUGUI porcentagemliteratura;

    public float portuguesbar;
    public Image portuguesimgbar;
    public float portuguesbarc;
    public float portuguesbarcc;
    public float ptporcentagemAcertos;
    public TextMeshProUGUI porcentagemportugues;

    public float idiomasbar;
    public Image idiomasimgbar;
    public float idiomasbarc;
    public float idiomasbarcc;
    public float idiomasporcentagemAcertos;
    public TextMeshProUGUI porcentagemidiomas;

    public float artesbar;
    public Image artesimgbar;
    public float artesbarc;
    public float artesbarcc;
    public float artesporcentagemAcertos;
    public TextMeshProUGUI porcentagemartes;

    public float historiabar;
    public Image historiaimgbar;
    public float historiabarc;
    public float historiabarcc;
    public float historiaporcentagemAcertos;
    public TextMeshProUGUI porcentagemhistoria;

    public float sociologiabar;
    public Image sociologiaimgbar;
    public float sociologiabarc;
    public float sociologiabarcc;
    public float sociologiaporcentagemAcertos;
    public TextMeshProUGUI porcentagemsociologia;

    public float filosofiabar;
    public Image filosofiaimgbar;
    public float filosofiabarc;
    public float filosofiabarcc;
    public float filosofiaporcentagemAcertos;
    public TextMeshProUGUI porcentagemfilosofia;

    public float biologiabar;
    public Image biologiaimgbar;
    public float biologiabarc;
    public float biologiabarcc;
    public float biologiaporcentagemAcertos;
    public TextMeshProUGUI porcentagembiologia;

    public float fisicabar;
    public Image fisicaimgbar;
    public float fisicabarc;
    public float fisicabarcc;
    public float fisicaporcentagemAcertos;
    public TextMeshProUGUI porcentagemfisica;

    public float geografiabar;
    public Image geografiaimgbar;
    public float geografiabarc;
    public float geografiabarcc;
    public float geografiaporcentagemAcertos;
    public TextMeshProUGUI porcentagemgeografia;

    public float quimicabar;
    public Image quimicaimgbar;
    public float quimicabarc;
    public float quimicabarcc;
    public float quimicaporcentagemAcertos;
    public TextMeshProUGUI porcentagemquimica;

    public float matematicabar;
    public Image matematicaimgbar;
    public float matematicabarc;
    public float matematicabarcc;
    public float matematicaporcentagemAcertos;
    public TextMeshProUGUI porcentagemmatematica;

    void Update()
    {
        totaltxt.text = (acertos + radial1.erros)  + "/" + total;
        mat.text = "Total de questões: " + Matematic.controlequestion + "/" +(Matematic.acertos + Matematic.erros);
        ling.text = "Total de questões: " + linguagens.controlequestion + "/" + (linguagens.acertos + linguagens.erros);
        cien.text = "Total de questões: " + ciedanatureza.controlequestion + "/" + (ciedanatureza.acertos + ciedanatureza.erros);
        cieh.text = "Total de questões: " + ciehumanas.controlequestion + "/" + (ciehumanas.acertos + ciehumanas.erros);
        literat.text = (literatura.acertos + literatura.erros) + " Questões";
        portugue.text = (portugues.acertos + portugues.erros) + " Questões";
        idioma.text = (Idiomas.acertos + Idiomas.erros) + " Questões";
        arte.text = (artes.acertos + artes.erros) + " Questões";
        histori.text = (historia.acertos + historia.erros) + " Questões";
        sociologi.text = (sociologia.acertos + sociologia.erros) + " Questões";
        filosofi.text = (filosofia.acertos + filosofia.erros) + " Questões";
        biologi.text = (biologia.acertos + biologia.erros) + " Questões";
        fisic.text = (fisica.acertos + fisica.erros) + " Questões";
        geografi.text = (geografia.acertos + geografia.erros) + " Questões";
        quimic.text = (Quimica.acertos + Quimica.erros) + " Questões";
        matematic.text = (Matematic.acertos + Matematic.erros) + " Questões";

        if (questions.inglespanhol == 1)
        {
            ingesp.text = "Total de questões: " + ingles.controlequestion + "/" + (ingles.acertos + ingles.erros);
        }
        else 
        {
            ingesp.text = "Total de questões: " + espanhol.controlequestion + "/" + (espanhol.acertos + espanhol.erros);
        }


        matbarc = Matematic.acertos;
        matbarcc = Matematic.controlequestion;

        linbarc = linguagens.acertos;
        linbarcc = linguagens.controlequestion;

        ciebarc = ciehumanas.acertos;
        ciebarcc = ciehumanas.controlequestion;

        ciednbarc = ciedanatureza.acertos;
        ciednbarcc = ciedanatureza.controlequestion;

        if (questions.inglespanhol == 1)
        {
          linesbarc = espanhol.acertos;
          linesbarcc = espanhol.controlequestion;
        }
        else 
        {
            linesbarc = ingles.acertos;
            linesbarcc = ingles.controlequestion;
        }

        literaturabarc = linguagens.acertos;
        literaturabarcc = linguagens.controlequestion;

        portuguesbarc = portugues.acertos;
        portuguesbarcc = portugues.controlequestion;

        idiomasbarc = Idiomas.acertos;
        idiomasbarcc = Idiomas.controlequestion;

        artesbarc = artes.acertos;
        artesbarcc = artes.controlequestion;

        historiabarc = historia.acertos;
        historiabarcc = historia.controlequestion;

        sociologiabarc = sociologia.acertos;
        sociologiabarcc = sociologia.controlequestion;

        filosofiabarc = filosofia.acertos;
        filosofiabarcc = filosofia.controlequestion;

        biologiabarc = biologia.acertos;
        biologiabarcc = biologia.controlequestion;

        fisicabarc = fisica.acertos;
        fisicabarcc = fisica.controlequestion;

        geografiabarc = geografia.acertos;
        geografiabarcc = geografia.controlequestion;

        quimicabarc = Quimica.acertos;
        quimicabarcc = Quimica.controlequestion;

        matematicabarc = Matematic.acertos;
        matematicabarcc = Matematic.controlequestion;

        matbar = matbarc / matbarcc;
        lingbar = linbarc / linbarcc;
        ciebar = ciebarc / ciebarcc;
        ciednbar = ciednbarc / ciednbarcc;
        lingesbar = linesbarc / linesbarcc;
        literaturabar = literaturabarc / literaturabarcc;
        portuguesbar = portuguesbarc / portuguesbarcc;
        idiomasbar = idiomasbarc / idiomasbarcc;
        artesbar = artesbarc / artesbarcc;
        historiabar = historiabarc / historiabarcc;
        sociologiabar = sociologiabarc / sociologiabarcc;
        filosofiabar = filosofiabarc / filosofiabarcc;
        biologiabar = biologiabarc / biologiabarcc;
        fisicabar = fisicabarc / fisicabarcc;
        geografiabar = geografiabarc / geografiabarcc;
        quimicabar = quimicabarc / quimicabarcc;
        matematicabar = matematicabarc / matematicabarcc;
        //adibar.transform.localScale = new Vector3(matbar, 1, 1);

        //acerto.text = "Acertos: "+acertos.ToString();
        acerto.text = acertos.ToString();
        matacerto.text = "Acertos: " + Matematic.acertos.ToString();
        lingacerto.text = "Acertos: " + linguagens.acertos.ToString();
        cienacerto.text = "Acertos: " + ciedanatureza.acertos.ToString();
        cieherto.text = "Acertos: " + ciehumanas.acertos.ToString();

        literatcerto.text = literatura.acertos.ToString();
        portuguecerto.text = portugues.acertos.ToString();
        idiomascerto.text = Idiomas.acertos.ToString();
        artescerto.text = artes.acertos.ToString();
        historiacerto.text = historia.acertos.ToString();
        sociologiacerto.text = sociologia.acertos.ToString();
        filosofiacerto.text = filosofia.acertos.ToString();
        biologiacerto.text = biologia.acertos.ToString();
        fisicacerto.text = fisica.acertos.ToString();
        geografiacerto.text = geografia.acertos.ToString();
        quimicacerto.text = Quimica.acertos.ToString();
        matematicacerto.text = Matematic.acertos.ToString();

        if (questions.inglespanhol == 1)
        {
            inglcerto.text = "Acertos: " + espanhol.acertos.ToString();
        }
        else
        {
            inglcerto.text = "Acertos: " + ingles.acertos.ToString();
        }

        acertos = Matematic.acertos+ Matematic.acertos + linguagens.acertos + ciedanatureza.acertos + ciehumanas.acertos + ingles.acertos + espanhol.acertos + literatura.acertos + geografia.acertos + portugues.acertos + Idiomas.acertos + artes.acertos + historia.acertos + sociologia.acertos + filosofia.acertos + biologia.acertos + fisica.acertos + Quimica.acertos;

        total = Matematic.controlequestion+ Matematic.controlequestion + linguagens.controlequestion + ciedanatureza.controlequestion + ciehumanas.controlequestion + ingles.controlequestion + espanhol.controlequestion + literatura.controlequestion + geografia.controlequestion + portugues.controlequestion + Idiomas.controlequestion + artes.controlequestion + historia.controlequestion + sociologia.controlequestion + filosofia.controlequestion + biologia.controlequestion + fisica.controlequestion + Quimica.controlequestion;
        

        if (currentValue < 800)
        {
            currentValue = acertos;
        }
        else 
        {
        
        }

        teste = literatura.acertos;
        ptteste = portugues.acertos;
        idiomasteste = Idiomas.acertos;
        artesteste = artes.acertos;
        historiateste = historia.acertos;
        sociologiateste = sociologia.acertos;
        filosofiateste = filosofia.acertos;
        biologiateste = biologia.acertos;
        fisicateste = fisica.acertos;
        geografiateste = geografia.acertos;
        quimicateste = Quimica.acertos;
        matematicateste = Matematic.acertos;

        image.fillAmount = currentValue / (acertos + radial1.erros);

        adibar.fillAmount = matbar;
        linbar.fillAmount = lingbar;
        cibar.fillAmount = ciebar;
        ciedbar.fillAmount = ciednbar;
        linesbar.fillAmount = lingesbar;
        literaturaimgbar.fillAmount = teste / teste1;
        portuguesimgbar.fillAmount = ptteste / ptteste1;
        idiomasimgbar.fillAmount = idiomasteste / idiomasteste1;
        artesimgbar.fillAmount = artesteste / artesteste1;
        historiaimgbar.fillAmount = historiateste / historiateste1;
        sociologiaimgbar.fillAmount = sociologiateste / sociologiateste1;
        filosofiaimgbar.fillAmount = filosofiateste / filosofiateste1;
        biologiaimgbar.fillAmount = biologiateste / biologiateste1;
        fisicaimgbar.fillAmount = fisicateste / fisicateste1;
        geografiaimgbar.fillAmount = geografiateste / geografiateste1;
        quimicaimgbar.fillAmount = quimicateste / quimicateste1;
        matematicaimgbar.fillAmount = matematicateste / matematicateste1;
        teste1 = literatura.acertos + literatura.erros;
        ptteste1 = portugues.acertos + portugues.erros;
        idiomasteste1 = Idiomas.acertos + Idiomas.erros;
        artesteste1 = artes.acertos + artes.erros;
        historiateste1 = historia.acertos + historia.erros;
        sociologiateste1 = sociologia.acertos + sociologia.erros;
        filosofiateste1 = filosofia.acertos + filosofia.erros;
        biologiateste1 = biologia.acertos + biologia.erros;
        fisicateste1 = fisica.acertos + fisica.erros;
        geografiateste1 = geografia.acertos + geografia.erros;
        quimicateste1 = Quimica.acertos + Quimica.erros;
        matematicateste1 = Matematic.acertos + Matematic.erros;


        /*
        porcentagemAcertos = (literatura.acertos / (float)teste1) * 100;
        porcentagemliteratura.text = porcentagemAcertos.ToString("0.0") + "%";

        ptporcentagemAcertos = (portugues.acertos / (float)ptteste1) * 100;  // Certifique-se que a divisão é feita em ponto flutuante
        porcentagemportugues.text = ptporcentagemAcertos.ToString("0.0") + "%";


        idiomasporcentagemAcertos = (Idiomas.acertos / (float)idiomasteste1) * 100;
        porcentagemidiomas.text = idiomasporcentagemAcertos.ToString("0.0") + "%";

        artesporcentagemAcertos = (artes.acertos / (float)artesteste1) * 100;
        porcentagemartes.text = artesporcentagemAcertos.ToString("0.0") + "%";

        historiaporcentagemAcertos = (historia.acertos / (float)historiateste1) * 100;
        porcentagemhistoria.text = historiaporcentagemAcertos.ToString("0.0") + "%";

        sociologiaporcentagemAcertos = (sociologia.acertos / (float)sociologiateste1) * 100;
        porcentagemsociologia.text = sociologiaporcentagemAcertos.ToString("0.0") + "%";

        filosofiaporcentagemAcertos = (filosofia.acertos / (float)filosofiateste1) * 100;
        porcentagemfilosofia.text = filosofiaporcentagemAcertos.ToString("0.0") + "%";

        biologiaporcentagemAcertos = (biologia.acertos / (float)biologiateste1) * 100;
        porcentagembiologia.text = porcentagemAcertos.ToString("0.0") + "%";

        fisicaporcentagemAcertos = (fisica.acertos / (float)fisicateste1) * 100;
        porcentagemfisica.text = fisicaporcentagemAcertos.ToString("0.0") + "%";

        geografiaporcentagemAcertos = (geografia.acertos / (float)geografiateste1) * 100;
        porcentagemgeografia.text = geografiaporcentagemAcertos.ToString("0.0") + "%";

        quimicaporcentagemAcertos = (Quimica.acertos / (float)quimicateste1) * 100;
        porcentagemquimica.text = quimicaporcentagemAcertos.ToString("0.0") + "%";

        matematicaporcentagemAcertos = (Matematic.acertos / (float)matematicateste1) * 100;
        porcentagemmatematica.text = matematicaporcentagemAcertos.ToString("0.0") + "%";
        */
        // Atualizando a porcentagem para Literatura
        porcentagemAcertos = teste1 > 0 ? (literatura.acertos / (float)teste1) * 100 : 0;
        porcentagemliteratura.text = porcentagemAcertos.ToString("0.0") + "%";

        // Atualizando a porcentagem para Português
        ptporcentagemAcertos = ptteste1 > 0 ? (portugues.acertos / (float)ptteste1) * 100 : 0;
        porcentagemportugues.text = ptporcentagemAcertos.ToString("0.0") + "%";

        // Atualizando a porcentagem para Idiomas
        idiomasporcentagemAcertos = idiomasteste1 > 0 ? (Idiomas.acertos / (float)idiomasteste1) * 100 : 0;
        porcentagemidiomas.text = idiomasporcentagemAcertos.ToString("0.0") + "%";

        // Atualizando a porcentagem para Artes
        artesporcentagemAcertos = artesteste1 > 0 ? (artes.acertos / (float)artesteste1) * 100 : 0;
        porcentagemartes.text = artesporcentagemAcertos.ToString("0.0") + "%";

        // Atualizando a porcentagem para História
        historiaporcentagemAcertos = historiateste1 > 0 ? (historia.acertos / (float)historiateste1) * 100 : 0;
        porcentagemhistoria.text = historiaporcentagemAcertos.ToString("0.0") + "%";

        // Atualizando a porcentagem para Sociologia
        sociologiaporcentagemAcertos = sociologiateste1 > 0 ? (sociologia.acertos / (float)sociologiateste1) * 100 : 0;
        porcentagemsociologia.text = sociologiaporcentagemAcertos.ToString("0.0") + "%";

        // Atualizando a porcentagem para Filosofia
        filosofiaporcentagemAcertos = filosofiateste1 > 0 ? (filosofia.acertos / (float)filosofiateste1) * 100 : 0;
        porcentagemfilosofia.text = filosofiaporcentagemAcertos.ToString("0.0") + "%";

        // Atualizando a porcentagem para Biologia
        biologiaporcentagemAcertos = biologiateste1 > 0 ? (biologia.acertos / (float)biologiateste1) * 100 : 0;
        porcentagembiologia.text = biologiaporcentagemAcertos.ToString("0.0") + "%";

        // Atualizando a porcentagem para Física
        fisicaporcentagemAcertos = fisicateste1 > 0 ? (fisica.acertos / (float)fisicateste1) * 100 : 0;
        porcentagemfisica.text = fisicaporcentagemAcertos.ToString("0.0") + "%";

        // Atualizando a porcentagem para Geografia
        geografiaporcentagemAcertos = geografiateste1 > 0 ? (geografia.acertos / (float)geografiateste1) * 100 : 0;
        porcentagemgeografia.text = geografiaporcentagemAcertos.ToString("0.0") + "%";

        // Atualizando a porcentagem para Química
        quimicaporcentagemAcertos = quimicateste1 > 0 ? (Quimica.acertos / (float)quimicateste1) * 100 : 0;
        porcentagemquimica.text = quimicaporcentagemAcertos.ToString("0.0") + "%";

        // Atualizando a porcentagem para Matemática
        matematicaporcentagemAcertos = matematicateste1 > 0 ? (Matematic.acertos / (float)matematicateste1) * 100 : 0;
        porcentagemmatematica.text = matematicaporcentagemAcertos.ToString("0.0") + "%";

        //
        float totalTentativas = acertos + radial1.erros; // Calcula o total de tentativas
        float porcentagemProgressoGeralfl = 0; // Inicializa a variável de porcentagem

        // Verifica se o total de tentativas é maior que zero para evitar divisão por zero
        if (totalTentativas > 0)
        {
            porcentagemProgressoGeralfl = (acertos / totalTentativas) * 100; // Calcula a porcentagem de acertos
        }
        else
        {
            porcentagemProgressoGeralfl = 0; // Se não houve tentativas, a porcentagem de acertos é 0%
        }

        // Atualiza o texto na interface do usuário
        porcentagemProgressoGeral.text = porcentagemProgressoGeralfl.ToString("0.0") + "%";

        //
    }
}

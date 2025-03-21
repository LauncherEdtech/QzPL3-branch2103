
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class questions : MonoBehaviour
{
    public GameObject buttonLAI;

    public GameObject imgbannerprova;

    public static bool assinante;

    public static bool salvar = false;
    public static string nome = "";
    public TextMeshProUGUI nometxt;

    public static bool prova;
    public static int acertosprova;
    public static int errosprova;

    public int moedas;
    public static int vidas = 10;

    public TextMeshProUGUI vidastxt;

    public static string imagev;
    public string imagevc;

    public int points;

    public AudioSource som2;
    public AudioSource som3;

    public PlayfabManager playfabManager;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;

    public TextMeshProUGUI titulotxt;

    //Acaba acima os botoes para o caminho das questoes

    public GameObject answer;
    public Color newColor;
    public Color newColor1;
    public Color normalColor;
    public Color normalColor1;
    public int controle;
    public string rc;
    public string ru;
    public static int materia;
    public int materiaver;
    public static int confirmar;
    public int alternar;
    public static int inglespanhol;

    public static bool display = false;
    public bool errou = false;

    public static bool save = false;

    public GameObject panel;
    public GameObject panelacabou;
    public static bool acabou = false;

    public TextMeshProUGUI moedastxt;
    public TextMeshProUGUI moedastxt1;

    public TextMeshProUGUI questao;
    public TextMeshProUGUI A;
    public TextMeshProUGUI B;
    public TextMeshProUGUI C;
    public TextMeshProUGUI D;
    public TextMeshProUGUI E;
    public TextMeshProUGUI correctAnswer;
    public TextMeshProUGUI entenditxt;
    private literatura literaturaInstance;
    private portugues portuguesInstance;
    private Idiomas IdiomasInstance;
    private artes ArtesInstance;
    private historia HistoriaInstance;
    private sociologia SociologiaInstance;
    private filosofia FilosofiaInstance;
    private biologia BiologiaInstance;
    private fisica FisicaInstance;
    private geografia GeografiaInstance;
    private Quimica QuimicaInstance;
    private Matematic MatematicInstance;

    public ChatG chatScript; // Referência ao script ChatG

    //Dicionario
    Dictionary<Button, string[]> categories = new Dictionary<Button, string[]>();

    void Start()
    {
        if (chatScript == null)
        {
            chatScript = FindObjectOfType<ChatG>(); // Procura automaticamente se não estiver definido
        }
        materia = 1;
        CarregarVidas();
        literaturaInstance = FindObjectOfType<literatura>();
        portuguesInstance = FindObjectOfType<portugues>();
        IdiomasInstance = FindObjectOfType<Idiomas>();
        ArtesInstance = FindObjectOfType<artes>();
        HistoriaInstance = FindObjectOfType<historia>();
        SociologiaInstance = FindObjectOfType<sociologia>();
        FilosofiaInstance = FindObjectOfType<filosofia>();
        BiologiaInstance = FindObjectOfType<biologia>();
        FisicaInstance = FindObjectOfType<fisica>();
        GeografiaInstance = FindObjectOfType<geografia>();
        QuimicaInstance = FindObjectOfType<Quimica>();
        MatematicInstance = FindObjectOfType<Matematic>();
        som2.Stop();
        som3.Stop();
        answer.SetActive(false);
        display = true;
        if (ChangeColors.colorblackwhite == 0)
        {
            button1.GetComponent<Image>().color = normalColor;
            button2.GetComponent<Image>().color = normalColor;
            button3.GetComponent<Image>().color = normalColor;
            button4.GetComponent<Image>().color = normalColor;
            button5.GetComponent<Image>().color = normalColor;
        }
        else
        {
            button1.GetComponent<Image>().color = normalColor1;
            button2.GetComponent<Image>().color = normalColor1;
            button3.GetComponent<Image>().color = normalColor1;
            button4.GetComponent<Image>().color = normalColor1;
            button5.GetComponent<Image>().color = normalColor1;
        }

      
    }

    void Update()
    {
        if (prova == true)
        {
            imgbannerprova.SetActive(true);
        }
        else 
        {
            imgbannerprova.SetActive(false);
        }

        if (vidas < 0) { vidas = 0; }

        if(salvar == true) { SalvarVidas(); }

        materiaver = materia;
        if (acabou == true)
        {
            panelacabou.SetActive(true);
        }
        else
        {
            panelacabou.SetActive(false);
        }

        imagevc = imagev;

        vidastxt.text = vidas.ToString();
        moedastxt.text = moedas.ToString();
        moedastxt1.text = "MOEDAS: " + moedas.ToString();
        if (PlayfabManager.preencheu == true)
        {
            nometxt.text = nome.ToString();
        }
        //moedas = radial.acertos * 5 - radial1.erros * 2;
        moedas = radial.acertos * 5;
        points = moedas;
        controle = points;

        if (confirmar == 1)
        {
            save = true;
            if (rc == ru)
            {
                playfabManager.SaveDailyProgress(1);
                TocarSom2();
                medalhas.controle = medalhas.controle + 1;
                ru = "";
                confirmar = 0;
                errou = true;
                answer.SetActive(true);
                entenditxt.text = "ENTENDI";
                buttonLAI.SetActive(false);
                //StartCoroutine("showcorrect");
                if (prova == true)
                {
                    acertosprova = acertosprova + 1;
                }
                if (rc == "A")
                {
                    button1.GetComponent<Image>().color = newColor1;
                }
                if (rc == "B")
                {
                    button2.GetComponent<Image>().color = newColor1;
                }
                if (rc == "C")
                {
                    button3.GetComponent<Image>().color = newColor1;
                }
                if (rc == "D")
                {
                    button4.GetComponent<Image>().color = newColor1;
                }
                if (rc == "E")
                {
                    button5.GetComponent<Image>().color = newColor1;
                }
                if (materia == 1)
                {
                    matematica.acertos = matematica.acertos + 1;
                    moedas = moedas + 1;
                }
                if (materia == 2)
                {
                    ciehumanas.acertos = ciehumanas.acertos + 1;
                    moedas = moedas + 5;
                }
                if (materia == 3)
                {
                    ciedanatureza.acertos = ciedanatureza.acertos + 1;
                    moedas = moedas + 5;
                }
                if (materia == 4)
                {
                    linguagens.acertos = linguagens.acertos + 1;
                    moedas = moedas + 5;
                }
                if (materia == 5)
                {
                    if (inglespanhol == 0)
                    {
                        ingles.acertos = ingles.acertos + 1;
                        moedas = moedas + 5;

                    }
                    else
                    {
                        espanhol.acertos = espanhol.acertos + 1;
                        moedas = moedas + 5;
                    }

                }
                if (materia == 6)
                {
                    literatura.acertos = literatura.acertos + 1;
                    moedas = moedas + 5;
                }
                if (materia == 7)
                {
                    portugues.acertos = portugues.acertos + 1;
                    moedas = moedas + 5;
                }
                if (materia == 8)
                {
                    Idiomas.acertos = Idiomas.acertos + 1;
                    moedas = moedas + 5;
                }
                if (materia == 9)
                {
                    artes.acertos = artes.acertos + 1;
                    moedas = moedas + 5;
                }
                if (materia == 10)
                {
                    historia.acertos = historia.acertos + 1;
                    moedas = moedas + 5;
                }
                if (materia == 11)
                {
                    sociologia.acertos = sociologia.acertos + 1;
                    moedas = moedas + 5;
                }

                if (materia == 12)
                {
                    filosofia.acertos = filosofia.acertos + 1;
                    moedas = moedas + 5;
                }

                if (materia == 13)
                {
                    biologia.acertos = biologia.acertos + 1;
                    moedas = moedas + 5;
                }
                if (materia == 14)
                {
                    fisica.acertos = fisica.acertos + 1;
                    moedas = moedas + 5;
                }
                if (materia == 15)
                {
                    geografia.acertos = geografia.acertos + 1;
                    moedas = moedas + 5;
                }
                if (materia == 16)
                {
                    Quimica.acertos = Quimica.acertos + 1;

                    moedas = moedas + 5;
                }
                if (materia == 17)
                {
                    global::Matematic.acertos = global::Matematic.acertos + 1;
                    moedas = moedas + 5;
                }
                save = true;
                SalvarVidas();
            }
            else
            {
                if (prova == true)
                {
                    errosprova = errosprova + 1;
                }
                if (assinante == false)
                {
                  vidas = vidas - 1;
                }
                SalvarVidas();
                playfabManager.SaveDailyProgress(1);
                TocarSom3();
                medalhas.controle = 0;
                confirmar = 0;
                errou = true;
                entenditxt.text = "ENTENDI";
                buttonLAI.SetActive(false);
                answer.SetActive(true);
                if (ChangeColors.colorblackwhite == 0)
                {
                    button1.GetComponent<Image>().color = normalColor;
                    button2.GetComponent<Image>().color = normalColor;
                    button3.GetComponent<Image>().color = normalColor;
                    button4.GetComponent<Image>().color = normalColor;
                    button5.GetComponent<Image>().color = normalColor;
                }
                else
                {
                    button1.GetComponent<Image>().color = normalColor1;
                    button2.GetComponent<Image>().color = normalColor1;
                    button3.GetComponent<Image>().color = normalColor1;
                    button4.GetComponent<Image>().color = normalColor1;
                    button5.GetComponent<Image>().color = normalColor1;
                }

                if (rc == "A")
                {
                    button1.GetComponent<Image>().color = newColor1;
                }
                if (rc == "B")
                {
                    button2.GetComponent<Image>().color = newColor1;
                }
                if (rc == "C")
                {
                    button3.GetComponent<Image>().color = newColor1;
                }
                if (rc == "D")
                {
                    button4.GetComponent<Image>().color = newColor1;
                }
                if (rc == "E")
                {
                    button5.GetComponent<Image>().color = newColor1;
                }
                if (ru == "A")
                {
                    button1.GetComponent<Image>().color = newColor;
                }
                if (ru == "B")
                {
                    button2.GetComponent<Image>().color = newColor;
                }
                if (ru == "C")
                {
                    button3.GetComponent<Image>().color = newColor;
                }
                if (ru == "D")
                {
                    button4.GetComponent<Image>().color = newColor;
                }
                if (ru == "E")
                {
                    button5.GetComponent<Image>().color = newColor;
                }
                if (materia == 1)
                {
                    matematica.erros = matematica.erros + 1;

                }
                if (materia == 2)
                {
                    ciehumanas.erros = ciehumanas.erros + 1;

                }
                if (materia == 3)
                {
                    ciedanatureza.erros = ciedanatureza.erros + 1;

                }
                if (materia == 4)
                {
                    linguagens.erros = linguagens.erros + 1;

                }
                if (materia == 5)
                {
                    if (inglespanhol == 0)
                    {
                        ingles.erros = ingles.erros + 1;
                    }
                    else
                    {
                        espanhol.erros = espanhol.erros + 1;
                    }

                }
                if (materia == 6)
                {
                    literatura.erros = literatura.erros + 1;

                }
                if (materia == 7)
                {
                    portugues.erros = portugues.erros + 1;

                }
                if (materia == 8)
                {
                    Idiomas.erros = Idiomas.erros + 1;

                }
                if (materia == 9)
                {
                    artes.erros = artes.erros + 1;

                }
                if (materia == 10)
                {
                    historia.erros = historia.erros + 1;

                }
                if (materia == 11)
                {
                    sociologia.erros = sociologia.erros + 1;

                }
                if (materia == 12)
                {
                    filosofia.erros = filosofia.erros + 1;

                }
                if (materia == 13)
                {
                    biologia.erros = biologia.erros + 1;

                }
                if (materia == 14)
                {
                    fisica.erros = fisica.erros + 1;

                }
                if (materia == 15)
                {
                    geografia.erros = geografia.erros + 1;

                }
                if (materia == 16)
                {
                    Quimica.erros = Quimica.erros + 1;

                }
                if (materia == 17)
                {
                    global::Matematic.erros = global::Matematic.erros + 1;

                }
                save = true;
            }
        }

        if (materia >= 6)
        {
            if (alternar == 1)
            {
                materia = 1;
            }

        }

        #region questaopermateria

        if (materia == 1)
        {
            titulotxt.text = "Matemática";
            questao.text = matematica.aquestion;
            A.text = "A) " + matematica.aanswerA;
            B.text = "B) " + matematica.aanswerB;
            C.text = "C) " + matematica.aanswerC;
            D.text = "D) " + matematica.aanswerD;
            E.text = "E) " + matematica.aanswerE;
            rc = matematica.acorrectAnswer;
            correctAnswer.text = "Explicação da resposta correta: " + matematica.acorrectAnswermessage;
            imagev = matematica.image;
        }
        if (materia == 2)
        {
            titulotxt.text = "Ciências Humanas";
            questao.text = ciehumanas.aquestion;
            A.text = "A) " + ciehumanas.aanswerA;
            B.text = "B) " + ciehumanas.aanswerB;
            C.text = "C) " + ciehumanas.aanswerC;
            D.text = "D) " + ciehumanas.aanswerD;
            E.text = "E) " + ciehumanas.aanswerE;
            rc = ciehumanas.acorrectAnswer;
            correctAnswer.text = "Explicação da resposta correta: " + ciehumanas.acorrectAnswermessage;
            imagev = ciehumanas.image;
        }
        if (materia == 3)
        {
            titulotxt.text = "Ciências da Natureza";
            questao.text = ciedanatureza.aquestion;
            A.text = "A) " + ciedanatureza.aanswerA;
            B.text = "B) " + ciedanatureza.aanswerB;
            C.text = "C) " + ciedanatureza.aanswerC;
            D.text = "D) " + ciedanatureza.aanswerD;
            E.text = "E) " + ciedanatureza.aanswerE;
            rc = ciedanatureza.acorrectAnswer;
            correctAnswer.text = "Explicação da resposta correta: " + ciedanatureza.acorrectAnswermessage;
            imagev = ciedanatureza.image;
        }
        if (materia == 4)
        {
            titulotxt.text = "Linguagens";
            questao.text = linguagens.aquestion;
            A.text = "A) " + linguagens.aanswerA;
            B.text = "B) " + linguagens.aanswerB;
            C.text = "C) " + linguagens.aanswerC;
            D.text = "D) " + linguagens.aanswerD;
            E.text = "E) " + linguagens.aanswerE;
            rc = linguagens.acorrectAnswer;
            correctAnswer.text = "Explicação da resposta correta: " + linguagens.acorrectAnswermessage;
            imagev = linguagens.image;
        }
        if (materia == 5)
        {
            titulotxt.text = "Linguagens";
            if (inglespanhol == 0)
            {

                questao.text = ingles.aquestion;
                A.text = "A) " + ingles.aanswerA;
                B.text = "B) " + ingles.aanswerB;
                C.text = "C) " + ingles.aanswerC;
                D.text = "D) " + ingles.aanswerD;
                E.text = "E) " + ingles.aanswerE;
                rc = ingles.acorrectAnswer;
                correctAnswer.text = "Explicação da resposta correta: " + ingles.acorrectAnswermessage;
                imagev = ingles.image;
            }
            else
            {
                questao.text = espanhol.aquestion;
                A.text = "A) " + espanhol.aanswerA;
                B.text = "B) " + espanhol.aanswerB;
                C.text = "C) " + espanhol.aanswerC;
                D.text = "D) " + espanhol.aanswerD;
                E.text = "E) " + espanhol.aanswerE;
                rc = espanhol.acorrectAnswer;
                correctAnswer.text = "Explicação da resposta correta: " + espanhol.acorrectAnswermessage;
                imagev = espanhol.image;
            }

        }
        if (materia == 6)
        {
            titulotxt.text = literatura.materia + " > " + literatura.vestibular + " > " + literatura.topico + " > " + literatura.subtopico;
            questao.text = literatura.aquestion;
            A.text = "A) " + literatura.aanswerA;
            B.text = "B) " + literatura.aanswerB;
            C.text = "C) " + literatura.aanswerC;
            D.text = "D) " + literatura.aanswerD;
            E.text = "E) " + literatura.aanswerE;
            rc = literatura.acorrectAnswer;
            correctAnswer.text = "Explicação da resposta correta: " + literatura.acorrectAnswermessage;
            imagev = literatura.image;
        }
        if (materia == 7)
        {
            titulotxt.text = portugues.materia + " > " + portugues.vestibular + " > " + portugues.topico + " > " + portugues.subtopico;
            questao.text = portugues.aquestion;
            A.text = "A) " + portugues.aanswerA;
            B.text = "B) " + portugues.aanswerB;
            C.text = "C) " + portugues.aanswerC;
            D.text = "D) " + portugues.aanswerD;
            E.text = "E) " + portugues.aanswerE;
            rc = portugues.acorrectAnswer;
            correctAnswer.text = "Explicação da resposta correta: " + portugues.acorrectAnswermessage;
            imagev = portugues.image;
        }
        if (materia == 8)
        {
            titulotxt.text = Idiomas.materia + " > " + Idiomas.vestibular + " > " + Idiomas.topico + " > " + Idiomas.subtopico;
            questao.text = Idiomas.aquestion;
            A.text = "A) " + Idiomas.aanswerA;
            B.text = "B) " + Idiomas.aanswerB;
            C.text = "C) " + Idiomas.aanswerC;
            D.text = "D) " + Idiomas.aanswerD;
            E.text = "E) " + Idiomas.aanswerE;
            rc = Idiomas.acorrectAnswer;
            correctAnswer.text = "Explicação da resposta correta: " + Idiomas.acorrectAnswermessage;
            imagev = Idiomas.image;
        }
        if (materia == 9)
        {
            titulotxt.text = artes.materia + " > " + artes.vestibular + " > " + artes.topico + " > " + artes.subtopico;
            questao.text = artes.aquestion;
            A.text = "A) " + artes.aanswerA;
            B.text = "B) " + artes.aanswerB;
            C.text = "C) " + artes.aanswerC;
            D.text = "D) " + artes.aanswerD;
            E.text = "E) " + artes.aanswerE;
            rc = artes.acorrectAnswer;
            correctAnswer.text = "Explicação da resposta correta: " + artes.acorrectAnswermessage;
            imagev = artes.image;
        }
        if (materia == 10)
        {
            titulotxt.text = historia.materia + " > " + historia.vestibular + " > " + historia.topico + " > " + historia.subtopico;
            questao.text = historia.aquestion;
            A.text = "A) " + historia.aanswerA;
            B.text = "B) " + historia.aanswerB;
            C.text = "C) " + historia.aanswerC;
            D.text = "D) " + historia.aanswerD;
            E.text = "E) " + historia.aanswerE;
            rc = historia.acorrectAnswer;
            correctAnswer.text = "Explicação da resposta correta: " + historia.acorrectAnswermessage;
            imagev = historia.image;
        }

        if (materia == 11)
        {
            titulotxt.text = sociologia.materia + " > " + sociologia.vestibular + " > " + sociologia.topico + " > " + sociologia.subtopico;
            questao.text = sociologia.aquestion;
            A.text = "A) " + sociologia.aanswerA;
            B.text = "B) " + sociologia.aanswerB;
            C.text = "C) " + sociologia.aanswerC;
            D.text = "D) " + sociologia.aanswerD;
            E.text = "E) " + sociologia.aanswerE;
            rc = sociologia.acorrectAnswer;
            correctAnswer.text = "Explicação da resposta correta: " + sociologia.acorrectAnswermessage;
            imagev = sociologia.image;
        }

        if (materia == 12)
        {
            titulotxt.text = filosofia.materia + " > " + filosofia.vestibular + " > " + filosofia.topico + " > " + filosofia.subtopico;
            questao.text = filosofia.aquestion;
            A.text = "A) " + filosofia.aanswerA;
            B.text = "B) " + filosofia.aanswerB;
            C.text = "C) " + filosofia.aanswerC;
            D.text = "D) " + filosofia.aanswerD;
            E.text = "E) " + filosofia.aanswerE;
            rc = filosofia.acorrectAnswer;
            correctAnswer.text = "Explicação da resposta correta: " + filosofia.acorrectAnswermessage;
            imagev = filosofia.image;
        }

        if (materia == 13)
        {
            titulotxt.text = biologia.materia + " > " + biologia.vestibular + " > " + biologia.topico + " > " + biologia.subtopico;
            questao.text = biologia.aquestion;
            A.text = "A) " + biologia.aanswerA;
            B.text = "B) " + biologia.aanswerB;
            C.text = "C) " + biologia.aanswerC;
            D.text = "D) " + biologia.aanswerD;
            E.text = "E) " + biologia.aanswerE;
            rc = biologia.acorrectAnswer;
            correctAnswer.text = "Explicação da resposta correta: " + biologia.acorrectAnswermessage;
            imagev = biologia.image;
        }

        if (materia == 14)
        {

            titulotxt.text = fisica.materia + " > " + fisica.vestibular + " > " + fisica.topico + " > " + fisica.subtopico;
            questao.text = fisica.aquestion;
            A.text = "A) " + fisica.aanswerA;
            B.text = "B) " + fisica.aanswerB;
            C.text = "C) " + fisica.aanswerC;
            D.text = "D) " + fisica.aanswerD;
            E.text = "E) " + fisica.aanswerE;
            rc = fisica.acorrectAnswer;
            correctAnswer.text = "Explicação da resposta correta: " + fisica.acorrectAnswermessage;
            imagev = fisica.image;
        }

        if (materia == 15)
        {
            titulotxt.text = geografia.materia + " > " + geografia.vestibular + " > " + geografia.topico + " > " + geografia.subtopico;
            questao.text = geografia.aquestion;
            A.text = "A) " + geografia.aanswerA;
            B.text = "B) " + geografia.aanswerB;
            C.text = "C) " + geografia.aanswerC;
            D.text = "D) " + geografia.aanswerD;
            E.text = "E) " + geografia.aanswerE;
            rc = geografia.acorrectAnswer;
            correctAnswer.text = "Explicação da resposta correta: " + geografia.acorrectAnswermessage;
            imagev = geografia.image;
        }

        if (materia == 16)
        {
            titulotxt.text = Quimica.materia + " > " + Quimica.vestibular + " > " + Quimica.topico + " > " + Quimica.subtopico;
            questao.text = Quimica.aquestion;
            A.text = "A) " + Quimica.aanswerA;
            B.text = "B) " + Quimica.aanswerB;
            C.text = "C) " + Quimica.aanswerC;
            D.text = "D) " + Quimica.aanswerD;
            E.text = "E) " + Quimica.aanswerE;
            rc = Quimica.acorrectAnswer;
            correctAnswer.text = "Explicação da resposta correta: " + Quimica.acorrectAnswermessage;
            imagev = Quimica.image;
        }

        if (materia == 17)
        {
            titulotxt.text = global::Matematic.materia + " > " + global::Matematic.vestibular + " > " + global::Matematic.topico + " > " + global::Matematic.subtopico;
             questao.text = global::Matematic.aquestion;
            A.text = "A) " + global::Matematic.aanswerA;
            B.text = "B) " + global::Matematic.aanswerB;
            C.text = "C) " + global::Matematic.aanswerC;
            D.text = "D) " + global::Matematic.aanswerD;
            E.text = "E) " + global::Matematic.aanswerE;
            rc = global::Matematic.acorrectAnswer;
            correctAnswer.text = "Explicação da resposta correta: " + global::Matematic.acorrectAnswermessage;
            imagev = global::Matematic.image;
        }
        #endregion
    }


    public void AskAI()
    {
        if (chatScript != null)
        {
            chatScript.OnSendButtonClick2(); // Chama a função para perguntar à IA
        }
        else
        {
            Debug.LogError("ChatG não foi encontrado!");
        }
    }

    public void AskAIAfterDelay()
    {
        StartCoroutine(WaitAndAskAI());
    }

    private IEnumerator WaitAndAskAI()
    {
        yield return new WaitForSeconds(1f); // Espera 2 segundos
        AskAI(); // Chama a função AskAI após o tempo de espera
    }
    public void colorv()
    {
        if (ChangeColors.colorblackwhite == 0)
        {
            button1.GetComponent<Image>().color = normalColor;
            button2.GetComponent<Image>().color = normalColor;
            button3.GetComponent<Image>().color = normalColor;
            button4.GetComponent<Image>().color = normalColor;
            button5.GetComponent<Image>().color = normalColor;
        }
        else
        {
            button1.GetComponent<Image>().color = normalColor1;
            button2.GetComponent<Image>().color = normalColor1;
            button3.GetComponent<Image>().color = normalColor1;
            button4.GetComponent<Image>().color = normalColor1;
            button5.GetComponent<Image>().color = normalColor1;
        }

    }

    public void entendi()
    {
        StartCoroutine("wait");
        display = true;
        controleui.troca = 1;
    }

    public void pular()
    {
        StartCoroutine("wait");
        StartCoroutine("passar");
        controleui.troca = 1;
    }

    public void Voltar()
    {
        // Atualiza a interface e o controle de troca
        StartCoroutine("wait");
        StartCoroutine("back");
        controleui.troca = 1;
    }

    public void leadboard()
    {
        playfabManager.SendLeaderboard(moedas);
        Debug.Log("send" + points);
    }

    public void atualizename()
    {
        nometxt.text = nome.ToString();
    }

    public void voltarentendi()
    {
        if (errou == true)
        {
            if (ChangeColors.colorblackwhite == 0)
            {
                button1.GetComponent<Image>().color = normalColor;
                button2.GetComponent<Image>().color = normalColor;
                button3.GetComponent<Image>().color = normalColor;
                button4.GetComponent<Image>().color = normalColor;
                button5.GetComponent<Image>().color = normalColor;
            }
            else
            {
                button1.GetComponent<Image>().color = normalColor1;
                button2.GetComponent<Image>().color = normalColor1;
                button3.GetComponent<Image>().color = normalColor1;
                button4.GetComponent<Image>().color = normalColor1;
                button5.GetComponent<Image>().color = normalColor1;
            }

        }
    }
    public void confirm()
    {

        button1.interactable = false;
        button2.interactable = false;
        button3.interactable = false;
        button4.interactable = false;
        button5.interactable = false;

        if (errou == true)
        {
            if (ChangeColors.colorblackwhite == 0)
            {
                button1.GetComponent<Image>().color = normalColor;
                button2.GetComponent<Image>().color = normalColor;
                button3.GetComponent<Image>().color = normalColor;
                button4.GetComponent<Image>().color = normalColor;
                button5.GetComponent<Image>().color = normalColor;
            }
            else
            {
                button1.GetComponent<Image>().color = normalColor1;
                button2.GetComponent<Image>().color = normalColor1;
                button3.GetComponent<Image>().color = normalColor1;
                button4.GetComponent<Image>().color = normalColor1;
                button5.GetComponent<Image>().color = normalColor1;
            }
            #region avan arquest o

            if (materia == 1)
            {
                matematica.control = matematica.control + 1;

            }
            if (materia == 2)
            {
                ciehumanas.control = ciehumanas.control + 1;

            }
            if (materia == 3)
            {
                ciedanatureza.control = ciedanatureza.control + 1;

            }
            if (materia == 4)
            {
                linguagens.control = linguagens.control + 1;

            }
            if (materia == 5)
            {
                if (inglespanhol == 0)
                {
                    ingles.control = ingles.control + 1;
                }
                else
                {
                    espanhol.control = espanhol.control + 1;
                }

            }
            if (materia == 6)
            {
                literaturaInstance.NextQuestion();

            }
            if (materia == 7)
            {
                portuguesInstance.NextQuestion();

            }
            if (materia == 8)
            {
                IdiomasInstance.NextQuestion();

            }
            if (materia == 9)
            {
                ArtesInstance.NextQuestion();

            }
            if (materia == 10)
            {
                HistoriaInstance.NextQuestion();

            }
            if (materia == 11)
            {
                SociologiaInstance.NextQuestion();

            }
            if (materia == 12)
            {
                FilosofiaInstance.NextQuestion();

            }
            if (materia == 13)
            {
                BiologiaInstance.NextQuestion();

            }
            if (materia == 14)
            {
                FisicaInstance.NextQuestion();

            }
            if (materia == 15)
            {
                GeografiaInstance.NextQuestion();

            }
            if (materia == 16)
            {
                QuimicaInstance.NextQuestion();

            }
            if (materia == 17)
            {
                MatematicInstance.NextQuestion();

            }

            if (alternar == 1)
            {
                materia = materia + 1;
            }
            save = true;
            #endregion

            controleui.troca = 1;
            StartCoroutine("wait");
        }
        else
        {
            confirmar = 1;

        }
    }



    public void CallConfirmTwice()
    {
        StartCoroutine(ConfirmRoutine());
    }

    private IEnumerator ConfirmRoutine()
    {
        confirm(); // Chama a primeira vez
        yield return new WaitForSeconds(0.5f); // Espera 1 segundo
        confirm(); // Chama a segunda vez
    }



    public void TocarSom2()
    {
        if (controleui.audioonoff == false)
        {

            // Para qualquer som que esteja tocando
            som2.Stop();

            // Toca o segundo som
            som2.Play();
        }
    }

    public void TocarSom3()
    {
        if (controleui.audioonoff == false) // Verifica se o som est  ativado
        {
            som3.Stop();
            som3.Play();
        }
    }


    public static void AtualizarSom()
    {
        if (controleui.audioonoff == true) // Se o som estiver desligado
        {
            // Para os sons
            GameObject obj = GameObject.Find("GameManager"); // Ajuste para o nome correto do objeto onde est  `questions`
            if (obj != null)
            {
                questions q = obj.GetComponent<questions>();
                if (q != null)
                {
                    q.som2.Stop();
                    q.som3.Stop();
                }
            }
        }
    }


    #region Selecionando resposta do usuario e a materia 

    public void a()
    {
        ru = "A";
    }

    public void b()
    {
        ru = "B";
    }

    public void c()
    {
        ru = "C";
    }

    public void d()
    {
        ru = "D";
    }

    public void e()
    {
        ru = "E";
    }

    public void alter()
    {
        alternar = 1;
        materia = UnityEngine.Random.Range(1, 5);
    }
    public void mat()
    {
        materia = 1;
        alternar = 0;
    }

    public void ciehuman()
    {
        materia = 2;
        alternar = 0;
    }

    public void ciedanat()
    {
        materia = 3;
        alternar = 0;
    }

    public void ling()
    {
        materia = 4;
        alternar = 0;
    }

    public void ingl()
    {
        materia = 5;
        alternar = 0;
        inglespanhol = 0;
    }

    public void espanh()
    {
        materia = 5;
        alternar = 0;
        inglespanhol = 1;
    }

    public void literat()
    {
        materia = 6;
        alternar = 0;
    }

    public void portugue()
    {
        materia = 7;
        alternar = 0;
    }

    public void idioma()
    {
        materia = 8;
        alternar = 0;
    }

    public void Artes()
    {
        materia = 9;
        alternar = 0;
    }

    public void Histori()
    {
        materia = 10;
        alternar = 0;
    }

    public void Sociologi()
    {
        materia = 11;
        alternar = 0;
    }

    public void Filosofi()
    {
        materia = 12;
        alternar = 0;
    }

    public void Biologia()
    {
        materia = 13;
        alternar = 0;
    }
    public void Fisica()
    {
        materia = 14;
        alternar = 0;
    }
    public void Geografia()
    {
        materia = 15;
        alternar = 0;
    }
    public void Quimic()
    {
        materia = 16;
        alternar = 0;
    }
    public void Matematic()
    {
        materia = 17;
        alternar = 0;
    }

    #endregion

    IEnumerator back()
    {
        yield return new WaitForSeconds(1f);
        if (materia == 1)
        {
            if (matematica.control > 0)
                matematica.control--;
        }
        if (materia == 2)
        {
            if (ciehumanas.control > 0)
                ciehumanas.control--;
        }
        if (materia == 3)
        {
            if (ciedanatureza.control > 0)
                ciedanatureza.control--;
        }
        if (materia == 4)
        {
            if (linguagens.control > 0)
                linguagens.control--;
        }
        if (materia == 5)
        {
            if (inglespanhol == 0)
            {
                if (ingles.control > 0)
                    ingles.control--;
            }
            else
            {
                if (espanhol.control > 0)
                    espanhol.control--;
            }
        }
        if (materia == 6)
        {
            if (literatura.control > 0)
                literatura.control--;
            literaturaInstance.PreviousQuestion();
        }
        if (materia == 7)
        {
            if (portugues.control > 0)
                portugues.control--;
            portuguesInstance.PreviousQuestion();
        }
        if (materia == 8)
        {
            if (Idiomas.control > 0)
                Idiomas.control--;
            IdiomasInstance.PreviousQuestion();
        }
        if (materia == 9)
        {
            if (Idiomas.control > 0)
                Idiomas.control--;
            ArtesInstance.PreviousQuestion();
        }
        if (materia == 10)
        {
            if (historia.control > 0)
                historia.control--;
            HistoriaInstance.PreviousQuestion();
        }
        if (materia == 11)
        {
            if (sociologia.control > 0)
                sociologia.control--;
            SociologiaInstance.PreviousQuestion();
        }
        if (materia == 12)
        {
            if (filosofia.control > 0)
                filosofia.control--;
            FilosofiaInstance.PreviousQuestion();
        }
        if (materia == 13)
        {
            if (biologia.control > 0)
                biologia.control--;
            BiologiaInstance.PreviousQuestion();
        }
        if (materia == 14)
        {
            if (fisica.control > 0)
                fisica.control--;
            FisicaInstance.PreviousQuestion();
        }
        if (materia == 15)
        {
            if (geografia.control > 0)
                geografia.control--;
            GeografiaInstance.PreviousQuestion();
        }
        if (materia == 16)
        {
            if (Quimica.control > 0)
                Quimica.control--;
            QuimicaInstance.PreviousQuestion();
        }
        if (materia == 17)
        {
            if (global::Matematic.control > 0)
                global::Matematic.control--;
            MatematicInstance.PreviousQuestion();
        }
    }
        IEnumerator passar()
    {
        yield return new WaitForSeconds(1f);
        if (materia == 1)
        {
            matematica.control = matematica.control + 1;

        }
        if (materia == 2)
        {
            ciehumanas.control = ciehumanas.control + 1;

        }
        if (materia == 3)
        {
            ciedanatureza.control = ciedanatureza.control + 1;

        }
        if (materia == 4)
        {
            linguagens.control = linguagens.control + 1;

        }
        if (materia == 5)
        {
            if (inglespanhol == 0)
            {
                ingles.control = ingles.control + 1;
            }
            else
            {
                espanhol.control = espanhol.control + 1;
            }
        }
        if (materia == 6)
        {
            literatura.control = literatura.control + 1;

        }
        if (materia == 7)
        {
            portugues.control = portugues.control + 1;

        }
        if (materia == 8)
        {
            Idiomas.control = Idiomas.control + 1;

        }
        if (materia == 9)
        {
            Idiomas.control = Idiomas.control + 1;

        }
        if (materia == 10)
        {
            historia.control = historia.control + 1;

        }
        if (materia == 11)
        {
            sociologia.control = sociologia.control + 1;

        }
        if (materia == 12)
        {
            filosofia.control = filosofia.control + 1;

        }
        if (materia == 13)
        {
            biologia.control = biologia.control + 1;

        }
        if (materia == 14)
        {
            fisica.control = fisica.control + 1;

        }
        if (materia == 15)
        {
            geografia.control = geografia.control + 1;

        }
        if (materia == 16)
        {
            Quimica.control = Quimica.control + 1;

        }
        if (materia == 17)
        {
            global::Matematic.control = global::Matematic.control + 1;

        }

        if (materia == 6)
        {
            literaturaInstance.NextQuestion();

        }
        if (materia == 7)
        {
            portuguesInstance.NextQuestion();

        }
        if (materia == 8)
        {
            IdiomasInstance.NextQuestion();

        }
        if (materia == 9)
        {
            ArtesInstance.NextQuestion();

        }
        if (materia == 10)
        {
            HistoriaInstance.NextQuestion();

        }
        if (materia == 11)
        {
            SociologiaInstance.NextQuestion();

        }
        if (materia == 12)
        {
            FilosofiaInstance.NextQuestion();

        }
        if (materia == 13)
        {
            BiologiaInstance.NextQuestion();

        }
        if (materia == 14)
        {
            FisicaInstance.NextQuestion();

        }
        if (materia == 15)
        {
            GeografiaInstance.NextQuestion();

        }
        if (materia == 16)
        {
            QuimicaInstance.NextQuestion();

        }
        if (materia == 17)
        {
            MatematicInstance.NextQuestion();

        }

    }


    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        entenditxt.text = "RESPONDER";
        buttonLAI.SetActive(true);
        panel.SetActive(true);
        display = true;
        answer.SetActive(false);
        errou = false;
        button1.interactable = true;
        button2.interactable = true;
        button3.interactable = true;
        button4.interactable = true;
        button5.interactable = true;
        StartCoroutine("wait1");
        panel.SetActive(false);
    }

    IEnumerator wait1()
    {
        yield return new WaitForSeconds(0.2f);
        panel.SetActive(true);
        display = false;
        StartCoroutine("wait3");
    }

    IEnumerator wait3()
    {
        yield return new WaitForSeconds(0.2f);
        panel.SetActive(true);
    }

    public void logout()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void acabouquestoes()
    {
        acabou = false;
    }

    public void resetaresalvar()
    {
        tarefas.hdomingo1 = "";
        tarefas.tdomingo1 = "";

        tarefas.hdomingo2 = "";
        tarefas.tdomingo2 = "";

        tarefas.hdomingo3 = "";
        tarefas.tdomingo3 = "";

        tarefas.hdomingo4 = "";
        tarefas.tdomingo4 = "";

        tarefas.hdomingo5 = "";
        tarefas.tdomingo5 = "";

        tarefas.hdomingo6 = "";
        tarefas.tdomingo6 = "";
        tarefas.domingo = 0;

        tarefas.sabado = 0;
        tarefas.hsabado1 = "";
        tarefas.tsabado1 = "";

        tarefas.hsabado2 = "";
        tarefas.tsabado2 = "";

        tarefas.hsabado3 = "";
        tarefas.tsabado3 = "";

        tarefas.hsabado4 = "";
        tarefas.tsabado4 = "";

        tarefas.hsabado5 = "";
        tarefas.tsabado5 = "";

        tarefas.hsabado6 = "";
        tarefas.tsabado6 = "";

        tarefas.sexta = 0;
        tarefas.hsexta1 = "";
        tarefas.tsexta1 = "";

        tarefas.hsexta2 = "";
        tarefas.tsexta2 = "";

        tarefas.hsexta3 = "";
        tarefas.tsexta3 = "";

        tarefas.hsexta4 = "";
        tarefas.tsexta4 = "";

        tarefas.hsexta5 = "";
        tarefas.tsexta5 = "";

        tarefas.hsexta6 = "";
        tarefas.tsexta6 = "";

        tarefas.hquarta1 = "";
        tarefas.tquarta1 = "";

        tarefas.hquarta2 = "";
        tarefas.tquarta2 = "";

        tarefas.hquarta3 = "";
        tarefas.tquarta3 = "";

        tarefas.hquarta4 = "";
        tarefas.tquarta4 = "";

        tarefas.hquarta5 = "";
        tarefas.tquarta5 = "";

        tarefas.hquarta6 = "";
        tarefas.tquarta6 = "";

        tarefas.quarta = 0;

        tarefas.hquinta1 = "";
        tarefas.tquinta1 = "";

        tarefas.hquinta2 = "";
        tarefas.tquinta2 = "";

        tarefas.hquinta3 = "";
        tarefas.tquinta3 = "";

        tarefas.hquinta4 = "";
        tarefas.tquinta4 = "";

        tarefas.hquinta5 = "";
        tarefas.tquinta5 = "";

        tarefas.hquinta6 = "";
        tarefas.tquinta6 = "";

        tarefas.quinta = 0;

        tarefas.hterca1 = "";
        tarefas.tterca1 = "";

        tarefas.hterca2 = "";
        tarefas.tterca2 = "";

        tarefas.hterca3 = "";
        tarefas.tterca3 = "";

        tarefas.hterca4 = "";
        tarefas.tterca4 = "";

        tarefas.hterca5 = "";
        tarefas.tterca5 = "";

        tarefas.hterca6 = "";
        tarefas.tterca6 = "";

        tarefas.terca = 0;

        tarefas.hsegunda1 = "";
        tarefas.tsegunda1 = "";

        tarefas.hsegunda2 = "";
        tarefas.tsegunda2 = "";

        tarefas.hsegunda3 = "";
        tarefas.tsegunda3 = "";

        tarefas.hsegunda4 = "";
        tarefas.tsegunda4 = "";

        tarefas.hsegunda5 = "";
        tarefas.tsegunda5 = "";

        tarefas.hsegunda6 = "";
        tarefas.tsegunda6 = "";

        medalhas.medalha2sg = 0;
        medalhas.medalha4sg = 0;
        medalhas.medalhaTdsMtrs = 0;
        medalhas.medalha10questions = 0;
        medalhas.medalha10questionsTdsMtrs = 0;
        medalhas.medalhafinal = 0;

        tarefas.segunda = 0;

        matematica.control = 0;
        matematica.acertos = 0;
        matematica.erros = 0;

        ciehumanas.control = 0;
        ciedanatureza.control = 0;
        linguagens.control = 0;
        ingles.control = 0;
        espanhol.control = 0;

        ciehumanas.acertos = 0;
        ciedanatureza.acertos = 0;
        linguagens.acertos = 0;
        ingles.acertos = 0;
        espanhol.acertos = 0;

        ciehumanas.erros = 0;
        ciedanatureza.erros = 0;
        linguagens.erros = 0;
        ingles.erros = 0;
        espanhol.erros = 0;
        questions.inglespanhol = 0;
        save = true;
    }

    public void deletaresalvar()
    {
        PlayfabManager.celular = "";
        controleui.apagouconta = true;

        tarefas.hdomingo1 = "";
        tarefas.tdomingo1 = "";

        tarefas.hdomingo2 = "";
        tarefas.tdomingo2 = "";

        tarefas.hdomingo3 = "";
        tarefas.tdomingo3 = "";

        tarefas.hdomingo4 = "";
        tarefas.tdomingo4 = "";

        tarefas.hdomingo5 = "";
        tarefas.tdomingo5 = "";

        tarefas.hdomingo6 = "";
        tarefas.tdomingo6 = "";
        tarefas.domingo = 0;

        tarefas.sabado = 0;
        tarefas.hsabado1 = "";
        tarefas.tsabado1 = "";

        tarefas.hsabado2 = "";
        tarefas.tsabado2 = "";

        tarefas.hsabado3 = "";
        tarefas.tsabado3 = "";

        tarefas.hsabado4 = "";
        tarefas.tsabado4 = "";

        tarefas.hsabado5 = "";
        tarefas.tsabado5 = "";

        tarefas.hsabado6 = "";
        tarefas.tsabado6 = "";

        tarefas.sexta = 0;
        tarefas.hsexta1 = "";
        tarefas.tsexta1 = "";

        tarefas.hsexta2 = "";
        tarefas.tsexta2 = "";

        tarefas.hsexta3 = "";
        tarefas.tsexta3 = "";

        tarefas.hsexta4 = "";
        tarefas.tsexta4 = "";

        tarefas.hsexta5 = "";
        tarefas.tsexta5 = "";

        tarefas.hsexta6 = "";
        tarefas.tsexta6 = "";

        tarefas.hquarta1 = "";
        tarefas.tquarta1 = "";

        tarefas.hquarta2 = "";
        tarefas.tquarta2 = "";

        tarefas.hquarta3 = "";
        tarefas.tquarta3 = "";

        tarefas.hquarta4 = "";
        tarefas.tquarta4 = "";

        tarefas.hquarta5 = "";
        tarefas.tquarta5 = "";

        tarefas.hquarta6 = "";
        tarefas.tquarta6 = "";

        tarefas.quarta = 0;

        tarefas.hquinta1 = "";
        tarefas.tquinta1 = "";

        tarefas.hquinta2 = "";
        tarefas.tquinta2 = "";

        tarefas.hquinta3 = "";
        tarefas.tquinta3 = "";

        tarefas.hquinta4 = "";
        tarefas.tquinta4 = "";

        tarefas.hquinta5 = "";
        tarefas.tquinta5 = "";

        tarefas.hquinta6 = "";
        tarefas.tquinta6 = "";

        tarefas.quinta = 0;

        tarefas.hterca1 = "";
        tarefas.tterca1 = "";

        tarefas.hterca2 = "";
        tarefas.tterca2 = "";

        tarefas.hterca3 = "";
        tarefas.tterca3 = "";

        tarefas.hterca4 = "";
        tarefas.tterca4 = "";

        tarefas.hterca5 = "";
        tarefas.tterca5 = "";

        tarefas.hterca6 = "";
        tarefas.tterca6 = "";

        tarefas.terca = 0;

        tarefas.hsegunda1 = "";
        tarefas.tsegunda1 = "";

        tarefas.hsegunda2 = "";
        tarefas.tsegunda2 = "";

        tarefas.hsegunda3 = "";
        tarefas.tsegunda3 = "";

        tarefas.hsegunda4 = "";
        tarefas.tsegunda4 = "";

        tarefas.hsegunda5 = "";
        tarefas.tsegunda5 = "";

        tarefas.hsegunda6 = "";
        tarefas.tsegunda6 = "";

        medalhas.medalha2sg = 0;
        medalhas.medalha4sg = 0;
        medalhas.medalhaTdsMtrs = 0;
        medalhas.medalha10questions = 0;
        medalhas.medalha10questionsTdsMtrs = 0;
        medalhas.medalhafinal = 0;

        tarefas.segunda = 0;

        matematica.control = 0;
        matematica.acertos = 0;
        matematica.erros = 0;

        ciehumanas.control = 0;
        ciedanatureza.control = 0;
        linguagens.control = 0;
        ingles.control = 0;
        espanhol.control = 0;

        ciehumanas.acertos = 0;
        ciedanatureza.acertos = 0;
        linguagens.acertos = 0;
        ingles.acertos = 0;
        espanhol.acertos = 0;

        ciehumanas.erros = 0;
        ciedanatureza.erros = 0;
        linguagens.erros = 0;
        ingles.erros = 0;
        espanhol.erros = 0;
        questions.inglespanhol = 0;
        save = true;
    }

    public void cor()
    {
        button1.GetComponent<Image>().color = normalColor;
        button2.GetComponent<Image>().color = normalColor;
        button3.GetComponent<Image>().color = normalColor;
        button4.GetComponent<Image>().color = normalColor;
        button5.GetComponent<Image>().color = normalColor;
    }
    public void cor1()
    {
        button1.GetComponent<Image>().color = normalColor1;
        button2.GetComponent<Image>().color = normalColor1;
        button3.GetComponent<Image>().color = normalColor1;
        button4.GetComponent<Image>().color = normalColor1;
        button5.GetComponent<Image>().color = normalColor1;
    }

    public static void SalvarVidas()
    {
        PlayerPrefs.SetInt("Vidas", vidas);
        PlayerPrefs.Save(); // Garante que os dados s o gravados
        salvar = false;
    }


    public static void CarregarVidas()
    {
        // Recupera o valor de "Vidas", se n o existir, retorna 10 como padr o
        vidas = PlayerPrefs.GetInt("Vidas", 10);
    }

    public static void Assinar()
    {
        assinante = true;
    }

    public static void CancelarAssinar()
    {
        assinante = false;
    }

    public static void ProvaFalse()
    {
        prova = false;
    }
}
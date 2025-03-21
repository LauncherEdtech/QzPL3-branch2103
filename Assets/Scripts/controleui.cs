using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;

public class controleui : MonoBehaviour
{

    public static bool lai = false;
    public GameObject panelLai;

    public GameObject panelquestoes;
    public static bool apagouconta = false;
    public GameObject perfileditar;


    public GameObject deletepanel;

    public GameObject apagardados;

    public GameObject panelcorwhite;
    public GameObject panelcorblack;

    public GameObject menu;
    public GameObject dashboard;
    public GameObject leadboard;

    public static bool audioonoff;
    public GameObject audioon;
    public GameObject audiooff;

    public TextMeshProUGUI dataText;
    private Animator anim;
    public static string controle;
    public static string system;
    public string syste;

    public GameObject perfil;
    public GameObject voltar;

    public GameObject login;
    public GameObject nameWindow;
    public GameObject loginWindow;

    public GameObject objcelular;
    public GameObject objlingestran;

    public GameObject inglesobj;
    public GameObject espanholobj;

    public GameObject inglesbutton;
    public GameObject espanholbutton;
    public TextMeshProUGUI ingesp;

    public GameObject filtro;
    public GameObject menufiltro;

    public static int days;

    public static int troca;

    public GameObject[] objetosParaControlar;

    public List<ScrollRect> scrollViews;

    // Start is called before the first frame update
    void Start()
    {
        apagardados.SetActive(false);
        deletepanel.SetActive(false);
        anim = GetComponent<Animator>();
        controle = "login";
        nameWindow.SetActive(false);
        ResetYPositionToZeroForAllScrollViews();
        perfileditar.SetActive(false);
        //audioonoff = true;

        // Carrega o estado do áudio salvo (padrão: 1 = sem som)
        audioonoff = PlayerPrefs.GetInt("audioonoff", 1) == 1;

        // Aplica a configuração na interface
        if (audioonoff)
        {
            audiooff.SetActive(true);
            audioon.SetActive(false);
        }
        else
        {
            audioon.SetActive(true);
            audiooff.SetActive(false);
        }



    }

    // Update is called once per frame
    void Update()
    {

        if(lai == true) { panelLai.SetActive(true); lai = false; }
        if (questions.assinante)
        {
            // Desativa os objetos
            AlterarEstadoObjetos(false);
        }
        else
        {
            // Ativa os objetos
            AlterarEstadoObjetos(true);
        }

        if (ChangeColors.colorblackwhite == 0) 
        {
            panelcorwhite.SetActive(false);
            panelcorblack.SetActive(true);
        }
        else 
        {
            panelcorblack.SetActive(false);
            panelcorwhite.SetActive(true);
        }

        if (audioonoff == true)
        {
           audiooff.SetActive(true);
            audioon.SetActive(false);
        }
        else
        {
            audioon.SetActive(true);
            audiooff.SetActive(false);
        }

        if (troca == 1)
        {
            anim.SetBool("quiz1", true);
            StartCoroutine("click");
            troca = 0;
        }
        if (days == 0) { dataText.text = "Segunda"; }
        if (days == 1) { dataText.text = "Terça"; }
        if (days == 2) { dataText.text = "Quarta"; }
        if (days == 3) { dataText.text = "Quinta"; }
        if (days == 4) { dataText.text = "Sexta"; }
        if (days == 5) { dataText.text = "Sábado"; }
        if (days == 6) { dataText.text = "Domingo"; }

        if (days < 0) { days = 6; }
        if (days > 6) { days = 0; }

        if (questions.inglespanhol == 0)
        {
            inglesobj.SetActive(true);
            espanholobj.SetActive(false);
            inglesbutton.SetActive(true);
            espanholbutton.SetActive(false);
            ingesp.text = "Inglês";

        }
        else 
        {
            inglesobj.SetActive(false);
            espanholobj.SetActive(true);
            inglesbutton.SetActive(false);
            espanholbutton.SetActive(true);
            ingesp.text = "Espanhol";
        }

        if (controle == "login")
        {
            perfil.SetActive(true);
            voltar.SetActive(false);
        }

        if (controle == "inicio") 
        {
            perfil.SetActive(true);
            voltar.SetActive(false);
        }
    
        if (controle == "quiz")
        {
            perfil.SetActive(false);
            voltar.SetActive(true);
        }

    }

    private void AlterarEstadoObjetos(bool estado)
    {
        foreach (GameObject objeto in objetosParaControlar)
        {
            if (objeto != null)
            {
                objeto.SetActive(estado);
            }
        }
    }

    public void aaudioon()
    {
        audioonoff = false;
        PlayerPrefs.SetInt("audioonoff", 0); // 0 = som ativado
        PlayerPrefs.Save(); // Salva a mudança permanentemente
                            
        questions.AtualizarSom();// Reativa sons do script questions
    }

    public void aaudiooff()
    {
        audioonoff = true;
        PlayerPrefs.SetInt("audioonoff", 1); // 1 = sem som
        PlayerPrefs.Save(); // Salva a mudança permanentemente

        questions.AtualizarSom(); // Desativa sons do script questions
    }


    public void startquiz()
    {
        anim.SetBool("quiz", true);
        anim.SetBool("start", false);
        anim.SetBool("rightdashboard", false);
        controle = "quiz";
    }

    public void startperfil()
    {
        anim.SetBool("rightperfil", true);
        anim.SetBool("rightdashboard", false);
        anim.SetBool("start", true);
        anim.SetBool("quiz", false);
        panelLai.SetActive(false);
        controle = "quiz";
    }

    public void perfildois()
    {
        anim.SetBool("rightperfil", false);
        anim.SetBool("start", false);
        //loginestava em true
        login.SetActive(true);
        nameWindow.SetActive(true);
        //loginestava em true
        loginWindow.SetActive(true);
        controle = "inicio";
    }

    public void perfiltres()
    {
        perfileditar.SetActive(true);
    }

    public void perfilquatro()
    {
        perfileditar.SetActive(false);
    }

    public void cronograma()
    {
        anim.SetBool("rightcronograma", true);
        anim.SetBool("start", false);
        anim.SetBool("rightperfil", false);
        controle = "quiz";
    }

    public void startdashboard()
    {
        anim.SetBool("rightdashboard", true);
        anim.SetBool("rightperfil", false);
        anim.SetBool("start", true);
        anim.SetBool("quiz", false);
        controle = "inicio";
        panelLai.SetActive(false);
    }

    public void startleadboard()
    {
        anim.SetBool("rightleadboard", true);
        anim.SetBool("rightperfil", false);
        anim.SetBool("start", false);
        controle = "quiz";
    }

    public void starttrofeus()
    {
        anim.SetBool("righttrofeus", true);
        anim.SetBool("rightperfil", false);
        anim.SetBool("start", false);
        controle = "quiz";
    }

    public void startconfig()
    {
        anim.SetBool("rightconfig", true);
        anim.SetBool("rightperfil", false);
        anim.SetBool("start", false);
        controle = "quiz";
    }

    public void backstart()
    {
        anim.SetBool("quiz", false);
        anim.SetBool("start", true);
        anim.SetBool("rightperfil", false);
        anim.SetBool("rightdashboard", false);
        anim.SetBool("rightleadboard", false);
        anim.SetBool("rightcronograma", false);
        anim.SetBool("righttrofeus", false);
        anim.SetBool("rightconfig", false);
        login.SetActive(false);
        panelLai.SetActive(false);
        controle = "inicio";
    }

    public void backconfig() 
    {
        anim.SetBool("quiz", false);
        anim.SetBool("start", true);
        anim.SetBool("rightperfil", false);
        anim.SetBool("rightdashboard", false);
        anim.SetBool("rightleadboard", false);
        anim.SetBool("rightcronograma", false);
        anim.SetBool("righttrofeus", false);
        anim.SetBool("rightconfig", false);
        login.SetActive(false);
        controle = "inicio";
    }

    public void salvarcelularetc()
    {
        //celular = celularinput.text;
        medalhas.save = true;
    }



    public void dashboar()
    {
        //dashboard.SetActive(true);
        //leadboard.SetActive(false);
    }

    public void leadboar()
    {
        //leadboard.SetActive(true);
        //dashboard.SetActive(false);
    }

    public void maisdia()
    {
        days = days + 1;
    }

    public void menosdia()
    {
        days = days - 1;
    }

    public void ResetYPositionToZeroForAllScrollViews()
    {
        foreach (ScrollRect scrollView in scrollViews)
        {
            RectTransform contentRectTransform = scrollView.content.GetComponent<RectTransform>();

            // Define a posição Y para 0
            Vector3 newPosition = contentRectTransform.localPosition;
            newPosition.y = 0f;

            // Atualiza a posição Y do RectTransform
            contentRectTransform.localPosition = newPosition;
        }
    }

    public void resetok()
    {
        apagardados.SetActive(true);
    }
    public void resetno()
    {
        apagardados.SetActive(false);
    }

    public void deletarok()
    {
        apagouconta = true;
        deletepanel.SetActive(true);
        medalhas.save = true;
    }
    public void deletar()
    {
        deletepanel.SetActive(true);
    }
    public void deletarno()
    {
        deletepanel.SetActive(false);
    }

    public void filter()
    {
        filtro.SetActive(true);
    }

    public void filterno()
    {
        filtro.SetActive(false);
    }

    public void menufiltroo()
    {
        menufiltro.SetActive(true);
        panelquestoes.SetActive(false);

        if(questions.materia <= 5 ) 
        {
            backstart();
        }
    }

    public void menufiltrooff()
    {
        menufiltro.SetActive(false);
        StartCoroutine("wait1");
    }

    IEnumerator wait1()
    {
        yield return new WaitForSeconds(0.01f);
        panelquestoes.SetActive(true);
        StartCoroutine("wait2");
    }

    IEnumerator wait2()
    {
        yield return new WaitForSeconds(0.01f);
        panelquestoes.SetActive(false);
        StartCoroutine("wait3");
    }

    IEnumerator wait3()
    {
        yield return new WaitForSeconds(0.01f);
        panelquestoes.SetActive(true);
        StartCoroutine("wait3");
    }

    public void FORTEST()
    {
        apagouconta = false;
        medalhas.save = true;
    }

    public void reset()
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
        matematica.erros   = 0;
                                 
        ciehumanas.control     = 0;
        ciedanatureza.control  = 0;
        linguagens.control     = 0;
        ingles.control         = 0;
        espanhol.control       = 0;
                               
        ciehumanas.acertos     = 0;
        ciedanatureza.acertos  = 0;
        linguagens.acertos     = 0;
        ingles.acertos         = 0;
        espanhol.acertos       = 0;
                                
        ciehumanas.erros       = 0;
        ciedanatureza.erros    = 0;
        linguagens.erros       = 0;
        ingles.erros           = 0;
        espanhol.erros         = 0;
        questions.inglespanhol = 0;
    }

    IEnumerator click()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("quiz1", false);
    }

}

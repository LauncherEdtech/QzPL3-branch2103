using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class medalhas : MonoBehaviour
{
    public static bool save = false;

    public TextMeshProUGUI txt;

    public GameObject notificacao;

    public GameObject imgmedalha2sg;
    public GameObject imgmedalha4sg;
    public GameObject imgmedalhaTdsMtrs;
    public GameObject imgmedalha10questions;
    public GameObject imgmedalha10questionsTdsMtrs;
    public GameObject imgmedalhafinal;

    public static int controle;

    public int controle1;

    public static int medalha2sg;
    public static int medalha4sg;
    public static int medalhaTdsMtrs;
    public static int medalha10questions;
    public static int medalha10questionsTdsMtrs;
    public static int medalhafinal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region medalha 2 questões seguidas

        if (medalha2sg != 1)
        {
            imgmedalha2sg.SetActive(false);
            if (controle == 2)
            {
                txt.text = "Acerte 2 questões seguidas!";
                medalha2sg = 1;
                save = true;
                Debug.Log("medalha");
                notificacao.SetActive(true);
                StartCoroutine("showcorrect");
            }
        }
        else { imgmedalha2sg.SetActive(true); }

        #endregion

        #region medalha 4 questões seguidas

        if (medalha4sg != 1)
        {
            imgmedalha4sg.SetActive(false);
            if (controle == 4)
            {
                txt.text = "Acerte 4 questões seguidas!";
                medalha4sg = 1;
                save = true;
                Debug.Log("medalha");
                notificacao.SetActive(true);
                StartCoroutine("showcorrect");
            }
        }
        else { imgmedalha4sg.SetActive(true); }

        #endregion

        #region medalha 10 questoes

        if (medalha10questions != 1)
        {
            imgmedalha10questions.SetActive(false);
            if (radial.acertos >= 10)
            {
                txt.text = "Acerte 10 questões!";
                medalha10questions = 1;
                save = true;
                Debug.Log("medalha");
                notificacao.SetActive(true);
                StartCoroutine("showcorrect");
            }
        }
        else { imgmedalha10questions.SetActive(true); }

        #endregion

        #region 10 questões todas as materias

        if (medalha10questionsTdsMtrs != 1)
        {
            imgmedalha10questionsTdsMtrs.SetActive(false);
           
                if (matematica.acertos >= 10)
                {
                    if (linguagens.acertos >= 10)
                    {
                        if (ciedanatureza.acertos >= 10)
                        {
                            if (ciehumanas.acertos >= 10)
                            {
                                if (ingles.acertos >= 10)
                                {
                                    txt.text = "acerte 10 questões de todas as matérias!";
                                    medalha10questionsTdsMtrs = 1;
                                    Debug.Log("medalha");
                                    notificacao.SetActive(true);
                                    StartCoroutine("showcorrect");
                                }
                            }
                        }
                    }
                }
            
                if (matematica.acertos >= 10)
                {
                    if (linguagens.acertos >= 10)
                    {
                        if (ciedanatureza.acertos >= 10)
                        {
                            if (ciehumanas.acertos >= 10)
                            {
                                if (espanhol.acertos >= 10)
                                {
                                    txt.text = "acerte 10 questões de todas as matérias!";
                                    medalha10questionsTdsMtrs = 1;
                                    Debug.Log("medalha");
                                    notificacao.SetActive(true);
                                    StartCoroutine("showcorrect");
                                }
                            }
                        }
                    }
                }
            
        }
        else { imgmedalha10questionsTdsMtrs.SetActive(false); }

        #endregion

        #region 1 questão todas as materias

        controle1 = medalhaTdsMtrs;

        if (medalhaTdsMtrs != 1)
        {
            imgmedalhaTdsMtrs.SetActive(false);
           
                if (matematica.acertos >= 1)
                {
                    if (linguagens.acertos >= 1)
                    {
                        if (ciedanatureza.acertos >= 1)
                        {
                            if (ciehumanas.acertos >= 1)
                            {
                                if (ingles.acertos >= 1)
                                {
                                    txt.text = "Acerte uma questão de todos as matérias!";
                                    medalhaTdsMtrs = 1;
                                    Debug.Log("medalha tds questoes");
                                    notificacao.SetActive(true);
                                    StartCoroutine("showcorrect");
                                }
                            }
                        }
                    }
                }
            
                if (matematica.acertos >= 1)
                {
                if (linguagens.acertos >= 1)
                    {
                    if (ciedanatureza.acertos >= 1)
                        {
                            if (ciehumanas.acertos >= 1)
                            {
                                if (espanhol.acertos >= 1)
                                {
                                    txt.text = "Acerte uma questão de todos as matérias!";
                                    medalhaTdsMtrs = 1;
                                    Debug.Log("medalha tds questoes");
                                    notificacao.SetActive(true);
                                    StartCoroutine("showcorrect");
                                }
                            }
                        }
                    }
                }
            
        }
         else { imgmedalhaTdsMtrs.SetActive(true); }
        #endregion

        #region medalha final

        if (medalhafinal != 1)
        {
            imgmedalhafinal.SetActive(false);
            if (radial.acertos >= 100)
            {
                txt.text = "Acerte 100 questões!";
                medalhafinal = 1;
                save = true;
                Debug.Log("medalha final");
                notificacao.SetActive(true);
                StartCoroutine("showcorrect");
            }
        }
        else { imgmedalhafinal.SetActive(true); }
        #endregion

    }
    IEnumerator showcorrect()
    {
        yield return new WaitForSeconds(2.5f);
        notificacao.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tarefas : MonoBehaviour
{
    public static int confirmar;

    public int diasemana;
    public TextMeshProUGUI diasemanatxt;

    #region segunda

    public static int segunda;

    public static string tsegunda1;
    public static string hsegunda1;
    public GameObject tsegundaobj1;
    public TextMeshProUGUI segundahoratxt1;
    public TextMeshProUGUI segundadescricaotxt1;

    public static string tsegunda2;
    public static string hsegunda2;
    public GameObject tsegundaobj2;
    public TextMeshProUGUI segundahoratxt2;
    public TextMeshProUGUI segundadescricaotxt2;

    public static string tsegunda3;
    public static string hsegunda3;
    public GameObject tsegundaobj3;
    public TextMeshProUGUI segundahoratxt3;
    public TextMeshProUGUI segundadescricaotxt3;

    public static string tsegunda4;
    public static string hsegunda4;
    public GameObject tsegundaobj4;
    public TextMeshProUGUI segundahoratxt4;
    public TextMeshProUGUI segundadescricaotxt4;

    public static string tsegunda5;
    public static string hsegunda5;
    public GameObject tsegundaobj5;
    public TextMeshProUGUI segundahoratxt5;
    public TextMeshProUGUI segundadescricaotxt5;

    public static string tsegunda6;
    public static string hsegunda6;
    public GameObject tsegundaobj6;
    public TextMeshProUGUI segundahoratxt6;
    public TextMeshProUGUI segundadescricaotxt6;

    #endregion

    #region terca

    public static int terca;
    public int terca1;

    public static string tterca1; // Substituído de "tsegunda1" para "tterca1"
    public static string hterca1; // Substituído de "hsegunda1" para "hterca1"
    public GameObject ttercaobj1; // Substituído de "tsegundaobj1" para "ttercaobj1"
    public TextMeshProUGUI tercahoratxt1; // Substituído de "segundahoratxt1" para "tercahoratxt1"
    public TextMeshProUGUI tercadescricaotxt1; // Substituído de "segundadescricaotxt1" para "tercadescricaotxt1"

    public static string tterca2; // Substituído de "tsegunda2" para "tterca2"
    public static string hterca2; // Substituído de "hsegunda2" para "hterca2"
    public GameObject ttercaobj2; // Substituído de "tsegundaobj2" para "ttercaobj2"
    public TextMeshProUGUI tercahoratxt2; // Substituído de "segundahoratxt2" para "tercahoratxt2"
    public TextMeshProUGUI tercadescricaotxt2; // Substituído de "segundadescricaotxt2" para "tercadescricaotxt2"

    public static string tterca3; // Substituído de "tsegunda3" para "tterca3"
    public static string hterca3; // Substituído de "hsegunda3" para "hterca3"
    public GameObject ttercaobj3; // Substituído de "tsegundaobj3" para "ttercaobj3"
    public TextMeshProUGUI tercahoratxt3; // Substituído de "segundahoratxt3" para "tercahoratxt3"
    public TextMeshProUGUI tercadescricaotxt3; // Substituído de "segundadescricaotxt3" para "tercadescricaotxt3"

    public static string tterca4; // Substituído de "tsegunda4" para "tterca4"
    public static string hterca4; // Substituído de "hsegunda4" para "hterca4"
    public GameObject ttercaobj4; // Substituído de "tsegundaobj4" para "ttercaobj4"
    public TextMeshProUGUI tercahoratxt4; // Substituído de "segundahoratxt4" para "tercahoratxt4"
    public TextMeshProUGUI tercadescricaotxt4; // Substituído de "segundadescricaotxt4" para "tercadescricaotxt4"

    public static string tterca5; // Substituído de "tsegunda5" para "tterca5"
    public static string hterca5; // Substituído de "hsegunda5" para "hterca5"
    public GameObject ttercaobj5; // Substituído de "tsegundaobj5" para "ttercaobj5"
    public TextMeshProUGUI tercahoratxt5; // Substituído de "segundahoratxt5" para "tercahoratxt5"
    public TextMeshProUGUI tercadescricaotxt5; // Substituído de "segundadescricaotxt5" para "tercadescricaotxt5"

    public static string tterca6; // Substituído de "tsegunda6" para "tterca6"
    public static string hterca6; // Substituído de "hsegunda6" para "hterca6"
    public GameObject ttercaobj6; // Substituído de "tsegundaobj6" para "ttercaobj6"
    public TextMeshProUGUI tercahoratxt6; // Substituído de "segundahoratxt6" para "tercahoratxt6"
    public TextMeshProUGUI tercadescricaotxt6; // Substituído de "segundadescricaotxt6" para "tercadescricaotxt6"

    #endregion

    #region quarta

    public static int quarta;

    public static string tquarta1; // Alterado de "tsegunda1" para "tquarta1"
    public static string hquarta1; // Alterado de "hsegunda1" para "hquarta1"
    public GameObject tquartaobj1;
    public TextMeshProUGUI quartahoratxt1;
    public TextMeshProUGUI quartadescricaotxt1;

    public static string tquarta2; // Alterado de "tsegunda2" para "tquarta2"
    public static string hquarta2; // Alterado de "hsegunda2" para "hquarta2"
    public GameObject tquartaobj2;
    public TextMeshProUGUI quartahoratxt2;
    public TextMeshProUGUI quartadescricaotxt2;

    public static string tquarta3; // Alterado de "tsegunda3" para "tquarta3"
    public static string hquarta3; // Alterado de "hsegunda3" para "hquarta3"
    public GameObject tquartaobj3;
    public TextMeshProUGUI quartahoratxt3;
    public TextMeshProUGUI quartadescricaotxt3;

    public static string tquarta4; // Alterado de "tsegunda4" para "tquarta4"
    public static string hquarta4; // Alterado de "hsegunda4" para "hquarta4"
    public GameObject tquartaobj4;
    public TextMeshProUGUI quartahoratxt4;
    public TextMeshProUGUI quartadescricaotxt4;

    public static string tquarta5; // Alterado de "tsegunda5" para "tquarta5"
    public static string hquarta5; // Alterado de "hsegunda5" para "hquarta5"
    public GameObject tquartaobj5;
    public TextMeshProUGUI quartahoratxt5;
    public TextMeshProUGUI quartadescricaotxt5;

    public static string tquarta6; // Alterado de "tsegunda6" para "tquarta6"
    public static string hquarta6; // Alterado de "hsegunda6" para "hquarta6"
    public GameObject tquartaobj6;
    public TextMeshProUGUI quartahoratxt6;
    public TextMeshProUGUI quartadescricaotxt6;

    #endregion

    #region quinta

    public static int quinta; // Alterado de "quarta" para "quinta"

    public static string tquinta1; // Alterado de "tquarta1" para "tquinta1"
    public static string hquinta1; // Alterado de "hquarta1" para "hquinta1"
    public GameObject tquintaobj1;
    public TextMeshProUGUI quintahoratxt1;
    public TextMeshProUGUI quintadescricaotxt1;

    public static string tquinta2; // Alterado de "tquarta2" para "tquinta2"
    public static string hquinta2; // Alterado de "hquarta2" para "hquinta2"
    public GameObject tquintaobj2;
    public TextMeshProUGUI quintahoratxt2;
    public TextMeshProUGUI quintadescricaotxt2;

    public static string tquinta3; // Alterado de "tquarta3" para "tquinta3"
    public static string hquinta3; // Alterado de "hquarta3" para "hquinta3"
    public GameObject tquintaobj3;
    public TextMeshProUGUI quintahoratxt3;
    public TextMeshProUGUI quintadescricaotxt3;

    public static string tquinta4; // Alterado de "tquarta4" para "tquinta4"
    public static string hquinta4; // Alterado de "hquarta4" para "hquinta4"
    public GameObject tquintaobj4;
    public TextMeshProUGUI quintahoratxt4;
    public TextMeshProUGUI quintadescricaotxt4;

    public static string tquinta5; // Alterado de "tquarta5" para "tquinta5"
    public static string hquinta5; // Alterado de "hquarta5" para "hquinta5"
    public GameObject tquintaobj5;
    public TextMeshProUGUI quintahoratxt5;
    public TextMeshProUGUI quintadescricaotxt5;

    public static string tquinta6; // Alterado de "tquarta6" para "tquinta6"
    public static string hquinta6; // Alterado de "hquarta6" para "hquinta6"
    public GameObject tquintaobj6;
    public TextMeshProUGUI quintahoratxt6;
    public TextMeshProUGUI quintadescricaotxt6;

    #endregion

    #region sexta
    public static int sexta; // Alterado de "quinta" para "sexta"

    public static string tsexta1; // Alterado de "tquinta1" para "tsexta1"
    public static string hsexta1; // Alterado de "hquinta1" para "hsexta1"
    public GameObject tsextaobj1;
    public TextMeshProUGUI sextahoratxt1;
    public TextMeshProUGUI sextadescricaotxt1;

    public static string tsexta2; // Alterado de "tquinta2" para "tsexta2"
    public static string hsexta2; // Alterado de "hquinta2" para "hsexta2"
    public GameObject tsextaobj2;
    public TextMeshProUGUI sextahoratxt2;
    public TextMeshProUGUI sextadescricaotxt2;

    public static string tsexta3; // Alterado de "tquinta3" para "tsexta3"
    public static string hsexta3; // Alterado de "hquinta3" para "hsexta3"
    public GameObject tsextaobj3;
    public TextMeshProUGUI sextahoratxt3;
    public TextMeshProUGUI sextadescricaotxt3;

    public static string tsexta4; // Alterado de "tquinta4" para "tsexta4"
    public static string hsexta4; // Alterado de "hquinta4" para "hsexta4"
    public GameObject tsextaobj4;
    public TextMeshProUGUI sextahoratxt4;
    public TextMeshProUGUI sextadescricaotxt4;

    public static string tsexta5; // Alterado de "tquinta5" para "tsexta5"
    public static string hsexta5; // Alterado de "hquinta5" para "hsexta5"
    public GameObject tsextaobj5;
    public TextMeshProUGUI sextahoratxt5;
    public TextMeshProUGUI sextadescricaotxt5;

    public static string tsexta6; // Alterado de "tquinta6" para "tsexta6"
    public static string hsexta6; // Alterado de "hquinta6" para "hsexta6"
    public GameObject tsextaobj6;
    public TextMeshProUGUI sextahoratxt6;
    public TextMeshProUGUI sextadescricaotxt6;

    #endregion

    #region sabado
    public static int sabado; // Alterado de "quarta" para "sabado"

    public static string tsabado1; // Alterado de "tquarta1" para "tsabado1"
    public static string hsabado1; // Alterado de "hquarta1" para "hsabado1"
    public GameObject tsabadoobj1;
    public TextMeshProUGUI sabadohoratxt1;
    public TextMeshProUGUI sabadodescricaotxt1;

    public static string tsabado2; // Alterado de "tquarta2" para "tsabado2"
    public static string hsabado2; // Alterado de "hquarta2" para "hsabado2"
    public GameObject tsabadoobj2;
    public TextMeshProUGUI sabadohoratxt2;
    public TextMeshProUGUI sabadodescricaotxt2;

    public static string tsabado3; // Alterado de "tquarta3" para "tsabado3"
    public static string hsabado3; // Alterado de "hquarta3" para "hsabado3"
    public GameObject tsabadoobj3;
    public TextMeshProUGUI sabadohoratxt3;
    public TextMeshProUGUI sabadodescricaotxt3;

    public static string tsabado4; // Alterado de "tquarta4" para "tsabado4"
    public static string hsabado4; // Alterado de "hquarta4" para "hsabado4"
    public GameObject tsabadoobj4;
    public TextMeshProUGUI sabadohoratxt4;
    public TextMeshProUGUI sabadodescricaotxt4;

    public static string tsabado5; // Alterado de "tquarta5" para "tsabado5"
    public static string hsabado5; // Alterado de "hquarta5" para "hsabado5"
    public GameObject tsabadoobj5;
    public TextMeshProUGUI sabadohoratxt5;
    public TextMeshProUGUI sabadodescricaotxt5;

    public static string tsabado6; // Alterado de "tquarta6" para "tsabado6"
    public static string hsabado6; // Alterado de "hquarta6" para "hsabado6"
    public GameObject tsabadoobj6;
    public TextMeshProUGUI sabadohoratxt6;
    public TextMeshProUGUI sabadodescricaotxt6;

    #endregion

    #region domingo
    public static int domingo; // Alterado de "quarta" para "domingo"

    public static string tdomingo1; // Alterado de "tquarta1" para "tdomingo1"
    public static string hdomingo1; // Alterado de "hquarta1" para "hdomingo1"
    public GameObject tdomingoobj1;
    public TextMeshProUGUI domingohoratxt1;
    public TextMeshProUGUI domingodescricaotxt1;

    public static string tdomingo2; // Alterado de "tquarta2" para "tdomingo2"
    public static string hdomingo2; // Alterado de "hquarta2" para "hdomingo2"
    public GameObject tdomingoobj2;
    public TextMeshProUGUI domingohoratxt2;
    public TextMeshProUGUI domingodescricaotxt2;

    public static string tdomingo3; // Alterado de "tquarta3" para "tdomingo3"
    public static string hdomingo3; // Alterado de "hquarta3" para "hdomingo3"
    public GameObject tdomingoobj3;
    public TextMeshProUGUI domingohoratxt3;
    public TextMeshProUGUI domingodescricaotxt3;

    public static string tdomingo4; // Alterado de "tquarta4" para "tdomingo4"
    public static string hdomingo4; // Alterado de "hquarta4" para "hdomingo4"
    public GameObject tdomingoobj4;
    public TextMeshProUGUI domingohoratxt4;
    public TextMeshProUGUI domingodescricaotxt4;

    public static string tdomingo5; // Alterado de "tquarta5" para "tdomingo5"
    public static string hdomingo5; // Alterado de "hquarta5" para "hdomingo5"
    public GameObject tdomingoobj5;
    public TextMeshProUGUI domingohoratxt5;
    public TextMeshProUGUI domingodescricaotxt5;

    public static string tdomingo6; // Alterado de "tquarta6" para "tdomingo6"
    public static string hdomingo6; // Alterado de "hquarta6" para "hdomingo6"
    public GameObject tdomingoobj6;
    public TextMeshProUGUI domingohoratxt6;
    public TextMeshProUGUI domingodescricaotxt6;
    #endregion


    public TMP_InputField horaTarefaInput;
    public TMP_InputField descricaoTarefaInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        terca1 = quarta;

        #region segunda

        if (segunda >= 1) 
        {
            tsegundaobj1.SetActive(true);
            segundahoratxt1.text = hsegunda1;
            segundadescricaotxt1.text = tsegunda1;
        }else {tsegundaobj1.SetActive(false);}


        if (segunda >= 2)
        {
            tsegundaobj2.SetActive(true);
            segundahoratxt2.text = hsegunda2;
            segundadescricaotxt2.text = tsegunda2;
        }else{tsegundaobj2.SetActive(false);}

        if (segunda >= 3)
        {
            tsegundaobj3.SetActive(true);
            segundahoratxt3.text = hsegunda3;
            segundadescricaotxt3.text = tsegunda3;
        }
        else { tsegundaobj3.SetActive(false); }

        if (segunda >= 4)
        {
            tsegundaobj4.SetActive(true);
            segundahoratxt4.text = hsegunda4;
            segundadescricaotxt4.text = tsegunda4;
        }
        else { tsegundaobj4.SetActive(false); }

        if (segunda >= 5)
        {
            tsegundaobj5.SetActive(true);
            segundahoratxt5.text = hsegunda5;
            segundadescricaotxt5.text = tsegunda5;
        }
        else { tsegundaobj5.SetActive(false); }

        if (segunda >= 6)
        {
            tsegundaobj6.SetActive(true);
            segundahoratxt6.text = hsegunda6;
            segundadescricaotxt6.text = tsegunda6;
        }
        else { tsegundaobj6.SetActive(false); }

        #endregion

        #region terça

        if (terca >= 1) // Substituído de "segunda" para "terca"
        {
            ttercaobj1.SetActive(true); // Substituído de "tsegundaobj1" para "ttercaobj1"
            tercahoratxt1.text = hterca1; // Substituído de "segundahoratxt1" para "tercahoratxt1"
            tercadescricaotxt1.text = tterca1; // Substituído de "segundadescricaotxt1" para "tercadescricaotxt1"
        }
        else { ttercaobj1.SetActive(false); } // Substituído de "tsegundaobj1" para "ttercaobj1"

        if (terca >= 2) // Substituído de "segunda" para "terca"
        {
            ttercaobj2.SetActive(true); // Substituído de "tsegundaobj2" para "ttercaobj2"
            tercahoratxt2.text = hterca2; // Substituído de "segundahoratxt2" para "tercahoratxt2"
            tercadescricaotxt2.text = tterca2; // Substituído de "segundadescricaotxt2" para "tercadescricaotxt2"
        }
        else { ttercaobj2.SetActive(false); } // Substituído de "tsegundaobj2" para "ttercaobj2"

        if (terca >= 3) // Substituído de "segunda" para "terca"
        {
            ttercaobj3.SetActive(true); // Substituído de "tsegundaobj3" para "ttercaobj3"
            tercahoratxt3.text = hterca3; // Substituído de "segundahoratxt3" para "tercahoratxt3"
            tercadescricaotxt3.text = tterca3; // Substituído de "segundadescricaotxt3" para "tercadescricaotxt3"
        }
        else { ttercaobj3.SetActive(false); } // Substituído de "tsegundaobj3" para "ttercaobj3"

        if (terca >= 4) // Substituído de "segunda" para "terca"
        {
            ttercaobj4.SetActive(true); // Substituído de "tsegundaobj4" para "ttercaobj4"
            tercahoratxt4.text = hterca4; // Substituído de "segundahoratxt4" para "tercahoratxt4"
            tercadescricaotxt4.text = tterca4; // Substituído de "segundadescricaotxt4" para "tercadescricaotxt4"
        }
        else { ttercaobj4.SetActive(false); } // Substituído de "tsegundaobj4" para "ttercaobj4"

        if (terca >= 5) // Substituído de "segunda" para "terca"
        {
            ttercaobj5.SetActive(true); // Substituído de "tsegundaobj5" para "ttercaobj5"
            tercahoratxt5.text = hterca5; // Substituído de "segundahoratxt5" para "tercahoratxt5"
            tercadescricaotxt5.text = tterca5; // Substituído de "segundadescricaotxt5" para "tercadescricaotxt5"
        }
        else { ttercaobj5.SetActive(false); } // Substituído de "tsegundaobj5" para "ttercaobj5"

        if (terca >= 6) // Substituído de "segunda" para "terca"
        {
            ttercaobj6.SetActive(true); // Substituído de "tsegundaobj6" para "ttercaobj6"
            tercahoratxt6.text = hterca6; // Substituído de "segundahoratxt6" para "tercahoratxt6"
            tercadescricaotxt6.text = tterca6; // Substituído de "segundadescricaotxt6" para "tercadescricaotxt6"
        }
        else { ttercaobj6.SetActive(false); } // Substituído de "tsegundaobj6" para "ttercaobj6"

        #endregion

        #region quarta

        if (quarta >= 1)
        {
            tquartaobj1.SetActive(true);
            quartahoratxt1.text = hquarta1;
            quartadescricaotxt1.text = tquarta1;
        }
        else { tquartaobj1.SetActive(false); }


        if (quarta >= 2)
        {
            tquartaobj2.SetActive(true);
            quartahoratxt2.text = hquarta2;
            quartadescricaotxt2.text = tquarta2;
        }
        else { tquartaobj2.SetActive(false); }

        if (quarta >= 3)
        {
            tquartaobj3.SetActive(true);
            quartahoratxt3.text = hquarta3;
            quartadescricaotxt3.text = tquarta3;
        }
        else { tquartaobj3.SetActive(false); }

        if (quarta >= 4)
        {
            tquartaobj4.SetActive(true);
            quartahoratxt4.text = hquarta4;
            quartadescricaotxt4.text = tquarta4;
        }
        else { tquartaobj4.SetActive(false); }

        if (quarta >= 5)
        {
            tquartaobj5.SetActive(true);
            quartahoratxt5.text = hquarta5;
            quartadescricaotxt5.text = tquarta5;
        }
        else { tquartaobj5.SetActive(false); }

        if (quarta >= 6)
        {
            tquartaobj6.SetActive(true);
            quartahoratxt6.text = hquarta6;
            quartadescricaotxt6.text = tquarta6;
        }
        else { tquartaobj6.SetActive(false); }

        #endregion

        #region quinta
        if (quinta >= 1)
        {
            tquintaobj1.SetActive(true);
            quintahoratxt1.text = hquinta1;
            quintadescricaotxt1.text = tquinta1;
        }
        else { tquintaobj1.SetActive(false); }


        if (quinta >= 2)
        {
            tquintaobj2.SetActive(true);
            quintahoratxt2.text = hquinta2;
            quintadescricaotxt2.text = tquinta2;
        }
        else { tquintaobj2.SetActive(false); }

        if (quinta >= 3)
        {
            tquintaobj3.SetActive(true);
            quintahoratxt3.text = hquinta3;
            quintadescricaotxt3.text = tquinta3;
        }
        else { tquintaobj3.SetActive(false); }

        if (quinta >= 4)
        {
            tquintaobj4.SetActive(true);
            quintahoratxt4.text = hquinta4;
            quintadescricaotxt4.text = tquinta4;
        }
        else { tquintaobj4.SetActive(false); }

        if (quinta >= 5)
        {
            tquintaobj5.SetActive(true);
            quintahoratxt5.text = hquinta5;
            quintadescricaotxt5.text = tquinta5;
        }
        else { tquintaobj5.SetActive(false); }

        if (quinta >= 6)
        {
            tquintaobj6.SetActive(true);
            quintahoratxt6.text = hquinta6;
            quintadescricaotxt6.text = tquinta6;
        }
        else { tquintaobj6.SetActive(false); }

        #endregion

        #region sexta
        if (sexta >= 1)
        {
            tsextaobj1.SetActive(true);
            sextahoratxt1.text = hsexta1;
            sextadescricaotxt1.text = tsexta1;
        }
        else { tsextaobj1.SetActive(false); }


        if (sexta >= 2)
        {
            tsextaobj2.SetActive(true);
            sextahoratxt2.text = hsexta2;
            sextadescricaotxt2.text = tsexta2;
        }
        else { tsextaobj2.SetActive(false); }

        if (sexta >= 3)
        {
            tsextaobj3.SetActive(true);
            sextahoratxt3.text = hsexta3;
            sextadescricaotxt3.text = tsexta3;
        }
        else { tsextaobj3.SetActive(false); }

        if (sexta >= 4)
        {
            tsextaobj4.SetActive(true);
            sextahoratxt4.text = hsexta4;
            sextadescricaotxt4.text = tsexta4;
        }
        else { tsextaobj4.SetActive(false); }

        if (sexta >= 5)
        {
            tsextaobj5.SetActive(true);
            sextahoratxt5.text = hsexta5;
            sextadescricaotxt5.text = tsexta5;
        }
        else { tsextaobj5.SetActive(false); }

        if (sexta >= 6)
        {
            tsextaobj6.SetActive(true);
            sextahoratxt6.text = hsexta6;
            sextadescricaotxt6.text = tsexta6;
        }
        else { tsextaobj6.SetActive(false); }

        #endregion

        #region sabado
        if (sabado >= 1)
        {
            tsabadoobj1.SetActive(true);
            sabadohoratxt1.text = hsabado1;
            sabadodescricaotxt1.text = tsabado1;
        }
        else { tsabadoobj1.SetActive(false); }


        if (sabado >= 2)
        {
            tsabadoobj2.SetActive(true);
            sabadohoratxt2.text = hsabado2;
            sabadodescricaotxt2.text = tsabado2;
        }
        else { tsabadoobj2.SetActive(false); }

        if (sabado >= 3)
        {
            tsabadoobj3.SetActive(true);
            sabadohoratxt3.text = hsabado3;
            sabadodescricaotxt3.text = tsabado3;
        }
        else { tsabadoobj3.SetActive(false); }

        if (sabado >= 4)
        {
            tsabadoobj4.SetActive(true);
            sabadohoratxt4.text = hsabado4;
            sabadodescricaotxt4.text = tsabado4;
        }
        else { tsabadoobj4.SetActive(false); }

        if (sabado >= 5)
        {
            tsabadoobj5.SetActive(true);
            sabadohoratxt5.text = hsabado5;
            sabadodescricaotxt5.text = tsabado5;
        }
        else { tsabadoobj5.SetActive(false); }

        if (sabado >= 6)
        {
            tsabadoobj6.SetActive(true);
            sabadohoratxt6.text = hsabado6;
            sabadodescricaotxt6.text = tsabado6;
        }
        else { tsabadoobj6.SetActive(false); }

        #endregion

        #region domingo
        if (domingo >= 1)
        {
            tdomingoobj1.SetActive(true);
            domingohoratxt1.text = hdomingo1;
            domingodescricaotxt1.text = tdomingo1;
        }
        else { tdomingoobj1.SetActive(false); }


        if (domingo >= 2)
        {
            tdomingoobj2.SetActive(true);
            domingohoratxt2.text = hdomingo2;
            domingodescricaotxt2.text = tdomingo2;
        }
        else { tdomingoobj2.SetActive(false); }

        if (domingo >= 3)
        {
            tdomingoobj3.SetActive(true);
            domingohoratxt3.text = hdomingo3;
            domingodescricaotxt3.text = tdomingo3;
        }
        else { tdomingoobj3.SetActive(false); }

        if (domingo >= 4)
        {
            tdomingoobj4.SetActive(true);
            domingohoratxt4.text = hdomingo4;
            domingodescricaotxt4.text = tdomingo4;
        }
        else { tdomingoobj4.SetActive(false); }

        if (domingo >= 5)
        {
            tdomingoobj5.SetActive(true);
            domingohoratxt5.text = hdomingo5;
            domingodescricaotxt5.text = tdomingo5;
        }
        else { tdomingoobj5.SetActive(false); }

        if (domingo >= 6)
        {
            tdomingoobj6.SetActive(true);
            domingohoratxt6.text = hdomingo6;
            domingodescricaotxt6.text = tdomingo6;
        }
        else { tdomingoobj6.SetActive(false); }

        #endregion

    }

    public void AdicionarTarefa()
    {
        confirmar = 1;
        if (horaTarefaInput.text != "" || descricaoTarefaInput.text != "")
        {
            #region segunda
            if (controleui.days == 0)
            {
                segunda = segunda + 1;
                if (segunda == 1)
                {
                    hsegunda1 = horaTarefaInput.text;
                    tsegunda1 = descricaoTarefaInput.text;

                }

                if (segunda == 2)
                {
                    hsegunda2 = horaTarefaInput.text;
                    tsegunda2 = descricaoTarefaInput.text;

                }

                if (segunda == 3)
                {
                    hsegunda3 = horaTarefaInput.text;
                    tsegunda3 = descricaoTarefaInput.text;

                }

                if (segunda == 4)
                {
                    hsegunda4 = horaTarefaInput.text;
                    tsegunda4 = descricaoTarefaInput.text;

                }

                if (segunda == 5)
                {
                    hsegunda5 = horaTarefaInput.text;
                    tsegunda5 = descricaoTarefaInput.text;

                }

                if (segunda == 6)
                {
                    hsegunda6 = horaTarefaInput.text;
                    tsegunda6 = descricaoTarefaInput.text;

                }
            }
            #endregion

            #region terca

            if (controleui.days == 1)
            {
                terca = terca + 1;
                if (terca == 1) // Substituído de "segunda" para "terca"
                {
                    hterca1 = horaTarefaInput.text; // Substituído de "hsegunda1" para "hterca1"
                    tterca1 = descricaoTarefaInput.text; // Substituído de "tsegunda1" para "tterca1"

                }

                if (terca == 2) // Substituído de "segunda" para "terca"
                {
                    hterca2 = horaTarefaInput.text; // Substituído de "hsegunda2" para "hterca2"
                    tterca2 = descricaoTarefaInput.text; // Substituído de "tsegunda2" para "tterca2"

                }

                if (terca == 3) // Substituído de "segunda" para "terca"
                {
                    hterca3 = horaTarefaInput.text; // Substituído de "hsegunda3" para "hterca3"
                    tterca3 = descricaoTarefaInput.text; // Substituído de "tsegunda3" para "tterca3"

                }

                if (terca == 4) // Substituído de "segunda" para "terca"
                {
                    hterca4 = horaTarefaInput.text; // Substituído de "hsegunda4" para "hterca4"
                    tterca4 = descricaoTarefaInput.text; // Substituído de "tsegunda4" para "tterca4"

                }

                if (terca == 5) // Substituído de "segunda" para "terca"
                {
                    hterca5 = horaTarefaInput.text; // Substituído de "hsegunda5" para "hterca5"
                    tterca5 = descricaoTarefaInput.text; // Substituído de "tsegunda5" para "tterca5"

                }

                if (terca == 6) // Substituído de "segunda" para "terca"
                {
                    hterca6 = horaTarefaInput.text; // Substituído de "hsegunda6" para "hterca6"
                    tterca6 = descricaoTarefaInput.text; // Substituído de "tsegunda6" para "tterca6"

                }
            }

            #endregion

            #region quarta

            if (controleui.days == 2)
            {
                quarta = quarta + 1;
                if (quarta == 1)
                {
                    hquarta1 = horaTarefaInput.text;
                    tquarta1 = descricaoTarefaInput.text;

                }

                if (quarta == 2)
                {
                    hquarta2 = horaTarefaInput.text;
                    tquarta2 = descricaoTarefaInput.text;

                }

                if (quarta == 3)
                {
                    hquarta3 = horaTarefaInput.text;
                    tquarta3 = descricaoTarefaInput.text;

                }

                if (quarta == 4)
                {
                    hquarta4 = horaTarefaInput.text;
                    tquarta4 = descricaoTarefaInput.text;

                }

                if (quarta == 5)
                {
                    hquarta5 = horaTarefaInput.text;
                    tquarta5 = descricaoTarefaInput.text;

                }

                if (quarta == 6)
                {
                    hquarta6 = horaTarefaInput.text;
                    tquarta6 = descricaoTarefaInput.text;

                }
            }

            #endregion

            #region quinta
            if (controleui.days == 3)
            {
                quinta = quinta + 1;
                if (quinta == 1)
                {
                    hquinta1 = horaTarefaInput.text;
                    tquinta1 = descricaoTarefaInput.text;

                }

                if (quinta == 2)
                {
                    hquinta2 = horaTarefaInput.text;
                    tquinta2 = descricaoTarefaInput.text;

                }

                if (quinta == 3)
                {
                    hquinta3 = horaTarefaInput.text;
                    tquinta3 = descricaoTarefaInput.text;

                }

                if (quinta == 4)
                {
                    hquinta4 = horaTarefaInput.text;
                    tquinta4 = descricaoTarefaInput.text;

                }

                if (quinta == 5)
                {
                    hquinta5 = horaTarefaInput.text;
                    tquinta5 = descricaoTarefaInput.text;

                }

                if (quinta == 6)
                {
                    hquinta6 = horaTarefaInput.text;
                    tquinta6 = descricaoTarefaInput.text;

                }
            }
            #endregion

            #region sexta


            if (controleui.days == 4)
            {
                sexta = sexta + 1;
                if (sexta == 1)
                {
                    hsexta1 = horaTarefaInput.text;
                    tsexta1 = descricaoTarefaInput.text;

                }

                if (sexta == 2)
                {
                    hsexta2 = horaTarefaInput.text;
                    tsexta2 = descricaoTarefaInput.text;

                }

                if (sexta == 3)
                {
                    hsexta3 = horaTarefaInput.text;
                    tsexta3 = descricaoTarefaInput.text;

                }

                if (sexta == 4)
                {
                    hsexta4 = horaTarefaInput.text;
                    tsexta4 = descricaoTarefaInput.text;

                }

                if (sexta == 5)
                {
                    hsexta5 = horaTarefaInput.text;
                    tsexta5 = descricaoTarefaInput.text;

                }

                if (sexta == 6)
                {
                    hsexta6 = horaTarefaInput.text;
                    tsexta6 = descricaoTarefaInput.text;

                }
            }

            #endregion

            #region sabado

            if (controleui.days == 5)
            {
                sabado = sabado + 1;
                if (sabado == 1)
                {
                    hsabado1 = horaTarefaInput.text;
                    tsabado1 = descricaoTarefaInput.text;

                }

                if (sabado == 2)
                {
                    hsabado2 = horaTarefaInput.text;
                    tsabado2 = descricaoTarefaInput.text;

                }

                if (sabado == 3)
                {
                    hsabado3 = horaTarefaInput.text;
                    tsabado3 = descricaoTarefaInput.text;

                }

                if (sabado == 4)
                {
                    hsabado4 = horaTarefaInput.text;
                    tsabado4 = descricaoTarefaInput.text;

                }

                if (sabado == 5)
                {
                    hsabado5 = horaTarefaInput.text;
                    tsabado5 = descricaoTarefaInput.text;

                }

                if (sabado == 6)
                {
                    hsabado6 = horaTarefaInput.text;
                    tsabado6 = descricaoTarefaInput.text;

                }
            }
            #endregion

            #region domingo
           
            if (controleui.days == 6)
            {

                domingo = domingo + 1;
                if (domingo == 1)
                {
                    hdomingo1 = horaTarefaInput.text;
                    tdomingo1 = descricaoTarefaInput.text;

                }

                if (domingo == 2)
                {
                    hdomingo2 = horaTarefaInput.text;
                    tdomingo2 = descricaoTarefaInput.text;

                }

                if (domingo == 3)
                {
                    hdomingo3 = horaTarefaInput.text;
                    tdomingo3 = descricaoTarefaInput.text;

                }

                if (domingo == 4)
                {
                    hdomingo4 = horaTarefaInput.text;
                    tdomingo4 = descricaoTarefaInput.text;

                }

                if (domingo == 5)
                {
                    hdomingo5 = horaTarefaInput.text;
                    tdomingo5 = descricaoTarefaInput.text;

                }

                if (domingo == 6)
                {
                    hdomingo6 = horaTarefaInput.text;
                    tdomingo6 = descricaoTarefaInput.text;

                }
            }

            #endregion

            horaTarefaInput.text = "";
            descricaoTarefaInput.text = "";
        }
    }

    }

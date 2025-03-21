using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {

    public Dictionary<string, int> progressoDiario;

    public bool apagouconta;
    public bool preencheu;
    public string celular;
    // medalhas

    public int medalha2sg;
    public int medalha4sg;
    public int medalhaTdsMtrs;
    public int medalha10questions;
    public int medalha10questionsTdsMtrs;
    public int medalhafinal;

    // cronograma

    public string hdomingo1;
    public string tdomingo1;
    public string hdomingo2;
    public string tdomingo2;
    public string hdomingo3;
    public string tdomingo3;
    public string hdomingo4;
    public string tdomingo4;
    public string hdomingo5;
    public string tdomingo5;
    public string hdomingo6;
    public string tdomingo6;

    public string hsabado1;
    public string tsabado1;
    public string hsabado2;
    public string tsabado2;
    public string hsabado3;
    public string tsabado3;
    public string hsabado4;
    public string tsabado4;
    public string hsabado5;
    public string tsabado5;
    public string hsabado6;
    public string tsabado6;

    public string hsexta1;
    public string tsexta1;
    public string hsexta2;
    public string tsexta2;
    public string hsexta3;
    public string tsexta3;
    public string hsexta4;
    public string tsexta4;
    public string hsexta5;
    public string tsexta5;
    public string hsexta6;
    public string tsexta6;

    public string hquinta1; 
    public string tquinta1; 
    public string hquinta2; 
    public string tquinta2; 
    public string hquinta3; 
    public string tquinta3; 
    public string hquinta4; 
    public string tquinta4; 
    public string hquinta5; 
    public string tquinta5; 
    public string hquinta6; 
    public string tquinta6; 

    public string hquarta1; 
    public string tquarta1; 
    public string hquarta2; 
    public string tquarta2; 
    public string hquarta3; 
    public string tquarta3; 
    public string hquarta4; 
    public string tquarta4; 
    public string hquarta5; 
    public string tquarta5; 
    public string hquarta6; 
    public string tquarta6; 

    public string hsegunda1;
    public string tsegunda1;
    public string hsegunda2;
    public string tsegunda2;
    public string hsegunda3;
    public string tsegunda3;
    public string hsegunda4;
    public string tsegunda4;
    public string hsegunda5;
    public string tsegunda5;
    public string hsegunda6;
    public string tsegunda6;

    public string hterca1;
    public string tterca1;
    public string hterca2;
    public string tterca2;
    public string hterca3;
    public string tterca3;
    public string hterca4;
    public string tterca4;
    public string hterca5;
    public string tterca5;
    public string hterca6;
    public string tterca6;

    public int domingo;
    public int sabado;
    public int sexta;
    public int segunda;
    public int terca;
    public int quinta; 
    public int quarta;

   

    // progresso materias
    public int mat;
    public int mata;
    public int mate;

    public int cieh;
    public int cien;
    public int ling;
    public int ing;
    public int esp;

    public int cieha;
    public int ciena;
    public int linga;
    public int inga;
    public int espa;


    public int ciehe;
    public int ciene;
    public int linge;
    public int inge;
    public int espe;

    public int inglespanhol;


    // Adicionando variáveis para Filosofia
    public int filo;  // Controle geral para Filosofia
    public int filoa; // Acertos em Filosofia
    public int filoe; // Erros em Filosofia

    // Adicionando variáveis para Geografia
    public int geog;
    public int geoga; 
    public int geoge;

    // Adicionando variáveis para Quimica
    public int quim;
    public int quima;
    public int quime;

    // Adicionando variáveis para Portugues
    public int port;
    public int porta;
    public int porte;

    // Adicionando variáveis para fisica
    public int fisi;
    public int fisia;
    public int fisie;


    // Adicionando variáveis para biologia
    public int biol;
    public int biola;
    public int biole;

    // Adicionando variáveis para sociologia
    public int soci;
    public int socia;
    public int socie;

    // Adicionando variáveis para historia
    public int hist;
    public int hista;
    public int histe;

    // Adicionando variáveis para artes
    public int art;
    public int arta;
    public int arte;

    // Adicionando variáveis para Idiomas
    public int Idio;
    public int Idioa;
    public int Idioe;

    // Adicionando variáveis para literatura
    public int lite;
    public int litea;
    public int litee;

    public Character(

        Dictionary<string, int> progressoDiario,
        bool apagouconta,
        bool preencheu,
        string celular,

        int medalha2sg,
        int medalha4sg,
        int medalhaTdsMtrs,
        int medalha10questions,
        int medalha10questionsTdsMtrs,
        int medalhafinal,

    string tdomingo1, string hdomingo1,
        string tdomingo2, string hdomingo2,
        string tdomingo3, string hdomingo3,
        string tdomingo4, string hdomingo4,
        string tdomingo5, string hdomingo5,
        string tdomingo6, string hdomingo6,


        string tsabado1, string hsabado1,
        string tsabado2, string hsabado2,
        string tsabado3, string hsabado3,
        string tsabado4, string hsabado4,
        string tsabado5, string hsabado5,
        string tsabado6, string hsabado6,

         string tsexta1, string hsexta1,
        string tsexta2, string hsexta2,
        string tsexta3, string hsexta3,
        string tsexta4, string hsexta4,
        string tsexta5, string hsexta5,
        string tsexta6, string hsexta6,


        string tquarta1, string hquarta1, 
        string tquarta2, string hquarta2, 
        string tquarta3, string hquarta3, 
        string tquarta4, string hquarta4, 
        string tquarta5, string hquarta5, 
        string tquarta6, string hquarta6, 

        string tquinta1, string hquinta1, 
        string tquinta2, string hquinta2, 
        string tquinta3, string hquinta3, 
        string tquinta4, string hquinta4, 
        string tquinta5, string hquinta5, 
        string tquinta6, string hquinta6, 

        string tterca1, string hterca1,
        string tterca2, string hterca2,
        string tterca3, string hterca3,
        string tterca4, string hterca4,
        string tterca5, string hterca5,
        string tterca6, string hterca6,

        string tsegunda1, string hsegunda1,
        string tsegunda2, string hsegunda2,
        string tsegunda3, string hsegunda3,
        string tsegunda4, string hsegunda4,
        string tsegunda5, string hsegunda5,
        string tsegunda6, string hsegunda6,

        int domingo,
        int sabado,
        int sexta,
        int quarta,
        int quinta,
        int terca,
        int segunda,

        // Adicionando novos parâmetros no final
        int mat, int mata, int mate, int cieh, int cien, int ling, int ing, int esp, int cieha,
        int ciena, int linga, int inga, int espa, int ciehe, int ciene, int linge, int inge, int espe, int inglespanhol, int filo, int filoa, int filoe, int geog, int geoga, int geoge,
        int quim, int quima, int quime, int port, int porta, int porte, int fisi, int fisia, int fisie, int biol, int biola, int biole, int soci, int socia, int socie, int hist, int hista, int histe,
        int art, int arta, int arte, int Idio, int Idioa, int Idioe, int lite, int litea, int litee)


    {
        this.apagouconta = apagouconta;
        this.preencheu = preencheu;
        this.celular = celular;
        this.medalha2sg = medalha2sg;
         this.medalha4sg = medalha4sg;
         this.medalhaTdsMtrs = medalhaTdsMtrs;
         this.medalha10questions = medalha10questions;
         this.medalha10questionsTdsMtrs = medalha10questionsTdsMtrs;
         this.medalhafinal = medalhafinal;

        this.tdomingo1 = tdomingo1;
        this.hdomingo1 = hdomingo1;
        this.tdomingo2 = tdomingo2;
        this.hdomingo2 = hdomingo2;
        this.tdomingo3 = tdomingo3;
        this.hdomingo3 = hdomingo3;
        this.tdomingo4 = tdomingo4;
        this.hdomingo4 = hdomingo4;
        this.tdomingo5 = tdomingo5;
        this.hdomingo5 = hdomingo5;
        this.tdomingo6 = tdomingo6;
        this.hdomingo6 = hdomingo6;

        this.tsabado1 = tsabado1;
        this.hsabado1 = hsabado1;
        this.tsabado2 = tsabado2;
        this.hsabado2 = hsabado2;
        this.tsabado3 = tsabado3;
        this.hsabado3 = hsabado3;
        this.tsabado4 = tsabado4;
        this.hsabado4 = hsabado4;
        this.tsabado5 = tsabado5;
        this.hsabado5 = hsabado5;
        this.tsabado6 = tsabado6;
        this.hsabado6 = hsabado6;

        this.tsexta1 = tsexta1;
        this.hsexta1 = hsexta1;
        this.tsexta2 = tsexta2;
        this.hsexta2 = hsexta2;
        this.tsexta3 = tsexta3;
        this.hsexta3 = hsexta3;
        this.tsexta4 = tsexta4;
        this.hsexta4 = hsexta4;
        this.tsexta5 = tsexta5;
        this.hsexta5 = hsexta5;
        this.tsexta6 = tsexta6;
        this.hsexta6 = hsexta6;

        this.tquarta1 = tquarta1;
        this.hquarta1 = hquarta1;
        this.tquarta2 = tquarta2;
        this.hquarta2 = hquarta2;
        this.tquarta3 = tquarta3;
        this.hquarta3 = hquarta3;
        this.tquarta4 = tquarta4;
        this.hquarta4 = hquarta4;
        this.tquarta5 = tquarta5;
        this.hquarta5 = hquarta5;
        this.tquarta6 = tquarta6;
        this.hquarta6 = hquarta6;

        this.tquinta1 = tquinta1;
        this.hquinta1 = hquinta1;
        this.tquinta2 = tquinta2;
        this.hquinta2 = hquinta2;
        this.tquinta3 = tquinta3;
        this.hquinta3 = hquinta3;
        this.tquinta4 = tquinta4;
        this.hquinta4 = hquinta4;
        this.tquinta5 = tquinta5;
        this.hquinta5 = hquinta5;
        this.tquinta6 = tquinta6;
        this.hquinta6 = hquinta6;

        this.tterca1 = tterca1;
        this.hterca1 = hterca1;
        this.tterca2 = tterca2;
        this.hterca2 = hterca2;
        this.tterca3 = tterca3;
        this.hterca3 = hterca3;
        this.tterca4 = tterca4;
        this.hterca4 = hterca4;
        this.tterca5 = tterca5;
        this.hterca5 = hterca5;
        this.tterca6 = tterca6;
        this.hterca6 = hterca6;

        this.tsegunda1 = tsegunda1;
        this.hsegunda1 = hsegunda1;
        this.tsegunda2 = tsegunda2;
        this.hsegunda2 = hsegunda2;
        this.tsegunda3 = tsegunda3;
        this.hsegunda3 = hsegunda3;
        this.tsegunda4 = tsegunda4;
        this.hsegunda4 = hsegunda4;
        this.tsegunda5 = tsegunda5;
        this.hsegunda5 = hsegunda5;
        this.tsegunda6 = tsegunda6;
        this.hsegunda6 = hsegunda6;

        this.domingo = domingo;
        this.sabado = sabado;
        this.sexta = sexta;
        this.quarta = quarta;
        this.quinta = quinta;
        this.segunda = segunda;
        this.terca = terca;

        this.mat = mat;
        this.mata = mata;
        this.mate = mate;

        this.cieh = cieh;
        this.cien = cien;
        this.ling = ling;
        this.ing = ing;
        this.esp = esp;
        this.cieha = cieha;
        this.ciena = ciena;
        this.linga = linga;
        this.inga = inga;
        this.espa = espa;
        this.ciehe = ciehe;
        this.ciene = ciene;
        this.linge = linge;
        this.inge = inge;
        this.espe = espe;
        this.inglespanhol = inglespanhol;

        // Inicializando as novas variáveis de Filosofia
        this.filo = filo;
        this.filoa = filoa;
        this.filoe = filoe;

        // Inicializando as novas variáveis de Geografia
        this.geog = geog;
        this.geoga = geoga;
        this.geoge = geoge;

        // Inicializando as novas variáveis de Quimica
        this.quim = quim;
        this.quima = quima;
        this.quime = quime;
        // Inicializando as novas variáveis de portugues
        this.port = port;
        this.porta = porta;
        this.porte = porte;

        // Inicializando as novas variáveis de fisica
        this.fisi = fisi;
        this.fisia = fisia;
        this.fisie = fisie;

        // Inicializando as novas variáveis de biologia
        this.biol = biol;
        this.biola = biola;
        this.biole = biole;

        // Inicializando as novas variáveis de sociologia
        this.soci = soci;
        this.socia = socia;
        this.socie = socie;

        // Inicializando as novas variáveis de historia
        this.hist = hist;
        this.hista = hista;
        this.histe = histe;

        // Inicializando as novas variáveis de artes
        this.art = art;
        this.arta = arta;
        this.arte = arte;

        // Inicializando as novas variáveis de Idiomas
        this.Idio = Idio;
        this.Idioa = Idioa;
        this.Idioe = Idioe;

        // Inicializando as novas variáveis de literatura
        this.lite = lite;
        this.litea = litea;
        this.litee = litee;


    }
}

public class CharacterBox : MonoBehaviour{
    public Character ReturnClass()
    {
        return new Character(

        progressoDiario: ProgressoDiarioManager.GetProgressoDiario(),
        controleui.apagouconta,
        PlayfabManager.preencheu,
        PlayfabManager.celular,

        medalhas.medalha2sg,
        medalhas.medalha4sg,
        medalhas.medalhaTdsMtrs,
        medalhas.medalha10questions,
        medalhas.medalha10questionsTdsMtrs,
        medalhas.medalhafinal,

            tarefas.tdomingo1, tarefas.hdomingo1,
            tarefas.tdomingo2, tarefas.hdomingo2,
            tarefas.tdomingo3, tarefas.hdomingo3,
            tarefas.tdomingo4, tarefas.hdomingo4,
            tarefas.tdomingo5, tarefas.hdomingo5,
            tarefas.tdomingo6, tarefas.hdomingo6,

             tarefas.tsabado1, tarefas.hsabado1,
            tarefas.tsabado2, tarefas.hsabado2,
            tarefas.tsabado3, tarefas.hsabado3,
            tarefas.tsabado4, tarefas.hsabado4,
            tarefas.tsabado5, tarefas.hsabado5,
            tarefas.tsabado6, tarefas.hsabado6,

            tarefas.tsexta1, tarefas.hsexta1,
            tarefas.tsexta2, tarefas.hsexta2,
            tarefas.tsexta3, tarefas.hsexta3,
            tarefas.tsexta4, tarefas.hsexta4,
            tarefas.tsexta5, tarefas.hsexta5,
            tarefas.tsexta6, tarefas.hsexta6,

            tarefas.tquarta1, tarefas.hquarta1,
            tarefas.tquarta2, tarefas.hquarta2,
            tarefas.tquarta3, tarefas.hquarta3,
            tarefas.tquarta4, tarefas.hquarta4,
            tarefas.tquarta5, tarefas.hquarta5,
            tarefas.tquarta6, tarefas.hquarta6,

            tarefas.tquinta1, tarefas.hquinta1,
            tarefas.tquinta2, tarefas.hquinta2,
            tarefas.tquinta3, tarefas.hquinta3,
            tarefas.tquinta4, tarefas.hquinta4,
            tarefas.tquinta5, tarefas.hquinta5,
            tarefas.tquinta6, tarefas.hquinta6,

            tarefas.tterca1, tarefas.hterca1,  
            tarefas.tterca2, tarefas.hterca2,  
            tarefas.tterca3, tarefas.hterca3,  
            tarefas.tterca4, tarefas.hterca4,  
            tarefas.tterca5, tarefas.hterca5,  
            tarefas.tterca6, tarefas.hterca6,

            tarefas.tsegunda1 ,tarefas.hsegunda1,
            tarefas.tsegunda2, tarefas.hsegunda2,
            tarefas.tsegunda3, tarefas.hsegunda3,
            tarefas.tsegunda4, tarefas.hsegunda4,
            tarefas.tsegunda5, tarefas.hsegunda5,
            tarefas.tsegunda6, tarefas.hsegunda6,

            tarefas.domingo,
            tarefas.sabado,
            tarefas.sexta,
            tarefas.quarta,
            tarefas.quinta, 
            tarefas.segunda,
            tarefas.terca,
            // Adicionando Filosofia 3 finais
            Matematic.control, Matematic.acertos, Matematic.erros, ciehumanas.control,ciedanatureza.control, linguagens.control,
            ingles.control, espanhol.control, ciehumanas.acertos, ciedanatureza.acertos, linguagens.acertos, ingles.acertos,
            espanhol.acertos,  ciehumanas.erros, ciedanatureza.erros, linguagens.erros, ingles.erros, espanhol.erros, questions.inglespanhol, filosofia.control, filosofia.acertos, filosofia.erros, geografia.control, geografia.acertos, geografia.erros,
             Quimica.control, Quimica.acertos, Quimica.erros, portugues.control, portugues.acertos, portugues.erros, fisica.control, fisica.acertos, fisica.erros, biologia.control, biologia.acertos, biologia.erros, sociologia.control, sociologia.acertos, sociologia.erros, historia.control, historia.acertos, historia.erros,
             artes.control, artes.acertos, artes.erros, artes.control, artes.acertos, artes.erros, literatura.control, literatura.acertos, literatura.erros);
    }  

   public void SetUi(Character character)
    {
        ProgressoDiarioManager.SetProgressoDiario(character.progressoDiario);
        controleui.apagouconta = character.apagouconta;
        PlayfabManager.preencheu = character.preencheu;
        PlayfabManager.celular = character.celular;

        medalhas.medalha2sg = character.medalha2sg;
        medalhas.medalha4sg = character.medalha4sg;
        medalhas.medalhaTdsMtrs = character.medalhaTdsMtrs;
        medalhas.medalha10questions = character.medalha10questions;
        medalhas.medalha10questionsTdsMtrs = character.medalha10questionsTdsMtrs;
        medalhas.medalhafinal = character.medalhafinal;

        tarefas.hdomingo1 = character.hdomingo1;
        tarefas.tdomingo1 = character.tdomingo1;

        tarefas.hdomingo2 = character.hdomingo2;
        tarefas.tdomingo2 = character.tdomingo2;

        tarefas.hdomingo3 = character.hdomingo3;
        tarefas.tdomingo3 = character.tdomingo3;

        tarefas.hdomingo4 = character.hdomingo4;
        tarefas.tdomingo4 = character.tdomingo4;

        tarefas.hdomingo5 = character.hdomingo5;
        tarefas.tdomingo5 = character.tdomingo5;

        tarefas.hdomingo6 = character.hdomingo6;
        tarefas.tdomingo6 = character.tdomingo6;
        tarefas.domingo = character.domingo;

        tarefas.sabado = character.sabado;
        tarefas.hsabado1 = character.hsabado1;
        tarefas.tsabado1 = character.tsabado1;

        tarefas.hsabado2 = character.hsabado2;
        tarefas.tsabado2 = character.tsabado2;

        tarefas.hsabado3 = character.hsabado3;
        tarefas.tsabado3 = character.tsabado3;

        tarefas.hsabado4 = character.hsabado4;
        tarefas.tsabado4 = character.tsabado4;

        tarefas.hsabado5 = character.hsabado5;
        tarefas.tsabado5 = character.tsabado5;

        tarefas.hsabado6 = character.hsabado6;
        tarefas.tsabado6 = character.tsabado6;

        tarefas.sexta = character.sexta;
        tarefas.hsexta1 = character.hsexta1;
        tarefas.tsexta1 = character.tsexta1;

        tarefas.hsexta2 = character.hsexta2;
        tarefas.tsexta2 = character.tsexta2;

        tarefas.hsexta3 = character.hsexta3;
        tarefas.tsexta3 = character.tsexta3;

        tarefas.hsexta4 = character.hsexta4;
        tarefas.tsexta4 = character.tsexta4;

        tarefas.hsexta5 = character.hsexta5;
        tarefas.tsexta5 = character.tsexta5;

        tarefas.hsexta6 = character.hsexta6;
        tarefas.tsexta6 = character.tsexta6;

        tarefas.hquarta1 = character.hquarta1; 
        tarefas.tquarta1 = character.tquarta1; 

        tarefas.hquarta2 = character.hquarta2; 
        tarefas.tquarta2 = character.tquarta2; 

        tarefas.hquarta3 = character.hquarta3; 
        tarefas.tquarta3 = character.tquarta3; 

        tarefas.hquarta4 = character.hquarta4; 
        tarefas.tquarta4 = character.tquarta4; 

        tarefas.hquarta5 = character.hquarta5; 
        tarefas.tquarta5 = character.tquarta5; 

        tarefas.hquarta6 = character.hquarta6; 
        tarefas.tquarta6 = character.tquarta6; 

        tarefas.quarta = character.quarta; 

        tarefas.hquinta1 = character.hquinta1; 
        tarefas.tquinta1 = character.tquinta1; 

        tarefas.hquinta2 = character.hquinta2; 
        tarefas.tquinta2 = character.tquinta2; 

        tarefas.hquinta3 = character.hquinta3; 
        tarefas.tquinta3 = character.tquinta3; 

        tarefas.hquinta4 = character.hquinta4; 
        tarefas.tquinta4 = character.tquinta4; 

        tarefas.hquinta5 = character.hquinta5; 
        tarefas.tquinta5 = character.tquinta5; 

        tarefas.hquinta6 = character.hquinta6; 
        tarefas.tquinta6 = character.tquinta6; 

        tarefas.hterca1 = character.hterca1; 
        tarefas.tterca1 = character.tterca1; 

        tarefas.hterca2 = character.hterca2; 
        tarefas.tterca2 = character.tterca2; 

        tarefas.hterca3 = character.hterca3; 
        tarefas.tterca3 = character.tterca3; 

        tarefas.hterca4 = character.hterca4; 
        tarefas.tterca4 = character.tterca4; 

        tarefas.hterca5 = character.hterca5; 
        tarefas.tterca5 = character.tterca5; 

        tarefas.hterca6 = character.hterca6; 
        tarefas.tterca6 = character.tterca6; 

        tarefas.terca = character.terca;

        tarefas.hsegunda1 = character.hsegunda1;
        tarefas.tsegunda1 = character.tsegunda1;

        tarefas.hsegunda2 = character.hsegunda2;
        tarefas.tsegunda2= character.tsegunda2;

        tarefas.hsegunda3 = character.hsegunda3;
        tarefas.tsegunda3 = character.tsegunda3;

        tarefas.hsegunda4 = character.hsegunda4;
        tarefas.tsegunda4 = character.tsegunda4;

        tarefas.hsegunda5 = character.hsegunda5;
        tarefas.tsegunda5 = character.tsegunda5;

        tarefas.hsegunda6 = character.hsegunda6;
        tarefas.tsegunda6 = character.tsegunda6;

        tarefas.segunda = character.segunda;

        tarefas.quinta = character.quinta;

        Matematic.control = character.mat;
        Matematic.acertos = character.mata;
        Matematic.erros = character.mate;


        // Adicionando a atualização da UI para Filosofia
        filosofia.control = character.filo;
        filosofia.acertos = character.filoa;
        filosofia.erros = character.filoe;

        // Adicionando a atualização da UI para geografia
        geografia.control = character.geog;
        geografia.acertos = character.geoga;
        geografia.erros = character.geoge;

        // Adicionando a atualização da UI para geografia
        Quimica.control = character.quim;
        Quimica.acertos = character.quima;
        Quimica.erros = character.quime;

        // Adicionando a atualização da UI para portugues
        portugues.control = character.port;
        portugues.acertos = character.porta;
        portugues.erros = character.porte;

        // Adicionando a atualização da UI para fisica
        fisica.control = character.fisi;
        fisica.acertos = character.fisia;
        fisica.erros = character.fisie;

        // Adicionando a atualização da UI para biologia
        biologia.control = character.biol;
        biologia.acertos = character.biola;
        biologia.erros = character.biole;

        // Adicionando a atualização da UI para sociologia
        sociologia.control = character.soci;
        sociologia.acertos = character.socia;
        sociologia.erros = character.socie;

        // Adicionando a atualização da UI para historia
        historia.control = character.hist;
        historia.acertos = character.hista;
        historia.erros = character.histe;

        // Adicionando a atualização da UI para artes
        artes.control = character.art;
        artes.acertos = character.arta;
        artes.erros = character.arte;

        // Adicionando a atualização da UI para Idiomas
        Idiomas.control = character.Idio;
        Idiomas.acertos = character.Idioa;
        Idiomas.erros = character.Idioe;

        // Adicionando a atualização da UI para literatura
        literatura.control = character.lite;
        literatura.acertos = character.litea;
        literatura.erros = character.litee;

        ciehumanas.control = character.cieh;
        ciedanatureza.control = character.cien;
        linguagens.control = character.ling;
        ingles.control = character.ing;
        espanhol.control = character.esp;

        ciehumanas.acertos = character.cieha;
        ciedanatureza.acertos = character.ciena;
        linguagens.acertos = character.linga;
        ingles.acertos = character.inga;
        espanhol.acertos = character.espa;

        ciehumanas.erros = character.ciehe;
        ciedanatureza.erros = character.ciene;
        linguagens.erros = character.linge;
        ingles.erros = character.inge;
        espanhol.erros = character.espe;
        questions.inglespanhol = character.inglespanhol;
    }
    
}

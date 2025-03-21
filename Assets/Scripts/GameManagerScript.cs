using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManagerScript : MonoBehaviour
{
    public int value; // A variável int que será alterada
    public TextMeshProUGUI valueText;

    public GameObject[] array1; 
    public GameObject[] array2; 
    public GameObject[] array3; 
    public GameObject[] array4;
    public GameObject[] array5;
    public GameObject[] array6;
    public GameObject[] array7;
    public GameObject[] array8;
    public GameObject[] array9;
    public GameObject[] array10;
    public GameObject[] array11;
    public GameObject[] array12;
    public GameObject[] array13;
    public GameObject[] array14;
    public GameObject[] array15;
    public GameObject[] array16;
    public GameObject[] array17;
    public GameObject[] array18;
    public GameObject[] array19;
    public GameObject[] array20;
    public GameObject[] array21;
    public GameObject[] array22;
    public GameObject[] array23;
    public GameObject[] array24;
    public GameObject[] array25;
    public GameObject[] array26;
    public GameObject[] array27;
    public GameObject[] array28;
    public GameObject[] array29;
    public GameObject[] array30;
    public GameObject[] array31;
    public GameObject[] array32;
    public GameObject[] array33;
    public GameObject[] array34;
    public GameObject[] array35;
    public GameObject[] array36;
    public GameObject[] array37;
    public GameObject[] array38;
    public GameObject[] array39;
    public GameObject[] array40;
    public GameObject[] array41;
    public GameObject[] array42;
    public GameObject[] array43;
    public GameObject[] array44;
    public GameObject[] array45;
    public GameObject[] array46;
    public GameObject[] array47;
    public GameObject[] array48;
    public GameObject[] array49;
    public GameObject[] array50;
    public GameObject[] array51;
    public GameObject[] array52;
    public GameObject[] array53;
    public GameObject[] array54;
    public GameObject[] array55;
    public GameObject[] array56;

    // Start is called before the first frame update
    void Start()
    {
        UpdateValueText();
        UpdateGameObjects();
    }

    // Função para definir o valor
    public void SetValue(int newValue)
    {
        value = newValue;
        UpdateValueText();
        UpdateGameObjects();
    }

    // Atualiza o texto do UI para mostrar o valor atual
    void UpdateValueText()
    {
         valueText.text = "Value: " + value.ToString();
    }

    // Atualiza os GameObjects com base no valor atual
    void UpdateGameObjects()
    {
        // Desabilita todos os GameObjects nos arrays
        foreach (GameObject go in array1)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array2)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array3)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array4)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array5)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array6)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array7)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array8)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array9)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array10)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array11)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array12)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array13)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array14)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array15)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array16)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array17)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array18)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array19)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array20)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array21)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array22)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array23)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array24)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array25)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array26)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array27)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array28)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array29)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array30)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array31)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array32)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array33)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array34)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array35)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array36)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array37)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array38)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array39)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array40)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array41)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array42)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array43)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array44)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array45)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array46)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array47)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array48)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array49)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array50)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array51)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array52)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array53)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array54)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array55)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in array56)
        {
            go.SetActive(false);
        }


        // Habilita o array correspondente ao valor
        if (value == 1)
        {
            valueText.text = "Literatura no Enem";
            foreach (GameObject go in array1)
            {
                go.SetActive(true);
            }
        }
        else if (value == 2)
        {
            valueText.text = "Portugues no Enem";
            foreach (GameObject go in array2)
            {
                go.SetActive(true);
            }
        }
        else if (value == 3)
        {
            valueText.text = "Idiomas no Enem";
            foreach (GameObject go in array3)
            {
                go.SetActive(true);
            }
        }
        else if (value == 4)
        {
            valueText.text = "Historia da Arte no Enem";
            foreach (GameObject go in array4)
            {
                go.SetActive(true);
            }
        }
        else if (value == 5)
        {
            valueText.text = "História do Brasil";
            foreach (GameObject go in array5)
            {
                go.SetActive(true);
            }
        }
        else if (value == 6)
        {
            valueText.text = "Idade Antiga e Média";
            foreach (GameObject go in array6)
            {
                go.SetActive(true);
            }
        }
        else if (value == 7)
        {
            valueText.text = "Idade Moderna";
            foreach (GameObject go in array7)
            {
                go.SetActive(true);
            }
        }
        else if (value == 8)
        {
            valueText.text = "Idade Contemporânea";
            foreach (GameObject go in array8)
            {
                go.SetActive(true);
            }
        }
        else if (value == 9)
        {
            valueText.text = "Trabalho";
            foreach (GameObject go in array9)
            {
                go.SetActive(true);
            }
        }
        else if (value == 10)
        {
            valueText.text = "Cidadania";
            foreach (GameObject go in array10)
            {
                go.SetActive(true);
            }
        }
        else if (value == 11)
        {
            valueText.text = "Cultura";
            foreach (GameObject go in array11)
            {
                go.SetActive(true);
            }
        }
        else if (value == 12)
        {
            valueText.text = "Democracia";
            foreach (GameObject go in array12)
            {
                go.SetActive(true);
            }
        }
        else if (value == 13)
        {
            valueText.text = "Filosofia Temática";
            foreach (GameObject go in array13)
            {
                go.SetActive(true);
            }
        }
        else if (value == 14)
        {
            valueText.text = "Filosofia Antiga";
            foreach (GameObject go in array14)
            {
                go.SetActive(true);
            }
        }
        else if (value == 15)
        {
            valueText.text = "Filosofia Medieval";
            foreach (GameObject go in array15)
            {
                go.SetActive(true);
            }
        }
        else if (value == 16)
        {
            valueText.text = "Filosofia Moderna";
            foreach (GameObject go in array16)
            {
                go.SetActive(true);
            }
        }
        else if (value == 17)
        {
            valueText.text = "Filósofos";
            foreach (GameObject go in array17)
            {
                go.SetActive(true);
            }
        }
        else if (value == 18)
        {
            valueText.text = "Filosofia Contemporânea";
            foreach (GameObject go in array18)
            {
                go.SetActive(true);
            }
        }
        else if (value == 19)
        {
            valueText.text = "Biologia Meio-ambiente e Mundo Vegetal";
            foreach (GameObject go in array19)
            {
                go.SetActive(true);
            }
        }
        else if (value == 20)
        {
            valueText.text = "Genética";
            foreach (GameObject go in array20)
            {
                go.SetActive(true);
            }
        }
        else if (value == 21)
        {
            valueText.text = "Corpo Humano e Saúde";
            foreach (GameObject go in array21)
            {
                go.SetActive(true);
            }
        }
        else if (value == 22)
        {
            valueText.text = "Citologia";
            foreach (GameObject go in array22)
            {
                go.SetActive(true);
            }
        }
        else if (value == 23)
        {
            valueText.text = "Bioquímica";
            foreach (GameObject go in array23)
            {
                go.SetActive(true);
            }
        }
        else if (value == 24)
        {
            valueText.text = "mecânica";
            foreach (GameObject go in array24)
            {
                go.SetActive(true);
            }
        }
        else if (value == 25)
        {
            valueText.text = "termologia e termodinâmica";
            foreach (GameObject go in array25)
            {
                go.SetActive(true);
            }
        }
        else if (value == 26)
        {
            valueText.text = "eletricidade e eletromagnetismo";
            foreach (GameObject go in array26)
            {
                go.SetActive(true);
            }
        }
        else if (value == 27)
        {
            valueText.text = "ondulatória e óptica";
            foreach (GameObject go in array27)
            {
                go.SetActive(true);
            }
        }
        else if (value == 28)
        {
            valueText.text = "fisica moderna";
            foreach (GameObject go in array28)
            {
                go.SetActive(true);
            }
        }
        else if (value == 29)
        {
            valueText.text = "Geografia Econômica";
            foreach (GameObject go in array29)
            {
                go.SetActive(true);
            }
        }
        else if (value == 30)
        {
            valueText.text = "Blocos Econômicos";
            foreach (GameObject go in array30)
            {
                go.SetActive(true);
            }
        }
        else if (value == 31)
        {
            valueText.text = "Geografia Humana";
            foreach (GameObject go in array31)
            {
                go.SetActive(true);
            }
        }
        else if (value == 32)
        {
            valueText.text = "Geografia Física";
            foreach (GameObject go in array32)
            {
                go.SetActive(true);
            }
        }
        else if (value == 33)
        {
            valueText.text = "Química Geral";
            foreach (GameObject go in array33)
            {
                go.SetActive(true);
            }
        }
        else if (value == 34)
        {
            valueText.text = "Fisico-quimica";
            foreach (GameObject go in array34)
            {
                go.SetActive(true);
            }
        }
        else if (value == 35)
        {
            valueText.text = "Química Ambiental";
            foreach (GameObject go in array35)
            {
                go.SetActive(true);
            }
        }
        else if (value == 36)
        {
            valueText.text = "Química orgânica";
            foreach (GameObject go in array36)
            {
                go.SetActive(true);
            }
        }
        else if (value == 37)
        {
            valueText.text = "Química Inorgânica";
            foreach (GameObject go in array37)
            {
                go.SetActive(true);
            }
        }
        else if (value == 38)
        {
            valueText.text = "Matemática Básica";
            foreach (GameObject go in array38)
            {
                go.SetActive(true);
            }
        }
        else if (value == 39)
        {
            valueText.text = "Vestibulares";
            foreach (GameObject go in array39)
            {
                go.SetActive(true);
            }
        }
        else if (value == 40)
        {
            valueText.text = "Vestibulares";
            foreach (GameObject go in array40)
            {
                go.SetActive(true);
            }
        }
        else if (value == 41)
        {
            valueText.text = "Vestibulares";
            foreach (GameObject go in array41)
            {
                go.SetActive(true);
            }
        }
        else if (value == 42)
        {
            valueText.text = "Vestibulares";
            foreach (GameObject go in array42)
            {
                go.SetActive(true);
            }
        }
        else if (value == 43)
        {
            valueText.text = "Vestibulares";
            foreach (GameObject go in array43)
            {
                go.SetActive(true);
            }
        }
        else if (value == 44)
        {
            valueText.text = "Vestibulares";
            foreach (GameObject go in array44)
            {
                go.SetActive(true);
            }
        }
        else if (value == 45)
        {
            valueText.text = "Vestibulares";
            foreach (GameObject go in array45)
            {
                go.SetActive(true);
            }
        }
        else if (value == 46)
        {
            valueText.text = "Vestibulares";
            foreach (GameObject go in array46)
            {
                go.SetActive(true);
            }
        }
        else if (value == 47)
        {
            valueText.text = "Vestibulares";
            foreach (GameObject go in array47)
            {
                go.SetActive(true);
            }
        }
        else if (value == 48)
        {
            valueText.text = "Vestibulares";
            foreach (GameObject go in array48)
            {
                go.SetActive(true);
            }
        }
        else if (value == 49)
        {
            valueText.text = "Literatura no Enem";
            foreach (GameObject go in array49)
            {
                go.SetActive(true);
            }
        }
        else if (value == 50)
        {
            valueText.text = "Vestibulares";
            foreach (GameObject go in array50)
            {
                go.SetActive(true);
            }
        }
        else if (value == 51)
        {
            valueText.text = "Literatura no Enem";
            foreach (GameObject go in array51)
            {
                go.SetActive(true);
            }
        }
        else if (value == 52)
        {
            valueText.text = "Vestibulares";
            foreach (GameObject go in array52)
            {
                go.SetActive(true);
            }
        }
        else if (value == 53)
        {
            valueText.text = "Literatura no Enem";
            foreach (GameObject go in array53)
            {
                go.SetActive(true);
            }
        }
        else if (value == 54)
        {
            valueText.text = "Vestibulares";
            foreach (GameObject go in array54)
            {
                go.SetActive(true);
            }
        }
        else if (value == 55)
        {
            valueText.text = "Idiomas no Enem";
            foreach (GameObject go in array55)
            {
                go.SetActive(true);
            }
        }
        else if (value == 56)
        {
            valueText.text = "Vestibulares";
            foreach (GameObject go in array56)
            {
                go.SetActive(true);
            }
        }

    }
}

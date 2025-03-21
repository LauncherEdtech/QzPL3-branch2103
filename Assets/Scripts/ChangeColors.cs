using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeColors : MonoBehaviour
{
    public List<Image> panels;
    public List<TMP_Text> textElements = new List<TMP_Text>();
    public static int colorblackwhite = 1;
    public Color targetColor;
    public Color targetColor2;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("colorblackwhite", colorblackwhite);
        colorblackwhite = PlayerPrefs.GetInt("colorblackwhite", colorblackwhite);
        if (colorblackwhite == 1)
        {
            foreach (TMP_Text textElement in textElements)
            {
                textElement.color = targetColor2;
            }

            foreach (Image panel in panels)
            {
                panel.color = targetColor;
            }
        }

        if (colorblackwhite == 0)
        {
            foreach (TMP_Text textElement in textElements)
            {
                textElement.color = targetColor;
            }

            foreach (Image panel in panels)
            {
                panel.color = targetColor2;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void white()
    {
        colorblackwhite = 1;

            foreach (TMP_Text textElement in textElements)
            {
                textElement.color = targetColor2;
            }

            foreach (Image panel in panels)
            {
                panel.color = targetColor;
            }
        
        PlayerPrefs.SetInt("colorblackwhite", colorblackwhite);
    }

    public void black()
    {
        colorblackwhite = 0;

            foreach (TMP_Text textElement in textElements)
            {
                textElement.color = targetColor;
            }

            foreach (Image panel in panels)
            {
                panel.color = targetColor2;
            }
        PlayerPrefs.SetInt("colorblackwhite", colorblackwhite);
    }
}

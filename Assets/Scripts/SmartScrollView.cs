using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SmartScrollView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ScrollRect horizontalScroll;
    public ScrollRect verticalScroll;

    private bool dragHorizontal = false;

    void Awake()
    {
        // Certifique-se de que os ScrollRects n�o est�o nulos
        if (horizontalScroll == null || verticalScroll == null)
        {
            Debug.LogError("Os ScrollRects n�o est�o atribu�dos corretamente no inspector.");
            return;
        }

        // Inicializa desativando o scroll horizontal
        horizontalScroll.enabled = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Determina a dire��o do arrasto na fase inicial
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            dragHorizontal = true;
            horizontalScroll.enabled = true;
            verticalScroll.enabled = false;
        }
        else
        {
            dragHorizontal = false;
            verticalScroll.enabled = true;
            horizontalScroll.enabled = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // N�o � necess�rio implementar nada aqui, o pr�prio ScrollRect lida com o arrasto
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Reativa ambos os scrolls ap�s o t�rmino do arrasto
        horizontalScroll.enabled = true;
        verticalScroll.enabled = true;
        dragHorizontal = false;
    }
}

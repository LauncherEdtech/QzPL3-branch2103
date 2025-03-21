using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollDirectionHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ScrollRect[] horizontalScrollRects; // Array dos ScrollRects horizontais

    private ScrollRect activeHorizontalScrollRect = null; // Guarda o ScrollRect ativo
    private bool isVerticalDrag = false;

    void Start()
    {
        // Simula um movimento horizontal ao iniciar o jogo
        Invoke("SimulateHorizontalMovement", 0.5f); // Aguarda meio segundo antes de simular
    }

    void Awake()
    {
        EnableHorizontalScrolling(false); // Desabilita o scroll horizontal inicialmente
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Identifica a direção do arrasto
        isVerticalDrag = Mathf.Abs(eventData.delta.y) > Mathf.Abs(eventData.delta.x);

        if (isVerticalDrag)
        {
            EnableHorizontalScrolling(false);
        }
        else
        {
            activeHorizontalScrollRect = GetActiveScrollRect(eventData);
            EnableHorizontalScrolling(true);
            if (activeHorizontalScrollRect != null)
            {
                activeHorizontalScrollRect.OnBeginDrag(eventData);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isVerticalDrag && activeHorizontalScrollRect != null)
        {
            activeHorizontalScrollRect.OnDrag(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (activeHorizontalScrollRect != null)
        {
            activeHorizontalScrollRect.OnEndDrag(eventData);
            activeHorizontalScrollRect = null;
        }
        EnableHorizontalScrolling(false);
    }

    private void EnableHorizontalScrolling(bool enabled)
    {
        foreach (ScrollRect scrollRect in horizontalScrollRects)
        {
            scrollRect.enabled = enabled;
        }
    }

    private ScrollRect GetActiveScrollRect(PointerEventData eventData)
    {
        foreach (ScrollRect scrollRect in horizontalScrollRects)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(scrollRect.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera))
            {
                return scrollRect;
            }
        }
        return null;
    }

    private void SimulateHorizontalMovement()
    {
        if (horizontalScrollRects.Length > 0 && horizontalScrollRects[0] != null)
        {
            var firstScrollRect = horizontalScrollRects[0];
            EnableHorizontalScrolling(true);
            firstScrollRect.horizontalNormalizedPosition += 0.1f; // Ajuste conforme a necessidade para simular o movimento
            EnableHorizontalScrolling(false);
        }
    }
}

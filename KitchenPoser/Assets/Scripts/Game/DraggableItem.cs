using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Alimentos.ItemType itemType;

    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Transform originalParent;

    [HideInInspector] public bool wasDropped = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        wasDropped = false;

        transform.SetParent(canvas.transform, true);
        canvasGroup.blocksRaycasts = false;
        Debug.Log("Started dragging " + itemType);
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localPoint
        );
        rectTransform.anchoredPosition = localPoint;
        Debug.Log("Dragging " + itemType);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!wasDropped)
        {
            transform.SetParent(originalParent, true);
        }

        canvasGroup.blocksRaycasts = true;
        Debug.Log("Ended dragging " + itemType);
    }
}
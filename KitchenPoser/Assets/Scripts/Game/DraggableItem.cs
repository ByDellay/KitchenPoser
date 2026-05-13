using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Classe responsável por permitir arrastar um item da UI
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Alimentos.ItemType itemType;

    // Referência ao RectTransform do objeto
    private RectTransform rectTransform;

    // Referência ao Canvas onde o objeto está
    private Canvas canvas;

    // Controla interação e raycasts durante o drag
    private CanvasGroup canvasGroup;

    // Guarda o pai original do objeto antes de arrastar
    private Transform originalParent;

    // Executado quando o objeto é iniciado
    private void Awake()
    {
        // Pega o RectTransform do objeto
        rectTransform = GetComponent<RectTransform>();

        // Procura o Canvas pai
        canvas = GetComponentInParent<Canvas>();

        // Pega o CanvasGroup do objeto
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Chamado no momento em que o jogador começa a arrastar
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Salva o pai original
        originalParent = transform.parent;

        // Move o objeto para o Canvas principal
        transform.SetParent(canvas.transform, true);

        // Desativa raycast para permitir detectar slots abaixo
        canvasGroup.blocksRaycasts = false;
    }

    // Chamado continuamente enquanto o objeto está sendo arrastado
    public void OnDrag(PointerEventData eventData)
    {
        // Converte a posição do mouse para posição local no Canvas
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localPoint
        );

        // Move o objeto para acompanhar o mouse
        rectTransform.anchoredPosition = localPoint;
    }

    // Chamado quando o jogador solta o objeto
    public void OnEndDrag(PointerEventData eventData)
    {
        // Retorna o objeto para o pai original
        transform.SetParent(originalParent, true);

        // Reativa raycasts do objeto
        canvasGroup.blocksRaycasts = true;
    }
}
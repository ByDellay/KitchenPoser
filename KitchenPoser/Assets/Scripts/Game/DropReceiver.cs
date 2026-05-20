using UnityEngine;
using UnityEngine.EventSystems;

public class DropReceiver : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        DraggableItem item = eventData.pointerDrag.GetComponent<DraggableItem>();

        if (item != null)
        {
            item.wasDropped = true;

            GameManager.Instance.AddItem(item.itemType);
            Destroy(item.gameObject);
        }
    }
}
using UnityEngine;
using UnityEngine.EventSystems;

public class DropReceiver : MonoBehaviour, IDropHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDrop(PointerEventData eventData)
    {
        DraggableItem item =
            eventData.pointerDrag.GetComponent<DraggableItem>();

        if (item != null)
        {
            GameManager.Instance.AddItem(item.itemType);

            Destroy(item.gameObject);
        }
    }
}
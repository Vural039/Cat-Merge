using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(eventData.position);
        worldPos.z = 0;
        transform.position = worldPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        MergeManager.Instance.TryMerge(gameObject, startPos);
    }
}

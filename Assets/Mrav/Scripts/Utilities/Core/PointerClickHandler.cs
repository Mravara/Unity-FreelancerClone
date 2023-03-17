using UnityEngine;
using UnityEngine.EventSystems;

public class PointerClickHandler : UIBehaviour, IPointerDownHandler
{
    public UnityEngine.Events.UnityEvent OnPointerDownEvent;

    public UnityEngine.Events.UnityEvent OnPointerRightDownEvent;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            OnPointerDownEvent.Invoke();
        else if (eventData.button == PointerEventData.InputButton.Right)
            OnPointerRightDownEvent.Invoke();
    }
}
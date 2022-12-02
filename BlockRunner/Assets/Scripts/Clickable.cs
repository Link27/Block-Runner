using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider))]

public class Clickable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // When the mouse hovers over a clickable object, the cursor will change to a clickable hand cursor
    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseControl.instance.Clickable();
    }

    // When the mouse is removed over the clickable object, the cursor will change back to the default cursor
    public void OnPointerExit(PointerEventData eventData)
    {
        MouseControl.instance.Default();
    }
}

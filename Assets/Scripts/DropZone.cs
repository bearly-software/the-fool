

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        MinorArcanaCard c = eventData.pointerDrag.GetComponent<MinorArcanaCard>();

        c.Play();
    }
}



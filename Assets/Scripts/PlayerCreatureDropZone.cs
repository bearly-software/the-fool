using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCreatureDropZone : DropZone
{
    public override void OnDrop(PointerEventData eventData)
    {
        MinorArcanaCard card = eventData.pointerDrag.GetComponent<MinorArcanaCard>();
        Debug.Log(card);
        base.OnDrop(eventData);

    }
}
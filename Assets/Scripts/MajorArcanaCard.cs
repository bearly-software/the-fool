using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MajorArcanaCard : MonoBehaviour, IPointerDownHandler {

    //private int clickCount = 0;
    private string _card = ""; 
    private MajorAspect _aspect; 

    public void OnPointerDown(PointerEventData eventData)
    {
        this.transform.parent.GetComponent<PlayerMajorArcana>().NewActiveMajorArcana(this);
    }

    public void SetArcanaAndCard(MajorAspect majorAspect, string card, Transform parentContainer)
    {
        _aspect = majorAspect;
        _card = card;

        this.GetComponent<Text>().text = this._aspect.GetAspectName;

        if(parentContainer) {
            this.gameObject.transform.SetParent(parentContainer, false);
        }
    }

    public void UpdateEffect(Text text)
    {
        text.text = _aspect.GetAspectName;
    }

    public string AspectCardName {
        get {
            return _aspect.GetAspectName + ":" + _card;
        }
    }
}

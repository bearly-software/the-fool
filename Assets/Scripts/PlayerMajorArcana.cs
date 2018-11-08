using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMajorArcana : MonoBehaviour {

    private MajorArcanaCard _selectedArcana;

    private MajorArcanaCard _divineArcana;
    private MajorArcanaCard _mindArcana;
    private MajorArcanaCard _bodyArcana;

    //private IDictionary<MajorAspect, MajorArcanaCard> _playerArcana = new Dictionary<MajorAspect, MajorArcanaCard>();

    private readonly Color selectArcanaTextColor = new Color(0f, 0f, 0f);
    private readonly Color notSelectArcanaTextColor = new Color(1f, 1f, 1f);

    public void Awake()
    {
        //add 3 major arcana cards.
        //create a major arcana card and then give it a name.
        _divineArcana = (Instantiate(Resources.Load("Prefabs/MajorArcanaCard")) as GameObject).GetComponent<MajorArcanaCard>();
        _mindArcana = (Instantiate(Resources.Load("Prefabs/MajorArcanaCard")) as GameObject).GetComponent<MajorArcanaCard>();
        _bodyArcana = (Instantiate(Resources.Load("Prefabs/MajorArcanaCard")) as GameObject).GetComponent<MajorArcanaCard>();

        MajorAspect divineAspect = new MajorAspect("Divine");
        MajorAspect mindAspect = new MajorAspect("Mind");
        MajorAspect bodyAspect = new MajorAspect("Body");

        _divineArcana.SetArcanaAndCard(divineAspect, "The Fool", this.gameObject.transform);
        _mindArcana.SetArcanaAndCard(mindAspect, "Lovers", this.gameObject.transform);
        _bodyArcana.SetArcanaAndCard(bodyAspect, "Wheel of Fortune", this.gameObject.transform);

        _selectedArcana = _divineArcana;
    }

	void Start () 
    {
        NewActiveMajorArcana(_selectedArcana);
	}

    public void NewActiveMajorArcana(MajorArcanaCard majorArcanaCard)
    {
        //update text color to denote the select aspect

        _selectedArcana.GetComponent<Text>().color = notSelectArcanaTextColor;

        majorArcanaCard.GetComponent<Text>().color = selectArcanaTextColor;

        _selectedArcana = majorArcanaCard;

        Hand hand = GameObject.Find("PlayerHand").gameObject.GetComponent<Hand>();

        hand.ShiftArcana();
    }

    public MajorArcanaCard GetSelectedArcana { get { return _selectedArcana; } }
}

public class MajorAspect
{
    private string _aspectName;

    public MajorAspect(string aspectName)
    {
        _aspectName = aspectName;
    }

    internal string GetAspectName { get { return _aspectName; }

    }
}
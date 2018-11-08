using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour {
    
    private List<MinorArcanaCard> _hand = new List<MinorArcanaCard>();
    private readonly int _startingHandSize = 4;

    void Start()
    {
        for (int i = 0; i < _startingHandSize; i++)
        {
            DrawNewCard();
        }

        ShiftArcana();
	}

    public void DrawNewCard() {
        Deck deck = GameObject.Find("Deck").GetComponent<Deck>();
        MinorArcanaCard card = deck.Draw();
        card.MoveCard(this.gameObject.transform);
        _hand.Add(card);
        card.ChangeEffect();
    }

    public void ShiftArcana()
    {
        //iterate through the card in the hand and change the text
        foreach(MinorArcanaCard minorCard in _hand) {
            minorCard.ChangeEffect();
        }
    }
}


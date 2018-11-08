using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    private Stack<MinorArcanaCard> _deck;

    void Start () {
        _deck = new Stack<MinorArcanaCard>();
        // Use this for initialization
        //by card
        //by suit
        foreach (var suit in MinorArcanaCard.Suits)
        {
            foreach (var value in MinorArcanaCard.Values)
            {
                MinorArcanaCard minorCard = (Instantiate(Resources.Load("Prefabs/MinorArcanaCard")) as GameObject).GetComponent<MinorArcanaCard>();
                minorCard.SetCard(suit, value, this.gameObject.transform);
                _deck.Push(minorCard);
            }
        }
        Shuffle();
	}
	
    public MinorArcanaCard Draw() {
        return _deck.Pop();
    }

    public void Shuffle()
    {
        var newDeck = _deck.ToArray();
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < newDeck.Length; t++)
        {
            MinorArcanaCard tmp = newDeck[t];
            int r = Random.Range(t, newDeck.Length);
            newDeck[t] = newDeck[r];
            newDeck[r] = tmp;
        }

        _deck = new Stack<MinorArcanaCard>(newDeck);
    }
}


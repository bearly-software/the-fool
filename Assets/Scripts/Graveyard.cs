using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard : MonoBehaviour {

    private IList<MinorArcanaCard> _graveyard = new List<MinorArcanaCard>();

    public void Add(MinorArcanaCard minorArcanaCard) {
        _graveyard.Add(minorArcanaCard);
    }
}

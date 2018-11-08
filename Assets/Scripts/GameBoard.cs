using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard: MonoBehaviour {

    public void EndTurn() {
        Debug.Log("ended turn");
        //all player creatures attack!

        foreach(MinorArcanaCard c in GameObject.Find("PlayerCreatures").GetComponentsInChildren<MinorArcanaCard>()) {
            c.Attack();
        }
    }
}

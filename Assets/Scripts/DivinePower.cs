using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DivinePower : MonoBehaviour {

    private int _power = 0;

    public int AddPower(int amount) {
        _power += amount;

        UpdatePower();

        return _power;
    }

    public void Awake() {
        UpdatePower();
    }

    private void UpdatePower() {
        this.GetComponent<Text>().text = "Divine Power: " + _power.ToString();
    }
}

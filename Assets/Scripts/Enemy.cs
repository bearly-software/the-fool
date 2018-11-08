using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    private int _life = 50;

    public int Damage(int amount) {
        _life -= amount;

        UpdateLifeTotal();

        return _life;
    }

    private void UpdateLifeTotal() {
        this.GetComponent<Text>().text = "Enemy Life Total: " + _life.ToString();
    }

    public void Awake()
    {
        //initialize text
        UpdateLifeTotal();
    }
}

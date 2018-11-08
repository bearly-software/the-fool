using UnityEngine;
using System.Collections;

public abstract class CardEffect  {
    public abstract string GetText();

    public abstract void Play();

    public abstract bool ShouldPersist { get; }

    public abstract void Attack(); //leaky abstraction
}

public class BodyEffect : CardEffect
{
    private string _effectKey;

    private int _power;
    private int _toughness;

    private MajorArcanaCard _major;
    private MinorArcanaCard _minor;

    public BodyEffect(int power, int toughtness) {

        _power = power;
        _toughness = toughtness;

    }

    public override string GetText()
    {
        return _power + "/" + _toughness;
    }

    public override void Play()
    {
        //noop
    }

    public override void Attack() {
        GameObject.Find("Enemy").GetComponent<Enemy>().Damage(_power);
    }


    public override bool ShouldPersist
    {
        get
        {
            return true;
        }
    }

}

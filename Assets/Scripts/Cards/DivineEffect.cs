using UnityEngine;
using System.Collections;


public class DivineEffect : CardEffect
{
    private string _effectKey;

    private int _divinePower;

    private MajorArcanaCard _major;
    private MinorArcanaCard _minor;

    public DivineEffect(int divinePower) {

        _divinePower = divinePower;
    }

    public override string GetText()
    {
        return "Evoke " + _divinePower + " Divine Power";
    }

    public override void Play()
    {
        //get the divine power component
        GameObject.Find("DivinePower").GetComponent<DivinePower>().AddPower(_divinePower);
        return;
    }

    public override void Attack()
    {
        return;
    }

    public override bool ShouldPersist
    {
        get
        {
            return false;
        }
    }

}

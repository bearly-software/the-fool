using UnityEngine;
using System.Collections;


public class MindEffect : CardEffect
{
    private string _effectKey;

    private int _spellPower;

    private MajorArcanaCard _major;
    private MinorArcanaCard _minor;

    public MindEffect(int spellPower) {

        _spellPower = spellPower;
    }

    public override string GetText()
    {
        return "Deal " + _spellPower + " damage";
    }

    public override void Play()
    {
        GameObject.Find("Enemy").GetComponent<Enemy>().Damage(_spellPower);
        return;
    }

    public override void  Attack()
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

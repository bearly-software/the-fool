using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinorArcanaCard : MonoBehaviour
{

    protected string _suit;
    protected string _value;
    protected MinorArcanaEffectFactory _cardFactory = new MinorArcanaEffectFactory();
    CardEffect _currentEffect;
    bool cardInPlay = false;

    public void Awake()
    {
        _cardFactory = new MinorArcanaEffectFactory(); 
    }

    public void ChangeEffect()
    {
        if(!cardInPlay) {
            var newSelectedMajorArcana = GameObject.Find("PlayerMajorArcana").GetComponent<PlayerMajorArcana>().GetSelectedArcana;
            _currentEffect = _cardFactory.NewCardEffect(newSelectedMajorArcana, this.GetComponent<MinorArcanaCard>());
            _updateEffect();    
        }
    }

    public void Play(Transform playZone = null)
    {
        cardInPlay = true;

        _currentEffect.Play();

        Draggable d = this.GetComponent<Draggable>();
        //get targetZone;

        if (d != null)
        {
            if (_currentEffect.ShouldPersist)
            {
                d.parentToReturnTo = GameObject.Find("PlayerCreatures").transform;
            }
            else
            {
                var graveyardGameObject = GameObject.Find("Graveyard");
                graveyardGameObject.GetComponent<Graveyard>().Add(this);
                d.parentToReturnTo = graveyardGameObject.transform;
            }
        }
    }

    public void Attack() {
        _currentEffect.Attack();
    }

    public void SetCard(string suit, string value, Transform parentTransform)
    {
        _suit = suit;
        _value = value;
        MajorArcanaCard m = GameObject.Find("PlayerMajorArcana").GetComponent<PlayerMajorArcana>().GetSelectedArcana;
        //need to set the effect of the card for each of the divine

        this.transform.Find("CardTitle").gameObject.GetComponent<Text>().text = _value + " " + _suit;
        //get the current 
        _currentEffect = _cardFactory.NewCardEffect(m, this);
        _updateEffect();

        this.transform.SetParent(parentTransform, false);
    }

    private void _updateEffect() {
        
        this.transform.Find("Effect").gameObject.GetComponent<Text>().text = _currentEffect.GetText();
    }

    public void MoveCard(Transform newParent) {
        this.transform.SetParent(newParent, false);
    }

    public string CardKey { get { return _suit + ":" + _value; } }

    internal static readonly string[] Suits = { 
        "Swords",
        "Wands",
        "Coins",
        "Cups"
    };

    internal static readonly string[] Values = {
        "Ace",
        "Two",
        "Three",
        "Four",
        "Five",
        "Six",
        "Seven",
        "Eight",
        "Nine",
        "Ten",
        "Page",
        "Knight",
        "Queen",
        "King"
    };

}

public class MinorArcanaEffectFactory {
    
    //private IDictionary<string, CardEffect> _cardDictionary = new Dictionary<string, CardEffect>();

    public CardEffect NewCardEffect(MajorArcanaCard majorCard, MinorArcanaCard minorCard) {
        //look for key
        var key = _buildKey(majorCard, minorCard);
        Debug.Log(key);
        CardEffect effect;

        if(_cardDictionary.ContainsKey(key)) {
            _cardDictionary.TryGetValue(key, out effect);
            return effect;
        } else {
            // add to dictionary, body and wheel of fortune
            //based on suit and value
            string[] aspectMajor = majorCard.AspectCardName.Split(':');
            if(aspectMajor[0] == "Divine") {
                effect = new DivineEffect(0);
            } else if( aspectMajor[0] == "Mind") {
                effect = new MindEffect(0);
            } else if (aspectMajor[0] == "Body") {
                effect = new BodyEffect(0, 0);    
            } else {
                effect = new BodyEffect(-1, -1);
            }

            _cardDictionary.Add(key, effect);
            return effect;
        }

    }

    private string _buildKey(MajorArcanaCard major, MinorArcanaCard minorArcanaCard) {
        //get the selected major arcana and aspect
        return major.AspectCardName + ":" + minorArcanaCard.CardKey;
    }

    //a divine the fool deck
    //a mind lovers deck
    //a wheel body deck
    Dictionary<string, CardEffect> _cardDictionary = new Dictionary<string, CardEffect>()
    {
        {"Body:Wheel of Fortune:Swords:Ace", new BodyEffect(1,1)},
        {"Body:Wheel of Fortune:Swords:Two", new BodyEffect(2,2)},
        {"Body:Wheel of Fortune:Swords:Three", new BodyEffect(3,3)},
        {"Body:Wheel of Fortune:Swords:Four", new BodyEffect(4,4)},
        {"Body:Wheel of Fortune:Swords:Five", new BodyEffect(5,5)},
        {"Body:Wheel of Fortune:Swords:Six", new BodyEffect(6,6)},
        {"Body:Wheel of Fortune:Swords:Seven", new BodyEffect(7,7)},
        {"Body:Wheel of Fortune:Swords:Eight", new BodyEffect(8,8)},
        {"Body:Wheel of Fortune:Swords:Nine", new BodyEffect(9,9)},
        {"Body:Wheel of Fortune:Swords:Ten", new BodyEffect(10,10)},
        {"Body:Wheel of Fortune:Swords:Page", new BodyEffect(11,11)},
        {"Body:Wheel of Fortune:Swords:Knight", new BodyEffect(12,12)},
        {"Body:Wheel of Fortune:Swords:Queen", new BodyEffect(13,13)},
        {"Body:Wheel of Fortune:Swords:King", new BodyEffect(14,14)},

        {"Body:Wheel of Fortune:Cups:Ace", new BodyEffect(1,1)},
        {"Body:Wheel of Fortune:Cups:Two", new BodyEffect(2,2)},
        {"Body:Wheel of Fortune:Cups:Three", new BodyEffect(3,3)},
        {"Body:Wheel of Fortune:Cups:Four", new BodyEffect(4,4)},
        {"Body:Wheel of Fortune:Cups:Five", new BodyEffect(5,5)},
        {"Body:Wheel of Fortune:Cups:Six", new BodyEffect(6,6)},
        {"Body:Wheel of Fortune:Cups:Seven", new BodyEffect(7,7)},
        {"Body:Wheel of Fortune:Cups:Eight", new BodyEffect(8,8)},
        {"Body:Wheel of Fortune:Cups:Nine", new BodyEffect(9,9)},
        {"Body:Wheel of Fortune:Cups:Ten", new BodyEffect(10,10)},
        {"Body:Wheel of Fortune:Cups:Page", new BodyEffect(11,11)},
        {"Body:Wheel of Fortune:Cups:Knight", new BodyEffect(12,12)},
        {"Body:Wheel of Fortune:Cups:Queen", new BodyEffect(13,13)},
        {"Body:Wheel of Fortune:Cups:King", new BodyEffect(14,14)},

        {"Body:Wheel of Fortune:Wands:Ace", new BodyEffect(1,1)},
        {"Body:Wheel of Fortune:Wands:Two", new BodyEffect(2,2)},
        {"Body:Wheel of Fortune:Wands:Three", new BodyEffect(3,3)},
        {"Body:Wheel of Fortune:Wands:Four", new BodyEffect(4,4)},
        {"Body:Wheel of Fortune:Wands:Five", new BodyEffect(5,5)},
        {"Body:Wheel of Fortune:Wands:Six", new BodyEffect(6,6)},
        {"Body:Wheel of Fortune:Wands:Seven", new BodyEffect(7,7)},
        {"Body:Wheel of Fortune:Wands:Eight", new BodyEffect(8,8)},
        {"Body:Wheel of Fortune:Wands:Nine", new BodyEffect(9,9)},
        {"Body:Wheel of Fortune:Wands:Ten", new BodyEffect(10,10)},
        {"Body:Wheel of Fortune:Wands:Page", new BodyEffect(11,11)},
        {"Body:Wheel of Fortune:Wands:Knight", new BodyEffect(12,12)},
        {"Body:Wheel of Fortune:Wands:Queen", new BodyEffect(13,13)},
        {"Body:Wheel of Fortune:Wands:King", new BodyEffect(14,14)},

        {"Body:Wheel of Fortune:Coins:Ace", new BodyEffect(1,1)},
        {"Body:Wheel of Fortune:Coins:Two", new BodyEffect(2,2)},
        {"Body:Wheel of Fortune:Coins:Three", new BodyEffect(3,3)},
        {"Body:Wheel of Fortune:Coins:Four", new BodyEffect(4,4)},
        {"Body:Wheel of Fortune:Coins:Five", new BodyEffect(5,5)},
        {"Body:Wheel of Fortune:Coins:Six", new BodyEffect(6,6)},
        {"Body:Wheel of Fortune:Coins:Seven", new BodyEffect(7,7)},
        {"Body:Wheel of Fortune:Coins:Eight", new BodyEffect(8,8)},
        {"Body:Wheel of Fortune:Coins:Nine", new BodyEffect(9,9)},
        {"Body:Wheel of Fortune:Coins:Ten", new BodyEffect(10,10)},
        {"Body:Wheel of Fortune:Coins:Page", new BodyEffect(11,11)},
        {"Body:Wheel of Fortune:Coins:Knight", new BodyEffect(12,12)},
        {"Body:Wheel of Fortune:Coins:Queen", new BodyEffect(13,13)},
        {"Body:Wheel of Fortune:Coins:King", new BodyEffect(14,14)},

        {"Mind:Lovers:Swords:Ace", new MindEffect(1)},
        {"Mind:Lovers:Swords:Two", new MindEffect(2)},
        {"Mind:Lovers:Swords:Three", new MindEffect(3)},
        {"Mind:Lovers:Swords:Four", new MindEffect(4)},
        {"Mind:Lovers:Swords:Five", new MindEffect(5)},
        {"Mind:Lovers:Swords:Six", new MindEffect(6)},
        {"Mind:Lovers:Swords:Seven", new MindEffect(7)},
        {"Mind:Lovers:Swords:Eight", new MindEffect(8)},
        {"Mind:Lovers:Swords:Nine", new MindEffect(9)},
        {"Mind:Lovers:Swords:Ten", new MindEffect(10)},
        {"Mind:Lovers:Swords:Page", new MindEffect(11)},
        {"Mind:Lovers:Swords:Knight", new MindEffect(12)},
        {"Mind:Lovers:Swords:Queen", new MindEffect(13)},
        {"Mind:Lovers:Swords:King", new MindEffect(14)},

        {"Mind:Lovers:Wands:Ace", new MindEffect(1)},
        {"Mind:Lovers:Wands:Two", new MindEffect(2)},
        {"Mind:Lovers:Wands:Three", new MindEffect(3)},
        {"Mind:Lovers:Wands:Four", new MindEffect(4)},
        {"Mind:Lovers:Wands:Five", new MindEffect(5)},
        {"Mind:Lovers:Wands:Six", new MindEffect(6)},
        {"Mind:Lovers:Wands:Seven", new MindEffect(7)},
        {"Mind:Lovers:Wands:Eight", new MindEffect(8)},
        {"Mind:Lovers:Wands:Nine", new MindEffect(9)},
        {"Mind:Lovers:Wands:Ten", new MindEffect(10)},
        {"Mind:Lovers:Wands:Page", new MindEffect(11)},
        {"Mind:Lovers:Wands:Knight", new MindEffect(12)},
        {"Mind:Lovers:Wands:Queen", new MindEffect(13)},
        {"Mind:Lovers:Wands:King", new MindEffect(14)},

        {"Mind:Lovers:Cups:Ace", new MindEffect(1)},
        {"Mind:Lovers:Cups:Two", new MindEffect(2)},
        {"Mind:Lovers:Cups:Three", new MindEffect(3)},
        {"Mind:Lovers:Cups:Four", new MindEffect(4)},
        {"Mind:Lovers:Cups:Five", new MindEffect(5)},
        {"Mind:Lovers:Cups:Six", new MindEffect(6)},
        {"Mind:Lovers:Cups:Seven", new MindEffect(7)},
        {"Mind:Lovers:Cups:Eight", new MindEffect(8)},
        {"Mind:Lovers:Cups:Nine", new MindEffect(9)},
        {"Mind:Lovers:Cups:Ten", new MindEffect(10)},
        {"Mind:Lovers:Cups:Page", new MindEffect(11)},
        {"Mind:Lovers:Cups:Knight", new MindEffect(12)},
        {"Mind:Lovers:Cups:Queen", new MindEffect(13)},
        {"Mind:Lovers:Cups:King", new MindEffect(14)},

        {"Mind:Lovers:Coins:Ace", new MindEffect(1)},
        {"Mind:Lovers:Coins:Two", new MindEffect(2)},
        {"Mind:Lovers:Coins:Three", new MindEffect(3)},
        {"Mind:Lovers:Coins:Four", new MindEffect(4)},
        {"Mind:Lovers:Coins:Five", new MindEffect(5)},
        {"Mind:Lovers:Coins:Six", new MindEffect(6)},
        {"Mind:Lovers:Coins:Seven", new MindEffect(7)},
        {"Mind:Lovers:Coins:Eight", new MindEffect(8)},
        {"Mind:Lovers:Coins:Nine", new MindEffect(9)},
        {"Mind:Lovers:Coins:Ten", new MindEffect(10)},
        {"Mind:Lovers:Coins:Page", new MindEffect(11)},
        {"Mind:Lovers:Coins:Knight", new MindEffect(12)},
        {"Mind:Lovers:Coins:Queen", new MindEffect(13)},
        {"Mind:Lovers:Coins:King", new MindEffect(14)},


        {"Divine:The Fool:Swords:Ace", new DivineEffect(1)},
        {"Divine:The Fool:Swords:Two", new DivineEffect(2)},
        {"Divine:The Fool:Swords:Three", new DivineEffect(3)},
        {"Divine:The Fool:Swords:Four", new DivineEffect(4)},
        {"Divine:The Fool:Swords:Five", new DivineEffect(5)},
        {"Divine:The Fool:Swords:Six", new DivineEffect(6)},
        {"Divine:The Fool:Swords:Seven", new DivineEffect(7)},
        {"Divine:The Fool:Swords:Eight", new DivineEffect(8)},
        {"Divine:The Fool:Swords:Nine", new DivineEffect(9)},
        {"Divine:The Fool:Swords:Ten", new DivineEffect(10)},
        {"Divine:The Fool:Swords:Page", new DivineEffect(11)},
        {"Divine:The Fool:Swords:Knight", new DivineEffect(12)},
        {"Divine:The Fool:Swords:Queen", new DivineEffect(13)},
        {"Divine:The Fool:Swords:King", new DivineEffect(14)},

        {"Divine:The Fool:Wands:Ace", new DivineEffect(1)},
        {"Divine:The Fool:Wands:Two", new DivineEffect(2)},
        {"Divine:The Fool:Wands:Three", new DivineEffect(3)},
        {"Divine:The Fool:Wands:Four", new DivineEffect(4)},
        {"Divine:The Fool:Wands:Five", new DivineEffect(5)},
        {"Divine:The Fool:Wands:Six", new DivineEffect(6)},
        {"Divine:The Fool:Wands:Seven", new DivineEffect(7)},
        {"Divine:The Fool:Wands:Eight", new DivineEffect(8)},
        {"Divine:The Fool:Wands:Nine", new DivineEffect(9)},
        {"Divine:The Fool:Wands:Ten", new DivineEffect(10)},
        {"Divine:The Fool:Wands:Page", new DivineEffect(11)},
        {"Divine:The Fool:Wands:Knight", new DivineEffect(12)},
        {"Divine:The Fool:Wands:Queen", new DivineEffect(13)},
        {"Divine:The Fool:Wands:King", new DivineEffect(14)},

        {"Divine:The Fool:Cups:Ace", new DivineEffect(1)},
        {"Divine:The Fool:Cups:Two", new DivineEffect(2)},
        {"Divine:The Fool:Cups:Three", new DivineEffect(3)},
        {"Divine:The Fool:Cups:Four", new DivineEffect(4)},
        {"Divine:The Fool:Cups:Five", new DivineEffect(5)},
        {"Divine:The Fool:Cups:Six", new DivineEffect(6)},
        {"Divine:The Fool:Cups:Seven", new DivineEffect(7)},
        {"Divine:The Fool:Cups:Eight", new DivineEffect(8)},
        {"Divine:The Fool:Cups:Nine", new DivineEffect(9)},
        {"Divine:The Fool:Cups:Ten", new DivineEffect(10)},
        {"Divine:The Fool:Cups:Page", new DivineEffect(11)},
        {"Divine:The Fool:Cups:Knight", new DivineEffect(12)},
        {"Divine:The Fool:Cups:Queen", new DivineEffect(13)},
        {"Divine:The Fool:Cups:King", new DivineEffect(14)},

        {"Divine:The Fool:Coins:Ace", new DivineEffect(1)},
        {"Divine:The Fool:Coins:Two", new DivineEffect(2)},
        {"Divine:The Fool:Coins:Three", new DivineEffect(3)},
        {"Divine:The Fool:Coins:Four", new DivineEffect(4)},
        {"Divine:The Fool:Coins:Five", new DivineEffect(5)},
        {"Divine:The Fool:Coins:Six", new DivineEffect(6)},
        {"Divine:The Fool:Coins:Seven", new DivineEffect(7)},
        {"Divine:The Fool:Coins:Eight", new DivineEffect(8)},
        {"Divine:The Fool:Coins:Nine", new DivineEffect(9)},
        {"Divine:The Fool:Coins:Ten", new DivineEffect(10)},
        {"Divine:The Fool:Coins:Page", new DivineEffect(11)},
        {"Divine:The Fool:Coins:Knight", new DivineEffect(12)},
        {"Divine:The Fool:Coins:Queen", new DivineEffect(13)},
        {"Divine:The Fool:Coins:King", new DivineEffect(14)}
    };


}
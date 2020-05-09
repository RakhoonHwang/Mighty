﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteManager : SingletonMonobehaviour<SpriteManager>
{   
    Dictionary<string, Sprite> playingCard;

    void Awake()
    {
        Sprite[] allcard = Resources.LoadAll<Sprite>("allcard");
        
        this.playingCard = new Dictionary<string, Sprite>();
        for (int i=0; i<allcard.Length; i++)
        {
            this.playingCard.Add(allcard[i].name, allcard[i]);
        }
    }

    public Sprite get_card_sprite(SHAPE? shape, int number)
    {
        string name = shape.ToString() + number.ToString();

        if (!this.playingCard.ContainsKey(name))
            return null;
        else
            return this.playingCard[name];
    }

    public Sprite get_card_sprite(string name)
    {
        if (!this.playingCard.ContainsKey(name))
            return null;
        else
            return this.playingCard[name];
    }
}
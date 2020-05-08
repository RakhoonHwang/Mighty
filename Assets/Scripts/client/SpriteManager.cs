﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteManager : SingletonMonobehaviour<SpriteManager>
{   
    Sprite[] playingCard;

    void Awake()
    {
        this.playingCard = Resources.LoadAll<Sprite>("allcard");
    }

    public Sprite get_card_sprite(int index)
    {
        return this.playingCard[index];
    }
}
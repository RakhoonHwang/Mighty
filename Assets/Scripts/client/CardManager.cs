﻿using System;
using System.Collections;
using System.Collections.Generic;

public class CardManager
{
    public List<Card> cards = new List<Card> ();
    
    public void make_all_cards()
    {
        foreach (SHAPE shape in Enum.GetValues(typeof(SHAPE)) )
        {
            for (int number=1; number<14; number++)
            {
                this.cards.Add(new Card(shape, number));
            }
        }
        this.cards.Add(new Card(null, 0));
    }

    public void shuffle()
    {
        Helper.Shuffle<Card>(this.cards);
    }
}

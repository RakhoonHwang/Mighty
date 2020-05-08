﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerHandCardManager 
{
    List<CardPicture> cards;

    public PlayerHandCardManager()
    {
        this.cards = new List<CardPicture>();
    }

    public void reset()
    {
        this.cards.Clear();
    }

    public void add(CardPicture card_picture)
    {
        this.cards.Add(card_picture);
    }

    public void remove(CardPicture card_picture)
    {
        bool result = this.cards.Remove(card_picture);
    }

    public int get_card_count()
    {
        return this.cards.Count;
    }

    public CardPicture get_card(int index)
    {
        return this.cards[index];
    }

    public CardPicture find_card(SHAPE? shape, int number)
    {
        return this.cards.Find(obj => obj.card.is_same(shape, number));
    }

    public int get_same_shape_count(SHAPE? shape)
    {
        List<CardPicture> same_cards = this.cards.FindAll(obj => obj.is_same(shape));
        return same_cards.Count;
    }

    public void sort_by_shape_and_number()
    {

    }

    public void enable_all_colliders(bool flag)
    {
        for (int i=0; i<this.cards.Count; i++)
        {
            this.cards[i].enable_collider(flag);
        }
    }
}

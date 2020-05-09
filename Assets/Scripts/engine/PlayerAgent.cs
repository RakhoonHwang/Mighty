﻿using System;
using System.Collections;
using System.Collections.Generic;

public enum ROLE : int
{
    YADANG,
    JUGONG,
    FRIEND
}

public class PlayerAgent 
{
    int player_index;
    public int score;

    List<Card> score_card;
    List<Card> hand_card;
    ROLE role;

    public PlayerAgent(int player_index)
    {
        this.player_index = player_index;
        this.score_card = new List<Card>();
        this.hand_card = new List<Card>();
        this.score = 0;
        this.role = ROLE.YADANG;
    }

    // 매판 초기화할 변수들.
    public void reset()
    {
        this.score_card.Clear();
        this.hand_card.Clear();
        this.role = ROLE.YADANG;
    }

    public void add_card_to_hand(List<Card> cards)
    {
		this.hand_card = cards;
    }
}

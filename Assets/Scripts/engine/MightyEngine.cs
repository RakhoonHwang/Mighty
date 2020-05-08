using System;
using System.Collections;
using System.Collections.Generic;


public class MightyEngine 
{   
    // 전체 카드
    CardManager card_manager;
    List<Card> card_list;

    // 플레이어들.
    List<PlayerAgent> player_agents;

	public List<Card> cards_from_players;

    public int first_player_index;
    public int current_player_index;
    public int scoring_player_index;
    public SHAPE? kiruda;
    public int winning_condition;
    
    public List<List<Card>> distributed_players_cards;

    public MightyEngine()
    {
        this.card_manager = new CardManager();
        this.card_list = new List<Card>();
        this.player_agents = new List<PlayerAgent>();
        this.cards_from_players = new List<Card>();
        this.first_player_index = 0;
        this.current_player_index = 0;
        this.scoring_player_index = 0;
        this.kiruda = null;
        this.winning_condition = 0;
        this.distributed_players_cards = new List<List<Card>>();
    }

    // 매판 초기화할 데이터.
    public void reset()
    {
        this.player_agents.ForEach(obj => obj.reset());
        this.first_player_index = 0; //전판 프렌드로 수정
        this.current_player_index = this.first_player_index;
        this.kiruda = null;
        this.winning_condition = 0;
        this.card_manager.make_all_cards();
        this.card_list.Clear();
        this.distributed_players_cards.Clear();
        clear_turn_data();
    }

    // 매턴 초기화할 데이터. 
    public void clear_turn_data()
    {
        this.cards_from_players.Clear();
        this.scoring_player_index = 0;
    }

    // 게임 시작
    // 추후 수정
    public void start()
    {
        this.player_agents.Clear();
        for (int i=0; i<5; i++)
        {
            this.player_agents.Add(new PlayerAgent(i));
            this.player_agents[i].reset();
            this.distributed_players_cards.Add(new List<Card>());
        }

        shuffle();
        dstribute_cards();

        /*
        for (int i=0; i<5; i++)
        {
            this.player_agents[i].sort_player_hand_slots();
        }
        */
    }

    void shuffle()
    {
        this.card_manager.shuffle();
        this.card_list = this.card_manager.cards;
    }

    // 추후 수정
    void dstribute_cards()
    {
        int player_index = this.first_player_index;
        List<Card> cards = new List<Card>();

        for (int count=0; count<5; count++)
        {
            if (count == 0)
                cards = this.card_list.GetRange(0, 13);
            else
                cards = this.card_list.GetRange(13+count*10, 10);
            
            this.distributed_players_cards[player_index] = cards;
            this.player_agents[player_index].add_card_to_hand(cards);    

            player_index = find_next_player_index_of(player_index);
        }
    }

    int MAX_PLAYER_COUNT = 5;
    public int get_next_player_index()
    {
        if (this.current_player_index < MAX_PLAYER_COUNT-1)
            return (int)(this.current_player_index + 1);
        else
            return 0;
    }

    public void move_to_next_player()
    {
        this.current_player_index = get_next_player_index();
    }

    int find_next_player_index_of(int prev_player_index)
    {
        if (prev_player_index < MAX_PLAYER_COUNT-1)
            return (int)(prev_player_index + 1);
        else
            return 0;
    }
}

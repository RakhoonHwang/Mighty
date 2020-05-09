using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections;
using System.Collections.Generic;

public class PlayRoomUI : SingletonMonobehaviour<PlayRoomUI> 
{
    // List<PlayerHandCardManager> player_hand_card_manager;

    Sprite back_image;

    // test용
    SpriteRenderer sprite_renderer;
    MightyEngine engine;
    List<CardPicture> card_pictures;  

    [SerializeField]  
    Transform test_position_root;
    List<Vector3> test_position;

    void Awake()
    {
        // this.player_hand_card_manager = new List<PlayerHandCardManager>();
        // this.player_hand_card_manager.Add(new PlayerHandCardManager());

        this.back_image = SpriteManager.Instance.get_card_sprite("back");

        this.sprite_renderer = GetComponent<SpriteRenderer>();
        this.engine = new MightyEngine();

        this.card_pictures = new List<CardPicture>();
        for (int i=0; i<13; i++)
        {
            GameObject original = Resources.Load("cardframe") as GameObject;
            GameObject obj = GameObject.Instantiate(original);
            obj.transform.parent = transform;
            CardPicture card_pic = obj.AddComponent<CardPicture>();
            this.card_pictures.Add(card_pic);
        }
        
        this.test_position = new List<Vector3>();
        make_slot_positions(test_position_root, this.test_position);
    }

    void OnGUI()
    {
        if (GUI.Button (new Rect(10,10,100,28), "test"))
        {
            this.engine.reset();
            this.engine.start();
            distribute_cards(this.engine.distributed_players_cards[0]);
        }
    }

    void reset()
    {
        // this.player_hand_card_manager[0].reset();
    }

    void make_slot_positions(Transform root, List<Vector3> targets)
    {
        Transform[] slots = root.GetComponentsInChildren<Transform>();
        for (int i=0; i<slots.Length; i++)
        {
            if (slots[i] == root)
                continue;
            
            targets.Add(slots[i].position);
        }
    }

    Sprite get_card_sprite(Card card)
    {
        if (card.number == 0)
            return SpriteManager.Instance.get_card_sprite("joker");
        else
            return SpriteManager.Instance.get_card_sprite(card.shape, card.number);
    }

    void distribute_cards(List<Card> cards)
    {
        reset();

        for (int i=0; i<13; i++)
        {
            this.card_pictures[i].update_card(cards[i], get_card_sprite(cards[i]));
            this.card_pictures[i].enable_collider(false);
            // this.card_pictures[i].set_slot_index(i);
            this.card_pictures[i].transform.localPosition = this.test_position[i];
            this.card_pictures[i].transform.localScale = Vector3.one;
            // this.player_hand_card_manager[0].add(card_picture);
        }
    }
}
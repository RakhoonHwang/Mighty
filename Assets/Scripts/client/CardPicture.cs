﻿using UnityEngine;
using System.Collections;

public class CardPicture : MonoBehaviour
{
    public Card card;
    public SpriteRenderer sprite_renderer;

    public int slot;
    BoxCollider box_collider;

    void Awake()
    {
        this.sprite_renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        this.box_collider = gameObject.GetComponent<BoxCollider>();
    }

    public void set_slot_index(int slot)
    {
        this.slot = slot;
    }

    public void update_card(Card card, Sprite image)
    {
        this.card = card;
        this.sprite_renderer.sprite = image;
    }

    public void update_backcard(Sprite back_image)
    {
        this.card = null;
        update_image(back_image);
    }

    public void update_image(Sprite image)
    {
        this.sprite_renderer.sprite = image;
    }

	public bool is_same(SHAPE? shape)
	{
		return this.card.shape == shape;
	}

	public bool is_same(SHAPE? shape, int number)
	{
		return this.card.is_same(shape, number);
	}

    public void enable_collider(bool flag)
    {
        this.box_collider.enabled = flag;
    }

    public bool is_back_card()
    {
        return this.card == null;
    }
}

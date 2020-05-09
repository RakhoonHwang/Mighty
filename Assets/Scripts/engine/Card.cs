using System.Collections;
using System.Collections.Generic;

public enum SHAPE : int
{
	S,
	D,
	H,
	C
}

public class Card
{
    public SHAPE? shape;
    public int number;

    public Card(SHAPE? shape, int number)
    {
        this.shape = shape;
        this.number = number;
    } 

    public static bool is_joker(int number)
    {
        return number == 0;
    }

    public bool is_same(SHAPE? shape, int number)
	{
		return this.shape == shape && this.number == number;
	}

    public bool is_same_shape(SHAPE? shape)
	{
		return this.shape == shape;
	}
}

namespace Solitfire.Logic;

public class Card
{
    public Suits Suit { get; }
    public Ranks Rank { get; }
    public bool IsFaceUp { get; set; }

    public Card(Suits suit, Ranks rank, bool isFaceUp)
    {
        Suit = suit;
        Rank = rank;
        IsFaceUp = isFaceUp;
    }
}
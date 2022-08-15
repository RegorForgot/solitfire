namespace Solitfire.Logic;

public class Card
{
    public Suits Suit { get; }
    public Ranks Rank { get; }
    public bool IsFaceUp { get; set; }
    public bool IsTopMost { get; set; }

    public Card(Suits suit, Ranks rank, bool isFaceUp, bool isTopMost)
    {
        Suit = suit;
        Rank = rank;
        IsFaceUp = isFaceUp;
        IsTopMost = isTopMost;
    }
}
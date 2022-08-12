namespace Solitaire.Logic;

public class Card
{
    public Suits Suit { get; }
    public Ranks Rank { get; }
    public bool Visible { get; set; }

    public Card(Suits suit, Ranks rank, bool visible)
    {
        Suit = suit;
        Rank = rank;
        Visible = visible;
    }
}
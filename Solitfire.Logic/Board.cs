namespace Solitfire.Logic;

public class Board
{
    public CardCollection<Card>[] Tableau { get; }
    public CardCollection<Card>[] Foundation { get; }
    public CardCollection<Card> Waste { get; }

    private readonly Card[] _cards = new Card[52];

    public Board()
    {
        Tableau = new CardCollection<Card>[7];
        Foundation = new CardCollection<Card>[4];
        Waste = new CardCollection<Card>();
        #region Instantiate Card lists

        for (int i = 0; i < Foundation.Length; i++)
        {
            Foundation[i] = new CardCollection<Card>();
        }

        for (int i = 0; i < Tableau.Length; i++)
        {
            Tableau[i] = new CardCollection<Card>();
        }

        #endregion

        CreateCards();
        PopulateBoard();
    }

    private void CreateCards()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                _cards[j + 13 * i] = new Card((Suits)i, (Ranks)j, false, false);
            }
        }
        Random random = new Random();
        random.Shuffle(_cards);
    }
    
    private void PopulateBoard()
    {
        int count = 0;

        for (int i = 0; i < 7; i++)
        {
            Tableau[i].AddRange(_cards[count..(count + i + 1)]);
            Tableau[i][i].IsFaceUp = true;
            Tableau[i][i].IsTopMost = true;
            count += i + 1;
        }

        Waste.AddRange(_cards[count..52]);
    }
}
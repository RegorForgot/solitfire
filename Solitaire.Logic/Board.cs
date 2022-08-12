namespace Solitaire.Logic;

public class Board
{
    public ObservableCollectionExtensions<Card>[] Tableau { get; }
    public ObservableCollectionExtensions<Card>[] Foundation { get; }
    public ObservableCollectionExtensions<Card> Waste { get; }

    private readonly Card[] _cards = new Card[52];

    public Board()
    {
        Tableau = new ObservableCollectionExtensions<Card>[7];
        Foundation = new ObservableCollectionExtensions<Card>[4];
        Waste = new ObservableCollectionExtensions<Card>();
        #region Instantiate Card lists

        for (int i = 0; i < Foundation.Length; i++)
        {
            Foundation[i] = new ObservableCollectionExtensions<Card>();
        }

        for (int i = 0; i < Tableau.Length; i++)
        {
            Tableau[i] = new ObservableCollectionExtensions<Card>();
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
                _cards[j + 13 * i] = new Card((Suits)i, (Ranks)j, false);
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
            Tableau[i][i].Visible = true;
            count += i + 1;
        }

        Waste.AddRange(_cards[count..52]);
    }
}
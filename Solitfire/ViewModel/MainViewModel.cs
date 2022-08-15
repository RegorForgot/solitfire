using Solitfire.Logic;

namespace Solitfire.ViewModel;

public class MainViewModel : BaseViewModel
{
    public CardCollection<Card>[] Tableau { get; }
    public CardCollection<Card>[] Foundation { get; }
    public CardCollection<Card> Waste { get; }

    public MainViewModel(Board board)
    {
        Tableau = board.Tableau;
        Foundation = board.Foundation;
        Waste = board.Waste;
    }
}
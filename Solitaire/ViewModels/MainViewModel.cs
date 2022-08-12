using Solitaire.Logic;

namespace Solitaire.ViewModels;

public class MainViewModel : BaseViewModel
{
    public ObservableCollectionExtensions<Card>[] Tableau { get; }
    public ObservableCollectionExtensions<Card>[] Foundation { get; }
    public ObservableCollectionExtensions<Card> Waste { get; }

    public MainViewModel(Board board)
    {
        Tableau = board.Tableau;
        Foundation = board.Foundation;
        Waste = board.Waste;
    }
}
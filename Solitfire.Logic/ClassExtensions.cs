using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Solitfire.Logic;

public static class RandomExtensions
{
    public static void Shuffle<T> (this Random rng, T[] array)
    {
        int n = array.Length;
        while (n > 1) 
        {
            int k = rng.Next(n--);
            (array[n], array[k]) = (array[k], array[n]);
        }
    }
}

public class CardCollection<T> : ObservableCollection<T>
{
    public void AddRange(IEnumerable<T> items)
    {
        CheckReentrancy();

        foreach (T t in items)
        {
            Items.Add(t);
        }
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        OnPropertyChanged(new PropertyChangedEventArgs("Count"));
        OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
    }
}
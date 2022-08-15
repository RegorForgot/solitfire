using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Solitfire.Logic;
using Solitfire.Tools;
using static Solitfire.Tools.VisualTreeHelperExtensions;

namespace Solitfire.View;

public class CardControl : Control
{
    public readonly static DependencyProperty CardProperty = DependencyProperty.Register(
        nameof(Card),
        typeof(Card),
        typeof(CardControl),
        new PropertyMetadata(default(Card)));

    public Card Card
    {
        get => (Card)GetValue(CardProperty);
        set => SetValue(CardProperty, value);
    }

    static CardControl()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(CardControl), new FrameworkPropertyMetadata(typeof(CardControl)));
    }

    public CardControl()
    {
        AllowDrop = true;
        MouseLeftButtonDown += OnPreviewMouseLeftButtonDown;
    }

    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
        if (Card.IsTopMost)
        {
            Margin = new Thickness(0, 0, 0, 0);
        } else if (!Card.IsFaceUp)
        {
            Margin = new Thickness(0, 0, 0, -9 * ActualHeight / 10);
        } else
        {
            Margin = new Thickness(0, 0, 0, -4 * ActualHeight / 5);
        }
    }

    private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        CardControl cardControl = (CardControl)sender;
        ListView? stackListView = FindAncestor<ListView>(cardControl);

        ItemCollection? items = stackListView?.Items;

        if (!cardControl.Card.IsFaceUp)
        {
            return;
        }

        bool descendingOrder = true;

        int? index = stackListView?.ItemContainerGenerator.IndexFromItem(cardControl.Card);

        if (items != null && index != null)
        {
            for (int i = (int)index + 1; i < items.Count; i++)
            {
                Card? firstCard = stackListView?.ItemContainerGenerator.ItemFromIndex<Card>(i - 1);
                Card? secondCard = stackListView?.ItemContainerGenerator.ItemFromIndex<Card>(i);

                if (firstCard == null || secondCard == null || firstCard.Rank == 1 + secondCard.Rank &&
                    (int)firstCard.Suit % 2 != (int)secondCard.Rank % 2)
                {
                    continue;
                }
                descendingOrder = false;
                break;
            }
        }

        if (!descendingOrder)
        {
            return;
        }

        List<Card>? cards = stackListView?.ItemContainerGenerator.ItemsFromIndex<Card>(0, items.Count - 1);
        MessageBox.Show("true!");
    }
}
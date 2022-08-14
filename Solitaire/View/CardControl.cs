using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Solitaire.Logic;
using static System.Math;
using static System.Windows.SystemParameters;

namespace Solitaire.View;

public class CardControl : Control
{
    #region Dependency Properties

    public readonly static DependencyProperty SuitProperty = DependencyProperty.Register(
        nameof(Suit),
        typeof(Suits),
        typeof(CardControl),
        new PropertyMetadata(default(Suits)));

    public Suits Suit
    {
        get => (Suits)GetValue(SuitProperty);
        set => SetValue(SuitProperty, value);
    }

    public readonly static DependencyProperty RankProperty = DependencyProperty.Register(
        nameof(Rank),
        typeof(Ranks),
        typeof(CardControl),
        new PropertyMetadata(default(Ranks)));

    public Ranks Rank
    {
        get => (Ranks)GetValue(RankProperty);
        set => SetValue(RankProperty, value);
    }

    public readonly static DependencyProperty IsFaceUpProperty = DependencyProperty.Register(
        nameof(IsFaceUp),
        typeof(bool),
        typeof(CardControl),
        new PropertyMetadata(default(bool))); 

    public bool IsFaceUp
    {
        get => (bool)GetValue(IsFaceUpProperty);
        set => SetValue(IsFaceUpProperty, value);
    }

    #endregion

    private Point StartPosition { get; set; }
    public new event MouseEventHandler MouseMove
    { 
        add => base.MouseMove += value;
        remove => base.MouseMove -= value;
    }

    static CardControl()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(CardControl), new FrameworkPropertyMetadata(typeof(CardControl)));
    }

    public CardControl()
    {
        AllowDrop = true;
        MouseMove += OnMouseMove;
    }

    protected override void OnMouseUp(MouseButtonEventArgs e)
    {
        IsFaceUp = !IsFaceUp;
    }

    protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        StartPosition = e.GetPosition(null);
    }

    private void OnMouseMove(object sender, MouseEventArgs e)
    {
        Point currentPosition = e.GetPosition(null);
        Vector change = StartPosition - currentPosition;

        if (e.LeftButton != MouseButtonState.Pressed ||
            !(Abs(change.X) > MinimumHorizontalDragDistance) && !(Abs(change.Y) > MinimumVerticalDragDistance) || 
            sender is not CardControl cardControl)
        {
            return;
        }
        
        DataObject dataObject = new DataObject(cardControl);
        DragDrop.DoDragDrop(cardControl, dataObject, DragDropEffects.Move);
    }
}
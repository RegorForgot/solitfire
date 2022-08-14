using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using static System.String;

namespace Solitfire.Tools;

public class CardImageConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            bool isFaceUp = (bool)values[2];

            if (isFaceUp)
            {
                string uri = Format("pack://application:,,,/Resources/CardAssets/{0}_{1}.png", values);
                return new BitmapImage(new Uri(uri));
            } else
            {
                string uri = "pack://application:,,,/Resources/CardAssets/back.png";
                return new BitmapImage(new Uri(uri));
            }
        } catch
        {
            return DependencyProperty.UnsetValue;
        }
    }
    
    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        return new[]
        {
            DependencyProperty.UnsetValue
        };
    }
}
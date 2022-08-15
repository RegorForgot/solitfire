using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Solitfire.Tools;

public static class VisualTreeHelperExtensions 
{
    public static T? FindAncestor<T>(DependencyObject? current) where T : DependencyObject
    {
        current = VisualTreeHelper.GetParent(current);
        do
        {
            if (current is T dependencyObject)
            {
                return dependencyObject;
            }
            current = VisualTreeHelper.GetParent(current);
        } while (current != null);
        return null;
    }
}

public static class ItemContainerGeneratorExtensions
{
    public static T? ItemFromIndex<T>(this ItemContainerGenerator generator, int index) where T : class
    {
        return generator.ItemFromContainer(generator.ContainerFromIndex(index)) as T;
    }

    public static int? IndexFromItem(this ItemContainerGenerator generator, object item)
    {
        return generator.IndexFromContainer(generator.ContainerFromItem(item));
    }

    /// <summary>
    /// Returns a list of Items of Type T from start to end index inclusive
    /// </summary>
    /// <param name="generator">this parameter, user does not input</param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <typeparam name="T">class of items to look for</typeparam>
    /// <returns></returns>
    public static List<T?> ItemsFromIndex<T>(this ItemContainerGenerator generator, int start, int end) where T : class
    {
        List<T?> items = new List<T?>();

        for (int i = start; i < end + 1; i++)
        {
            items.Add(generator.ItemFromIndex<T>(i));
        }

        return items;
    }
}
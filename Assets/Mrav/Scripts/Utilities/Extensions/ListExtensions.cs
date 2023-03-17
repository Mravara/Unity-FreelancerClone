using UnityEngine;
using System.Collections.Generic;

public static class ListExtension
{
    public static T NextItem<T>(this List<T> array, T item)
    {
        if (array.Count > 0)
            return array[(array.IndexOf(item) + 1) == array.Count ? 0 : (array.IndexOf(item) + 1)];
        else
            return default(T);
    }

    public static T PreviousItem<T>(this List<T> array, T item)
    {
        if (array.Count > 0)
            return array[(array.IndexOf(item) - 1) < 0 ? array.Count - 1 : (array.IndexOf(item) - 1)];
        else
            return default(T);
    }

    public static T FirstItem<T>(this List<T> array)
    {
        if (array.Count > 0)
            return array[0];
        else
            return default(T);
    }

    public static T LastItem<T>(this List<T> array)
    {
        if (array.Count > 0)
            return array[array.Count - 1];
        else
            return default(T);
    }

    public static T Pop<T>(this List<T> array, int index)
    {
        T item = array[index];
        array.RemoveAt(index);
        return item;
    }

    public static T Pop<T>(this BetterList<T> array, int index)
    {
        T item = array[index];
        array.RemoveAt(index);
        return item;
    }

    public static void MoveItemToEnd<T>(this List<T> array, int index)
    {
        T item = array[index];
        for (int i = index + 1; i < array.Count; i++)
        {
            array[i - 1] = array[i];
        }
        array[array.Count - 1] = item;
    }
}

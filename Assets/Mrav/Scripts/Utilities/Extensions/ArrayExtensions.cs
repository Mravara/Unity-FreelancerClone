using UnityEngine;
using System;
using System.Linq;

public static class ArrayExtension
{
    public static T NextItem<T>(this T[] array, T item)
    {
        if (array.Length == 0)
            return default(T);

        if (item == null)
            return array[0];

        return array[(Array.IndexOf(array, item) + 1) == array.Length ? 0 : (Array.IndexOf(array, item) + 1)];
    }

    public static T PreviousItem<T>(this T[] array, T item)
    {
        if (array.Length == 0)
            return default(T);

        return array[(Array.IndexOf(array, item) - 1) < 0 ? array.Length - 1 : (Array.IndexOf(array, item) - 1)];
    }

    public static T FirstItem<T>(this T[] array)
    {
        if (array.Length > 0)
            return array[0];
        else
            return default(T);
    }

    public static T LastItem<T>(this T[] array)
    {
        if (array.Length > 0)
            return array[array.Length - 1];
        else
            return default(T);
    }

    public static void ActivateGameObjects(this GameObject[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i].SetActive(true);
        }
    }

    public static void DeactivateGameObjects(this GameObject[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i].SetActive(false);
        }
    }

    public static void Shuffle<T>(this T[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            var item = UnityEngine.Random.Range(0, i);
            T tmp = array[i];
            array[i] = array[item];
            array[item] = tmp;
        }
    }

    public static int GetIndex<T>(this T[] array, T item)
    {
        return Array.IndexOf(array, item);
    }

    public static bool Contains<T>(this T[] array, T item)
    {
        for (int i = 0; i < array.Length; i++)
        {
            T obj = array[i];

            if (obj != null && obj.Equals(item))
                return true;
        }

        return false;
    }

    public static void MoveItemToEnd<T>(this T[] array, int index)
    {
        T item = array[index];
        for (int i = index + 1; i < array.Length; i++)
        {
            array[i - 1] = array[i];
        }
        array[array.Length - 1] = item;
    }
}

using UnityEngine;
using System.Collections;

public static class FloatExtension
{
    public static float IncreaseByPercentage(this float f, float percentage)
    {
        return f + (f * percentage);
    }

    public static float SubstractByPercentage(this float f, float percentage)
    {
        return f - (f * percentage);
    }

    public static float ChangeByPercentage(this float f, float percentage)
    {
        return f * percentage;
    }

    public static int IncreaseByPercentage(this int i, float percentage)
    {
        return Mathf.RoundToInt(i + (i * percentage));
    }

    public static int SubstractByPercentage(this int i, float percentage)
    {
        return Mathf.RoundToInt(i - (i * percentage));
    }

    public static int ChangeByPercentage(this int i, float percentage)
    {
        return Mathf.RoundToInt(i * percentage);
    }

    public static bool IsBetween(this float i, float min, float max)
    {
        return (i <= max && i >= min);
    }
}

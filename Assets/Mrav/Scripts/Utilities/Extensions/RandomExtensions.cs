using SRandom = System.Random;
using URandom = UnityEngine.Random;

public static class RandomExtensions
{
    public static bool Bool
    {
        get
        {
            return URandom.value <= .5f;
        }
    }
}
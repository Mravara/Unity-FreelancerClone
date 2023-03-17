using UnityEngine;

public static class ColorExtension
{
    public static Color whiteTransparent
    {
        get 
        {
            return new Color(1f, 1f, 1f, 0f);
        }
    }

    public static string ToHexColor(this Color c)
    {
        string hexColor = string.Format("#{0}{1}{2}",
        ((int)(c.r * 255)).ToString("X2"),
        ((int)(c.g * 255)).ToString("X2"),
        ((int)(c.b * 255)).ToString("X2"));
        return hexColor;
    }

    public static Color NewAlpha(this Color c, float a)
    {
        return new Color(c.r, c.g, c.b, a);
    }

    public static Color Hue(Color c, float h)
    {
       return new HSBColor(c, h).ToColor();
    }
}
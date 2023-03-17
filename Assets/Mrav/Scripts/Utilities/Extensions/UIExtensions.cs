using UnityEngine;

public static class UIExtensions
{
    /// <summary>
    /// Set interactible and block raycasts property.
    /// </summary>
    /// <param name="value">Enable/Disable</param>
    public static void SetAlive(this CanvasGroup canvasGroup, bool value)
    {
        canvasGroup.interactable = canvasGroup.blocksRaycasts = value;
    }

    /// <summary>
    /// Set image alpha property.
    /// </summary>
    /// <param name="a">Alpha value</param>
    public static void SetAlpha(this UnityEngine.UI.Image image, float newAlpha)
    {
        image.color = image.color.NewAlpha(newAlpha);
    }
}

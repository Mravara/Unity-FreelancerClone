using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LayerMaskExtensions
{
    public static bool IsCorrectLayer(this LayerMask mask, Collider collider)
    {
        return mask.Contains(collider.gameObject.layer);
    }

    public static bool IsCorrectLayer(this LayerMask mask, Collision collider)
    {
        return mask.Contains(collider.gameObject.layer);
    }

    public static bool IsCorrectLayer(this LayerMask mask, GameObject go)
    {
        return mask.Contains(go.layer);
    }

    public static bool Contains(this LayerMask mask, int layer)
    {
        return (mask & (1 << layer)) > 0;
    }

    public static LayerMask InvertedMask(this LayerMask mask)
    {
        return ~(1 << mask);
    }
}

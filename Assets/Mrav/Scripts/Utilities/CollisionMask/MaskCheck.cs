using UnityEngine;
using System.Collections;

[System.Serializable]
public class MaskCheck
{
    public LayerMask Mask;

    public bool IsCorrectLayer(Collider collider)
    {
        return Mask.Contains(collider.gameObject.layer);
    }

    public bool IsCorrectLayer(Collision collision)
    {
        return Mask.Contains(collision.gameObject.layer);
    }

    public bool IsCorrectLayer(GameObject go)
    {
        return Mask.Contains(go.layer);
    }

	public LayerMask GetInvertedMask()
    {
        return ~(1 << Mask);
    }
}

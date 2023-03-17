using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    public bool XAxis = false;
    public bool YAxis = false;
    public bool ZAxis = false;

    private float RandomRotation
    {
        get
        {
            return UnityEngine.Random.Range(0f, 359f);
        }
    }

    public void Rotate()
    {
        Transform t = transform;
        t.eulerAngles = new Vector3(
            XAxis ? RandomRotation : t.eulerAngles.x,
            YAxis ? RandomRotation : t.eulerAngles.y,
            ZAxis ? RandomRotation : t.eulerAngles.z);
    }
}

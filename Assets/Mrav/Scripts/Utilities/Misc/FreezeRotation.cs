using UnityEngine;
using System.Collections;

public class FreezeRotation : MonoBehaviour
{
    private Transform _transform;
    private Quaternion _rotation;

    void Awake()
    {
        _transform = transform;
        _rotation = _transform.rotation;
    }

    void LateUpdate()
    {
        _transform.rotation = _rotation;
    }
}

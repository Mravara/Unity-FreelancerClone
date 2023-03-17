using UnityEngine;
using System.Collections;

public class FreezeLocalPosition : MonoBehaviour
{
    private Vector3 _offset;
    private Transform _parentTransform;
    private Transform _transform;

    void Awake()
    {
        _transform = transform;
        _parentTransform = transform.parent;
        _offset = _parentTransform.position - _transform.position;
    }

    void FixedUpdate()
    {
        _transform.position = _parentTransform.position - _offset;
    }
}

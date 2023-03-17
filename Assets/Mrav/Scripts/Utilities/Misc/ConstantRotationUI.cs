using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotationUI : MonoBehaviour
{
    public float RotationSpeed = 100f;
    public bool RandomRotationOnStart = false;

    private RectTransform _transform;

    void Awake()
    {
        _transform = GetComponent<RectTransform>();
        Vector3 rotation = Vector3.forward * UnityEngine.Random.Range(0f, 359f);
        if (RandomRotationOnStart)
            _transform.localEulerAngles = rotation;
    }

    void FixedUpdate()
    {
        Vector3 rotation = Vector3.forward * RotationSpeed * Time.deltaTime;
        _transform.Rotate(rotation);
    }
}


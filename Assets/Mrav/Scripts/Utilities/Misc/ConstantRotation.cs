using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    public float RotationSpeed = 100f;
    public Vector3 Axis;
    public bool RandomRotationOnStart = false;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        Vector3 rotation = Axis * UnityEngine.Random.Range(0f, 359f);
        if (RandomRotationOnStart)
            _transform.localEulerAngles = rotation;
    }

    private void FixedUpdate()
    {
        Vector3 rotation = Axis * RotationSpeed * Time.deltaTime;
        _transform.Rotate(rotation);
    }
}

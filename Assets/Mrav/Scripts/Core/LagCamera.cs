using UnityEngine;

/// <summary>
/// Adds a slight lag to camera rotation to make the third person camera a little more interesting.
/// Requires that it starts parented to something in order to follow it correctly.
/// </summary>
[RequireComponent(typeof(Camera))]
public class LagCamera : MonoBehaviour
{    
    [Tooltip("Speed at which the camera rotates. (Camera uses Slerp for rotation.)")]
    public float MoveSpeed = 100f;
    public float RotateSpeed = 90.0f;

    private Transform target;
    private Vector3 startOffset;

    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        target = _transform.parent;

        if (target == null)
            Debug.LogWarning(name + ": Lag Camera will not function correctly without a target.");
        if (transform.parent == null)
            Debug.LogWarning(name + ": Lag Camera will not function correctly without a parent to derive the initial offset from.");

        startOffset = _transform.localPosition;
        _transform.SetParent(null);
    }

    private void FixedUpdate()
    {
        UpdateCamera();
    }

    private void UpdateCamera()
    {
        if (target != null)
        {
            _transform.position = Vector3.Lerp(_transform.position, target.TransformPoint(startOffset), Time.fixedDeltaTime * MoveSpeed);
            _transform.rotation = Quaternion.Slerp(_transform.rotation, target.rotation, Time.fixedDeltaTime * RotateSpeed);
        }
    }
}

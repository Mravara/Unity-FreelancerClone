using UnityEngine;

public class FakeRigidbody : MonoBehaviour
{
    private Transform _transform;

    public bool IsKinematic = false;

    public Vector3 Velocity
    {
        get
        {
            return _velocity;
        }
    }

    private Vector3 _velocity = Vector3.zero;

    private void Awake()
    {
        _transform = transform;
    }

    public void FakeFixedUpdate()
    {
        if (IsKinematic)
            return;

        _velocity += (Vector3.down * 100f) * Time.fixedDeltaTime;

        _transform.position += _velocity * Time.fixedDeltaTime;
    }

    public void AddForce(Vector3 force)
    {
        _velocity += force;
    }

    public void SetVelocity(Vector3 velocity)
    {
        _velocity = velocity;
    }
}

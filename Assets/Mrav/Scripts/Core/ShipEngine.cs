using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipEngine : MonoBehaviour
{
    [Header("Throttle")]
    public float ThrottleSpeed = 50f;
    public float ThrottleMultiplier = 1f;

    [Header("Throttle")]
    public float ThrusterSpeed = 150f;
    public float ThrusterMultiplier = 1f;

    [Header("Cruise")]
    public float CruiseSpeed = 400f;
    public float CruiseMultiplier = 1f;

    [Header("Handling")]
    public float TurnSpeed = 5f;
    public float TurnMultiplier = 1f;
    public float CruiseTurnMultiplier = 0.5f;

    public EngineState CurrentState;

    public Rigidbody Rigidbody { get { return _rigidbody; } }

    private Vector3 _linearInput;
    private Vector3 _angularInput;
    private float _thrusterInput;

    // engine kill info
    private Vector3 _engineKillVelocity;
    private float _engineKillThrottle = 0f;

    private Rigidbody _rigidbody;

    private float _cruiseModifier = 0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (CurrentState != EngineState.Cruising)
            UpdateThruster();

        switch (CurrentState)
        {
            case EngineState.Cruising:
                UpdateCruise();
                break;
            case EngineState.Running:
                UpdateThrottle();
                break;
            case EngineState.Killed:
                UpdateEngineKill();
                break;
            default:
                UpdateThrottle();
                break;
        }
        
        UpdateAngularForce();
    }

    public void SetPhysicsInput(Vector3 linearInput, Vector3 angularInput, float thruster = 0f)
    {
        _linearInput = linearInput;
        _angularInput = angularInput;
        _thrusterInput = thruster;
    }

    private void UpdateThrottle()
    {
        _rigidbody.AddRelativeForce(_linearInput.normalized * GetRequiredAcceleration(ThrottleSpeed) * ThrottleMultiplier, ForceMode.Acceleration);
    }

    private void UpdateEngineKill()
    {
        if (_thrusterInput != 0f)
            return;

        float speed = Mathf.Clamp(0f, _engineKillVelocity.magnitude, ThrottleSpeed + ThrusterSpeed);
        
        _rigidbody.AddForce(_engineKillVelocity.normalized * GetRequiredAcceleration(speed) * _rigidbody.mass);

        if (_engineKillThrottle != _linearInput.z)
            StartEngine();
    }

    private void UpdateAngularForce()
    {
        float multiplier = CurrentState == EngineState.Cruising ? CruiseTurnMultiplier : TurnMultiplier;
        _rigidbody.AddRelativeTorque(_angularInput * GetRequiredAcceleration(TurnSpeed) * multiplier, ForceMode.Acceleration);
    }

    private void UpdateCruise()
    {
        _cruiseModifier = Mathf.MoveTowards(_cruiseModifier, 1f, Time.fixedDeltaTime * 0.5f);
        _linearInput.z = _cruiseModifier;
        _rigidbody.AddRelativeForce(_linearInput * GetRequiredAcceleration(CruiseSpeed) * CruiseMultiplier, ForceMode.Acceleration);
    }

    private void UpdateThruster()
    {
        if (_thrusterInput != 0f)
        {
            float speed = ThrusterSpeed;
            if (CurrentState == EngineState.Killed)
            {
                _engineKillVelocity = _rigidbody.velocity;
                speed += ThrottleSpeed;
            }

            Vector3 input = _linearInput;
            input.z = 1f;
            _rigidbody.AddRelativeForce(input.normalized * GetRequiredAcceleration(speed) * ThrusterMultiplier, ForceMode.Acceleration);
        }
    }

    public void StartEngine()
    {
        ChangeState(EngineState.Running);
    }

    public void StartCruise()
    {
        ChangeState(EngineState.Cruising);
    }

    public void KillEngine()
    {
        if (CurrentState == EngineState.Killed)
            ChangeState(EngineState.Running);
        else
        {
            _engineKillVelocity = _rigidbody.velocity;
            _engineKillThrottle = _linearInput.z;
            ChangeState(EngineState.Killed);
        }
    }

    private void ChangeState(EngineState state)
    {
        CurrentState = state;

        if (state == EngineState.Cruising)
            _cruiseModifier = 0f;
    }

    private float GetRequiredAcceleration(float speed)
    {
        return (GetRequiredVelocityChange(speed) / Time.fixedDeltaTime);
    }

    private float GetRequiredVelocityChange(float speed)
    {
        float m = Mathf.Clamp01(_rigidbody.drag * Time.fixedDeltaTime);
        return speed * m / (1f - m);
    }
}

public enum EngineState
{
    Running,
    Cruising,
    Killed
}
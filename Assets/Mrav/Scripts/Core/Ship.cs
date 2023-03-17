using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ShipEngine))]
[RequireComponent(typeof(ShipInput))]
public class Ship : MonoBehaviour
{   
    public Transform Transform
    {
        get
        {
            return _transform;
        }
    }

    public Vector3 AimPosition
    {
        get
        {
            return _aimPosition;
        }
    }
    
    public float Speed = 0f;

    public LayerMask AimMask;
    public ShipInput ShipInput;
    public ShipEngine ShipEngine;
    public Camera Camera;

    // Getters for external objects to reference things like input.
    public Vector3 Velocity { get { return ShipEngine.Rigidbody.velocity; } }

    [SerializeField]
    private AbstractWeapon[] _weapons;

    private Vector3 _linearInput = new Vector3();
    private Vector3 _angularInput = new Vector3();

    private Transform _transform;

    private Vector3 _aimPosition;

    private void Awake()
    {
        ShipInput = GetComponent<ShipInput>();
        ShipEngine = GetComponent<ShipEngine>();
        _transform = transform;

        for (int i = 0; i < _weapons.Length; i++)
        {
            _weapons[i].Setup(this);
        }
    }

    private void Update()
    {
        // Pass the input to the physics to move the ship.
        _linearInput.x = ShipInput.Strafe;
        _linearInput.y = 0f;
        _linearInput.z = ShipInput.Throttle;

        if (ShipInput.MouseControl)
        {
            _angularInput.x = ShipInput.Pitch;
            _angularInput.y = ShipInput.Yaw;
            _angularInput.z = ShipInput.Roll;
        }
        else
        {
            _angularInput.x = 0f;
            _angularInput.y = 0f;
            _angularInput.z = ShipInput.Roll;
        }

        if (ShipInput.Cruise)
            ShipEngine.StartCruise();
        
        ShipEngine.SetPhysicsInput(_linearInput, _angularInput, ShipInput.Thruster == 0f ? 0f : Mathf.Max(ShipInput.Thruster, ShipInput.Throttle));

        if (Input.GetKeyDown(KeyCode.Z))
            ShipEngine.KillEngine();

        Speed = Velocity.magnitude;
    }

    private void FixedUpdate()
    {
        UpdateAim();
        UpdateWeapons();
    }

    private void UpdateWeapons()
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            _weapons[i].CustomUpdate();
        }
    }

    private void UpdateAim()
    {
        RaycastHit hit;
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 500f, AimMask))
        {
            _aimPosition = hit.point;
        }
        else
        {
            _aimPosition = ray.GetPoint(500f);
        }
    }

    // editor utility
    public void CacheWeapons()
    {
        _weapons = GetComponentsInChildren<AbstractWeapon>();
    }
}



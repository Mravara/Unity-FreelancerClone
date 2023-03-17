using UnityEngine;

public class ShipInput : MonoBehaviour
{
    public bool MouseControl
    {
        get
        {
            return _spaceControl || _mouseControl;
        }
    }

    public bool Cruise
    {
        get
        {
            return Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W);
        }
    }

    [Range(-1f, 1f)]
    public float Pitch;
    [Range(-1f, 1f)]
    public float Yaw;
    [Range(-1f, 1f)]
    public float Roll;
    [Range(-1f, 1f)]
    public float Strafe;
    [Range(0f, 1f)]
    public float Throttle;
    [Range(-1f, 1f)]
    public float Thruster;

    public bool Shoot = false;

    private bool _spaceControl = false;
    private bool _mouseControl = false;

    private void Update()
    {
        UpdateInput();
        UpdateMouseWheelThrottle();
    }
        
    private void UpdateInput()
    {
        // auto mouse control
        if (Input.GetKeyDown(KeyCode.Space))
            _spaceControl = !_spaceControl;

        Strafe = Input.GetAxisRaw("Horizontal");

        Vector3 mousePos = Input.mousePosition;
             
        Pitch = (mousePos.y - (Screen.height * 0.5f)) / (Screen.height* 0.5f);
        Yaw = (mousePos.x - (Screen.width * 0.5f)) / (Screen.width * 0.5f);

        if (Input.GetKey(KeyCode.Q))
            Roll = 1f;
        else if (Input.GetKey(KeyCode.E))
            Roll = -1f;
        else
            Roll = 0f;

        if (Input.GetKey(KeyCode.W))
            Thruster = Mathf.Lerp(Thruster, 1f, Time.deltaTime * 5f);
        else
            Thruster = 0f;

        // Make sure the values don't exceed limits.
        Pitch = -Mathf.Clamp(Pitch, -1.0f, 1.0f);
        Yaw = Mathf.Clamp(Yaw, -1.0f, 1.0f);

        _mouseControl = Input.GetMouseButton(0);

        Shoot = Input.GetMouseButton(1);
    }

    private void UpdateMouseWheelThrottle()
    {
        Throttle += Input.GetAxis("Mouse ScrollWheel");
        Throttle = Mathf.Clamp(Throttle, 0.0f, 1.0f);
    }
}
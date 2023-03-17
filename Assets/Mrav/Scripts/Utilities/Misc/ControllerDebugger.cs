using UnityEngine;

public class ControllerDebugger : MonoBehaviour
{
    [SerializeField]
    private GameObject _debugger;

    private static bool _exists = false;

    private void Awake()
    {
        if (_exists)
        {
            Destroy(gameObject);
            return;
        }

        _exists = true;

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            _debugger.SetActive(!_debugger.activeSelf);
        }
    }
}

using UnityEngine;
using System.Collections;

/// <summary>
/// Doesn't destroy the object this script is on.
/// </summary>
public class DontDestroyOnLoad : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

using UnityEngine;
using System.Collections;

/// <summary>
/// Counts frames per second. Use FPSCounter.FPS.
/// </summary>
public class FPSCounter : MonoBehaviour
{
    public float UpdateInterval = 0.5F;

    private float _accumulatedFPS = 0; // FPS accumulated over the interval
    private int _framesDrawn = 0; // Frames drawn over the interval
    private float _timeLeftForInterval; // Left time for current interval

    private float _fps;
    public float FPS
    {
        get { return _fps; }
    }

    void Start()
    {
        _timeLeftForInterval = UpdateInterval;
    }

    void Update()
    {
        _timeLeftForInterval -= Time.deltaTime;
        _accumulatedFPS += Time.timeScale / Time.deltaTime;
        ++_framesDrawn;

        // Interval ended - update GUI text and start new interval
        if (_timeLeftForInterval <= 0.0)
        {
            _fps = _accumulatedFPS / _framesDrawn;
            _timeLeftForInterval = UpdateInterval;
            _accumulatedFPS = 0.0F;
            _framesDrawn = 0;
        }
    }
}
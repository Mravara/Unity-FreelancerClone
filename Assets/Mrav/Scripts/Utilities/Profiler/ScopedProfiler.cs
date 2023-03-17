using UnityEngine.Profiling;
using System;

public struct ScopedProfiler : IDisposable
{
    public ScopedProfiler(string name)
    {
        Profiler.BeginSample(name);
    }

    public ScopedProfiler(string name, UnityEngine.Object targetObject)
    {
        Profiler.BeginSample(name, targetObject);
    }

    public void Dispose()
    {
        Profiler.EndSample();
    }
}
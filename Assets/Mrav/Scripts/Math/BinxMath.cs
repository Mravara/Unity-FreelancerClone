using UnityEngine;
using System.Collections.Generic;

public static class BinxMath
{
    /// <summary>
    /// 0.5.PercentOf(100) = 50
    /// </summary>
    public static float PercentOf(this float num, float target)
    {
        return num*target;
    }

	/// <summary>
	/// 50.IsWhatPercentageOf(100) = 0.5
	/// </summary>
	public static float IsWhatPercentageOf(this int num, int target)
	{
		return (float)num/target;
	}

    /// <summary>
    /// 50.IsWhatPercentageOf(100) = 0.5
    /// </summary>
    public static float IsWhatPercentageOf(this float num, float target)
    {
        return num/target;
    }

	/// <summary>
	/// 50.IsWhatPercentageOf(100) = 0.5
	/// </summary>
	public static double IsWhatPercentageOf(this double num, double target)
	{
		return num/target;
	}

    public static Vector2 MidPoint(this Vector2 pos, Vector2 target)
    {
        return target + (pos - target)/2f;
    }

	public static Vector3 MidPoint(this Vector3 pos, Vector3 target)
    {
        return target + (pos - target)/2f;
    }

	public static float Remap (this float value, float from1, float to1, float from2, float to2)
	{
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}

	public static float RemapInverted (this float value, float from1, float to1, float from2, float to2)
	{
		float res = (value - from1) / (to1 - from1) * (to2 - from2) + from2;
		float delta = res - from2;
		return to2 - delta;
	}

	public static float GetHeightInUnits(this Camera camera)
	{
		return 2f * camera.orthographicSize;
	}

	public static float GetWidthInUnits(this Camera camera)
	{
		return GetHeightInUnits (camera) * camera.aspect;
	}

    public static float FindMedian(float min, float max)
    {
        return (min + max) / 2f;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        angle = Mathf.Repeat(angle, 360f);
        min = Mathf.Repeat(min, 360f);
        max = Mathf.Repeat(max, 360f);

        bool inverse = false;
        float tmin = min;
        float tangle = angle;

        if (min > 180f)
        {
            inverse = !inverse;
            tmin -= 180f;
        }

        if (angle > 180f)
        {
            inverse = !inverse;
            tangle -= 180f;
        }

        bool result = !inverse ? tangle > tmin : tangle < tmin;
        if (!result)
            angle = min;

        inverse = false;
        tangle = angle;

        float tmax = max;
        if (angle > 180f)
        {
            inverse = !inverse;
            tangle -= 180f;
        }
        if (max > 180f)
        {
            inverse = !inverse;
            tmax -= 180f;
        }

        result = !inverse ? tangle < tmax : tangle > tmax;

        if (!result)
            angle = max;

        return angle;
    }

    public static Vector3 GetLaunchVelocity(Vector3 start, Vector3 target, float gravity, float peak, out float time)
    {
        float yDisplacement = target.y - start.y;
        Vector3 xzDisplacement = new Vector3(target.x - start.x, 0f, target.z - start.z);
        time = Mathf.Sqrt(Mathf.Abs(2 * peak / gravity)) + Mathf.Sqrt(Mathf.Abs(2 * (yDisplacement - peak) / gravity));
        Vector3 yVelocity = Vector3.up * Mathf.Sqrt(Mathf.Abs(2 * gravity * peak));
        Vector3 xzVelocity = xzDisplacement / time;
        return xzVelocity + yVelocity * -Mathf.Sign(gravity);
    }
}
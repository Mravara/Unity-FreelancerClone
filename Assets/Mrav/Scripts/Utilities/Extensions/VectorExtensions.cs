using UnityEngine;
using Random = UnityEngine.Random;

public static class VectorExtensions
{
    public static float Average(this Vector2 v)
    {
        return (v.x + v.y) * 0.5f;
    }

    public static float RandomValue(this Vector2 v)
    {
        return Random.Range(v.x, v.y);
    }

    public static Vector2 RandomValue(this Vector4 v)
    {
        return new Vector2(Random.Range(v.x, v.y), Random.Range(v.z, v.w));
    }

    public static float ToAngleInDegrees(this Vector2 v)
    {
        return Mathf.Rad2Deg * Mathf.Atan2(v.y, v.x);
    }

    public static Vector3 Multiply(this Vector3 a, Vector3 b)
    {
        return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }

    public static Vector3 ScaleByVector(this Vector3 a, Vector3 b)
    {
        return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }

    public static Vector2 DirectionTo(this Vector2 a, Vector2 b)
    {
        Vector2 heading = b - a;
        return heading / heading.magnitude;
    }

    public static Vector3 DirectionTo(this Vector3 a, Vector3 b)
    {
        Vector3 heading = b - a;
        return heading / heading.magnitude;
    }

    public static Vector2 DirectionFrom(this Vector2 a, Vector2 b)
    {
        Vector2 heading = (b - a) * -1f;
        return heading / heading.magnitude;
    }

    public static Vector3 DirectionFrom(this Vector3 a, Vector3 b)
    {
        Vector3 heading = (b - a) * -1f;
        return heading / heading.magnitude;
    }

    public static Vector2 xz(this Vector3 v)
    {
        return new Vector2(v.x, v.z);
    }

    public static Vector2 Rotate(this Vector2 v, float angle)
    {
        if (angle == 0f)
        {
            return v;
        }
        float f = angle * Mathf.Deg2Rad;
        float cos = Mathf.Cos(f);
        float sin = Mathf.Sin(f);
        return new Vector2(v.x * cos - v.y * sin, v.x * sin + v.y * cos);
    }

    /// <summary>
    /// Compute the cross product AB x AC
    /// </summary>
    /// <param name="pointA"></param>
    /// <param name="pointB"></param>
    /// <param name="pointC"></param>
    /// <returns></returns>
    public static float CrossProduct(Vector2 pointA, Vector2 pointB, Vector2 pointC)
    {
        Vector2 AB = pointB - pointA;
        Vector2 AC = pointC - pointA;
        float cross = AB.x * AC.y - AB.y * AC.x;
        return cross;
    }

    /// <summary>
    /// Compute the dot product AB . AC
    /// </summary>
    /// <param name="pointA"></param>
    /// <param name="pointB"></param>
    /// <param name="pointC"></param>
    /// <returns></returns>
    public static float DotProduct(Vector2 pointA, Vector2 pointB, Vector2 pointC)
    {
        Vector2 AB = pointB - pointA;
        Vector2 BC = pointC - pointB;
        float dot = AB.x * BC.x + AB.y * BC.y;
        return dot;
    }

    /// <summary>
    /// Compute the distance from AB to C
    /// if isSegment is true, AB is a segment, not a line.
    /// </summary>
    /// <param name="pointA"></param>
    /// <param name="pointB"></param>
    /// <param name="pointC"></param>
    /// <param name="isSegment"></param>
    /// <returns></returns>
    public static float LineToPointDistance2D(Vector2 pointA, Vector2 pointB, Vector2 pointC, bool isSegment)
    {
        float dist = VectorExtensions.CrossProduct(pointA, pointB, pointC) / (pointA - pointB).magnitude;
        if (isSegment)
        {
            float dot1 = DotProduct(pointA, pointB, pointC);
            if (dot1 > 0)
                return (pointB - pointC).magnitude;

            float dot2 = DotProduct(pointB, pointA, pointC);
            if (dot2 > 0)
                return (pointA - pointC).magnitude;
        }
        return Mathf.Abs(dist);
    }

    public static Vector3 MoveTowardsZ(this Vector3 position, float targetZ, float deltaDistance)
    {
        return Vector3.MoveTowards(position, new Vector3(position.x, position.y, targetZ), deltaDistance);
    }

    public static Vector3 SetX(this Vector3 v, float x)
    {
        return new Vector3(x, v.y, v.z);
    }

    public static Vector3 SetY(this Vector3 v, float y)
    {
        return new Vector3(v.x, y, v.z);
    }

    public static Vector3 SetZ(this Vector3 v, float z)
    {
        return new Vector3(v.x, v.y, z);
    }

    public static float DistanceTo(this Vector3 a, Vector3 b)
    {
        return Vector3.Distance(a, b);
    }

    public static float DistanceToXZ(this Vector3 a, Vector3 b)
    {
        a.y = 0f;
        b.y = 0f;
        return Vector3.Distance(a, b);
    }
}
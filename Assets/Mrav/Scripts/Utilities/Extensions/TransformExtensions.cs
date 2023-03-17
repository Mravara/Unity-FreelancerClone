using UnityEngine;

public static class TransformExtensions
{
    public static void SetPositionX(this Transform t, float x)
    {
        Vector3 pos = t.position;
        pos.x = x;
        t.position = pos;
    }

    public static void SetPositionY(this Transform t, float y)
    {
        Vector3 pos = t.position;
        pos.y = y;
        t.position = pos;
    }

    public static void SetPositionZ(this Transform t, float z)
    {
        Vector3 pos = t.position;
        pos.z = z;
        t.position = pos;
    }

    public static void SetLocalPositionX(this Transform t, float x)
    {
        Vector3 pos = t.localPosition;
        pos.x = x;
        t.localPosition = pos;
    }

    public static void SetLocalPositionY(this Transform t, float y)
    {
        Vector3 pos = t.localPosition;
        pos.y = y;
        t.localPosition = pos;
    }

    public static void SetLocalPositionZ(this Transform t, float z)
    {
        Vector3 pos = t.localPosition;
        pos.z = z;
        t.localPosition = pos;
    }

    public static void LookAtX(this Transform t, Vector3 position)
    {
        t.LookAt(new Vector3(t.position.x, position.y, position.z));
    }

    public static void LookAtY(this Transform t, Vector3 position)
    {
        t.LookAt(new Vector3(position.x, t.position.y, position.z));
    }

    public static void LookAtZ(this Transform t, Vector3 position)
    {
        t.LookAt(new Vector3(position.x, position.y, t.position.z));
    }

    public static void LookAtSlerp(this Transform t, Vector3 lookAt, Vector3 upwards, float time)
    {
        t.rotation = Quaternion.Slerp(t.rotation, Quaternion.LookRotation(lookAt - t.position, upwards), time);
    }

    public static void LookAtTowards(this Transform t, Vector3 lookAt, Vector3 upwards, float delta)
    {
        t.rotation = Quaternion.RotateTowards(t.rotation, Quaternion.LookRotation(t.position.DirectionTo(lookAt), upwards), delta);
    }

    public static void LookAtLerp(this Transform t, Vector3 lookAt, Vector3 upwards, float delta)
    {
        t.rotation = Quaternion.Lerp(t.rotation, Quaternion.LookRotation(t.position.DirectionTo(lookAt), upwards), delta);
    }

    public static void RotateTowards(this Transform t, Vector3 eulerAngle, float delta)
    {
        t.eulerAngles = Vector3.MoveTowards(t.eulerAngles, eulerAngle, delta);
    }

    public static void MoveTowards(this Transform t, Vector3 moveTo, float maxDistanceDelta)
    {
        t.position = Vector3.MoveTowards(t.position, moveTo, maxDistanceDelta);
    }

    public static void MoveLocalTowards(this Transform t, Vector3 moveTo, float maxDistanceDelta)
    {
        t.localPosition = Vector3.MoveTowards(t.localPosition, moveTo, maxDistanceDelta);
    }

    public static void LookAtInverse(this Transform t, Transform target)
    {
        t.LookAt(2f * t.position - target.position);
    }
}

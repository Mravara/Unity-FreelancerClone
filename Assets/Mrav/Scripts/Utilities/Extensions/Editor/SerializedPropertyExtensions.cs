using UnityEngine;
using UnityEditor;
using System;

public static class SerializedPropertyExtensions
{
    public static void CopyPropertyFrom(this SerializedProperty thisProp, SerializedProperty newProp)
    {
        if (thisProp.propertyType == SerializedPropertyType.Boolean)
            thisProp.boolValue = newProp.boolValue;
        else if (thisProp.propertyType == SerializedPropertyType.Integer)
            thisProp.intValue = newProp.intValue;
        else if (thisProp.propertyType == SerializedPropertyType.Float)
            thisProp.floatValue = newProp.floatValue;
        else if (thisProp.propertyType == SerializedPropertyType.LayerMask)
            thisProp.intValue = newProp.intValue;
        else if (thisProp.propertyType == SerializedPropertyType.ObjectReference)
            thisProp.objectReferenceValue = newProp.objectReferenceValue;
        else if (thisProp.propertyType == SerializedPropertyType.String)
            thisProp.stringValue = newProp.stringValue;
        else if (thisProp.propertyType == SerializedPropertyType.Vector2)
            thisProp.vector2Value = newProp.vector2Value;
        else if (thisProp.propertyType == SerializedPropertyType.Vector3)
            thisProp.vector3Value = newProp.vector3Value;
        else if (thisProp.propertyType == SerializedPropertyType.Quaternion)
            thisProp.quaternionValue = newProp.quaternionValue;
        else if (thisProp.propertyType == SerializedPropertyType.Vector4)
            thisProp.vector4Value = newProp.vector4Value;
        else if (thisProp.propertyType == SerializedPropertyType.Enum)
            thisProp.enumValueIndex = newProp.enumValueIndex;
        else if (thisProp.propertyType == SerializedPropertyType.Color)
            thisProp.colorValue = newProp.colorValue;
        else if (thisProp.propertyType == SerializedPropertyType.AnimationCurve)
            thisProp.animationCurveValue = newProp.animationCurveValue;
        else if (thisProp.propertyType == SerializedPropertyType.Rect)
            thisProp.rectValue = newProp.rectValue;
        else
            Debug.LogError("Failed to copy " + newProp.name);

    }
}

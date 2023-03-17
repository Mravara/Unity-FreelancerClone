using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class AbstractBullet : MonoBehaviour
{
    public Rigidbody Rigidbody;
}

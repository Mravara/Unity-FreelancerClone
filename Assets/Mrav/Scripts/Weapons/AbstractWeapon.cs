using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeapon : MonoBehaviour
{
    public float FireRate = 0.3f;

    private Transform _transform;

    private Vector3 _startingRotation;

    private Ship _ship;

    private float _nextFire = 0f;

    public AbstractBullet Bullet;

    protected virtual void Awake()
    {
        _transform = transform;

        _startingRotation = _transform.localEulerAngles;
    }

    public virtual void Setup(Ship ship)
    {
        _ship = ship;
    }

    public void CustomUpdate()
    {
        UpdateRotation();

        if (_ship.ShipInput.Shoot && Time.time > _nextFire)
        {
            Fire();
        }
    }

    private void Fire()
    {
        _nextFire = Time.time + FireRate;

        GameObject projectile = GameObject.Instantiate(Bullet.gameObject, _transform.position, Quaternion.identity) as GameObject;
        AbstractBullet bullet = projectile.GetComponent<AbstractBullet>();

        Vector3 force = _ship.Velocity + _transform.forward * 300f;

        bullet.Rigidbody.AddForce(force, ForceMode.VelocityChange);

        Destroy(bullet.gameObject, 10f);
    }

    private void UpdateRotation()
    {
        _transform.LookAtTowards(_ship.AimPosition, _ship.Transform.up, 300f * Time.fixedDeltaTime);
        Vector3 newRotation = _transform.localEulerAngles;

        newRotation.x = BinxMath.ClampAngle(newRotation.x, _startingRotation.x - 60f, _startingRotation.x + 60f);
        newRotation.y = BinxMath.ClampAngle(newRotation.y, _startingRotation.y - 60f, _startingRotation.y + 60f);
        //newRotation.z = _startingRotation.z;

        _transform.localEulerAngles = newRotation;
    }
}
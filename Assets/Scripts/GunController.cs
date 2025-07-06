using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private BulletPoolController bulletPool;
    [SerializeField] private float velocity;
    [SerializeField] private float firingRate;
    private float nextFiringTime;

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = new Vector2(Input.GetAxisRaw("HorizontalFire"), Input.GetAxisRaw("VerticalFire"));
        if (dir != Vector2.zero && Time.time >= nextFiringTime)
        {
            Shoot(dir);
            nextFiringTime = Time.time + (1f / firingRate);
        }
    }

    void Shoot(Vector2 direction)
    {
        BulletController bullet = bulletPool.GetBullet(transform.position, Quaternion.identity).GetComponent<BulletController>();
        bullet.SetVelocity(direction, velocity);
    }
}

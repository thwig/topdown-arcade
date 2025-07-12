using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private BulletPoolController bulletPool;
    [SerializeField] private float velocity;
    [SerializeField] private float firingRate;
    [SerializeField] private float delayBeforeFiring;
    [SerializeField] private float damage;
    private float nextFiringTime = 0f;
    private bool buffering = false;

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = new Vector2(Input.GetAxisRaw("HorizontalFire"), Input.GetAxisRaw("VerticalFire")).normalized;
        if (dir != Vector2.zero && Time.time >= nextFiringTime && !buffering)
        {
            StartCoroutine(ShootWithDelay());
        }
    }

    IEnumerator ShootWithDelay()
    {
        buffering = true;
        yield return new WaitForSeconds(delayBeforeFiring);
        Vector2 finalDir = new Vector2(Input.GetAxisRaw("HorizontalFire"), Input.GetAxisRaw("VerticalFire")).normalized;
        if (finalDir != Vector2.zero && Time.time >= nextFiringTime)
        {
            BulletController bullet = bulletPool.GetBullet(transform.position, BulletRotation()).GetComponent<BulletController>();
            bullet.SetVelocity(finalDir, velocity);
            bullet.SetDamage(damage);
            nextFiringTime = Time.time + (1f / firingRate);
        }
        buffering = false;
    }

    Quaternion BulletRotation()
    {
        return Quaternion.identity;
    }
}

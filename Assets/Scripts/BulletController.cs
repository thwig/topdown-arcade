using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IProjectile
{
    private Vector3 direction = Vector2.zero;
    private float speed = 0f;
    private float damage = 0f;

    public void SetVelocity(Vector2 direction, float speed)
    {
        this.direction = direction.normalized;
        this.speed = speed;
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
    public float GetDamage()
    {
        return damage;
    }

    void Update()
    {
        transform.position += Time.deltaTime * direction * speed;
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == gameObject.layer)
        {
            gameObject.SetActive(false);
        }
    }
}

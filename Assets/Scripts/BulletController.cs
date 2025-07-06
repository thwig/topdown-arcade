using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Vector3 direction = Vector2.zero;
    private float speed = 0f;

    public void SetVelocity(Vector2 direction, float speed)
    {
        this.direction = direction.normalized;
        this.speed = speed;
    }

    void Update()
    {
        transform.position += Time.deltaTime * direction * speed;
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}

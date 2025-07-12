using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float health;
    void Update()
    {
        targetPlayer();
    }

    void targetPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            OnHit(other.gameObject);
        }
    }

    void OnHit(GameObject projectile)
    {
        
        Die();
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}

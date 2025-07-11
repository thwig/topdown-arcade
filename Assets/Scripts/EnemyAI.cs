using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPlayer();
    }

    void targetPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
    }
}

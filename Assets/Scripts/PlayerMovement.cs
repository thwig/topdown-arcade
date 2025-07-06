using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float velocity;
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() {

        Vector3 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        transform.position += Time.deltaTime * velocity * dir;
    }
}


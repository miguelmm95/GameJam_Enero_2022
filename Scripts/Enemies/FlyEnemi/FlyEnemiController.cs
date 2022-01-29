using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemiController : MonoBehaviour
{
    public Transform player;

    private Rigidbody2D rb;

    private Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;

        direction.Normalize();
        movement = direction;
    }

    void moveEnemi
}

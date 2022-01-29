using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float CurrHealth;

    public int health;

    void Start()
    {
        CurrHealth = health;
    }

    void Update()
    {
        if(CurrHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void getDamage(int damage)
    {
        CurrHealth -= damage;
    }
}

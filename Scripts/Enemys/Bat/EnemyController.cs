using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public SpawnController sc;
    public AudioSource deadSound;

    private Rigidbody2D rb;
    private float CurrHealth;

    public int health;
    public bool imDead;

    void Start()
    {
        CurrHealth = health;
    }

    void Update()
    {
        if(CurrHealth <= 0)
        {
            //sc.spawnEnemy = true;
            deadSound.Play();
            Destroy(gameObject);
        }
    }

    public void getDamage(int damage)
    {
        CurrHealth -= damage;
    }
}

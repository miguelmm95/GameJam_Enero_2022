using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public int damage;
    public float lifeTime;

    public Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0){
            Destroy(gameObject);
        }
    }

    void FixedUpdate(){
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}

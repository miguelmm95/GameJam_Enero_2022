using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 40f;
    public int damage = 5;
    public float lifeTime;

    public Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        lifeTime -= Time.deltaTime;

        transform.position += transform.right * Time.deltaTime * speed;

        if(lifeTime <= 0){
            Destroy(gameObject);
        }
    }

    void FixedUpdate(){
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            Destroy(gameObject);
            Debug.Log("IM HERE");
        }
    }
}

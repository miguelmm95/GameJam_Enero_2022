using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 40f;
    public int damage = 5;
    public float lifeTime;

    private Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed * Time.deltaTime, 0);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("HOLA MUNDO");
            collision.gameObject.GetComponent<EnemyController>().getDamage(damage);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveImput;
    private bool isGrounded;
    private bool facingRight = true;
    private int extraJumps;
    private float jumpTimeCounter;
    private bool isJumping;
    public float speed;
    public float jumpForce;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask isJumpable;
    public int actualNumberOfJumps;
    public float jumpTime;



    void Start(){
        extraJumps = actualNumberOfJumps;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, isJumpable);

        moveImput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveImput * speed, rb.velocity.y);

        if(!facingRight && moveImput > 0){
            Flip();
        }else if(facingRight && moveImput < 0){
            Flip();
        }
    }

    void Update(){

        if(isGrounded){
            extraJumps = actualNumberOfJumps;
        }

        if(Input.GetKeyDown(KeyCode.W) && extraJumps >= 0){
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded){
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKey(KeyCode.W) && isJumping){
            if(jumpTimeCounter > 0){
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }else{
                isJumping = false;
            }
            
        }

        if(Input.GetKeyUp(KeyCode.W)){
            isJumping = false;
        }
    }

    void Flip(){
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}

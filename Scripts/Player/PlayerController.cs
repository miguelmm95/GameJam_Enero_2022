using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public WeaponController weapon;
    public Animator animator;

    private Rigidbody2D rb;
    private float moveImput;
    private bool isGrounded;
    private int extraJumps;
    private float jumpTimeCounter;
    private bool isJumping;
    private bool isDashing;

    public float speed;
    public float jumpForce;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask isJumpable;
    public int actualNumberOfJumps;
    public float jumpTime;
    public float dashDistance = 10f;



    void Start(){
        extraJumps = actualNumberOfJumps;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, isJumpable);

        moveImput = Input.GetAxisRaw("Horizontal");
        if(!isDashing)
            rb.velocity = new Vector2(moveImput * speed, rb.velocity.y);

        
        Vector3 aim = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(aim.x < transform.position.x){
            transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);      //Turn Left
        }else{
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);        //Turn Right
        }

        if(aim.x < transform.position.x && Input.GetKeyDown(KeyCode.Mouse1)){         //Dash Left
            StartCoroutine(Dash(-1f));
        }else if(aim.x > transform.position.x && Input.GetKeyDown(KeyCode.Mouse1)){   //Dash Right
            StartCoroutine(Dash(1f));
        }
    }

    void Update(){

        if(isGrounded){
            extraJumps = actualNumberOfJumps;
        }

        if(Input.GetMouseButtonDown(0)){
            weapon.isShooting = true;
        }

        if(Input.GetMouseButtonUp(0)){
            weapon.isShooting = false;
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

    IEnumerator Dash (float direction)
    {
        isDashing = true;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = rb.gravityScale;
        rb.gravityScale = 0;
        yield return new WaitForSeconds(0.3f);
        isDashing = false;
        rb.gravityScale = gravity;
    }
}
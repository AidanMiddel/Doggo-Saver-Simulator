using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //movement left and right

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    //fliping

    private bool facingRight = true;


    //jumping variable

    private bool isGrounded;
    public Transform groundcheck;
    public float checkRadious;
    public LayerMask whatIsGround;

    //double jump

    private int extraJumps;
    public int extraJumpsValue;

    //functions

    void Start(){
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){

        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadious, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        Debug.Log(moveInput);

        if (facingRight == false && moveInput > 0) {
            Flip();
        } else if(facingRight == true && moveInput < 0) {
            Flip();
        }
    }

    void Update(){
        if (isGrounded == true){
            extraJumps = extraJumpsValue;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0){
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true){
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip(){
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}

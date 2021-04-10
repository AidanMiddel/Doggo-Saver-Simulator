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

    //Trigger variables
    public bool isJumping;

    //double jump
    private int extraJumps;
    public int extraJumpsValue;


    //animation

    private Animator anim;

    //functions
    void Start(){
        extraJumps = extraJumpsValue;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //Trigger Var
        isGrounded = isJumping;


    }

    void FixedUpdate(){
        //A & D > LeftArrow & RightArrow
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadious, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0) {
            Flip();
        } else if(facingRight == true && moveInput < 0) {
            Flip();
        }

        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        } else
        {
            anim.SetBool("isRunning", true);
        }
    }

    void Update(){
         
        //Extra Jumps
        if (isGrounded == true){
            extraJumps = extraJumpsValue;
        }

        if(Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip(){

        //Sprite flipper
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


    // Collectables
    private void OnTriggerEnter(Collider hit)
    {
        switch (hit.gameObject.tag)
        {
            case "WinCircle":
                LevelManager.Instance.Win();
                break;
        }
    }

}

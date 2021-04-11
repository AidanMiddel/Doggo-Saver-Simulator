using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //movement left and right

    public float speed;
    public float jumpForce;
    private float moveInput;
    GameObject other;

    private Rigidbody2D rb;

    //jumping variable

    private bool isGrounded;
    public Transform groundcheck;
    public float checkRadious;
    public LayerMask whatIsGround;

    //Trigger variables

    public bool isJumping;
    LevelManager LVLManager;

    //double jump

    private int extraJumps;
    public int extraJumpsValue;


    //animation

    private Animator anim;

    //functions

    private void Awake()
    {
        LVLManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void Start(){
        extraJumps = extraJumpsValue;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //Trigger Var
        isGrounded = isJumping;

        other.gameObject.tag.Equals("Enemy");
    }

    void FixedUpdate(){
        //A & D > LeftArrow & RightArrow
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadious, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if (moveInput < 0) {
            transform.eulerAngles = new Vector3(0, 180, 0);
        } 
        else if(moveInput > 0) 
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
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


    //Enemy interaction
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            LVLManager.RespawnUpdate();
        }

        if (col.gameObject.tag.Equals("Kill_Box"))
        {
            Destroy(other);
        }
    }
    
    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}

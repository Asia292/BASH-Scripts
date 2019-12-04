using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private float jumpHeight = 5.0f;
    [SerializeField]
    private float speed = 5.0f;
    private float playerScale = 0.07f;

    private Animator animator;//For the animator.controller FSM
    private bool isJumping; //for the animator.controller FSM
    private bool isWalking; //For the animator.controller FSM

    private bool isOnGround;
    //private bool canDoubleJump;
    private Vector3 currentScale;
    private bool facingRight = true;
    public LayerMask groundLayer; // layer goes here
    
    // Use this for initialization
    void Start ()
    {
        //GameObject.Find("Audio").GetComponent<AudioScript>().PlayMusic();
        //canDoubleJump = true;
        animator = GetComponent<Animator>();
	}

    void Update() {
    if (Input.GetKeyDown(KeyCode.UpArrow))
    {
        if (isOnGround)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 1 * jumpHeight);
            isJumping = true;
        }
        /*else
        {
            if (canDoubleJump)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 1 * jumpHeight);
                canDoubleJump = false;
            }

        }*/
    }
    if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
    {
        float v = Input.GetAxisRaw("Horizontal");
            GetComponent<Rigidbody2D>().velocity = new Vector2(v * speed, GetComponent<Rigidbody2D>().velocity.y);
            isWalking = true;
            if (v < 1) transform.localScale = new Vector3(-playerScale, playerScale, 1);
            else transform.localScale = new Vector3(playerScale, playerScale, 1);
    }
    else
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        isWalking = false;
    }
        
}

    void FlipHorizontal()
    {
        facingRight = !facingRight;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
	
	// Update is called once per frame
    void FixedUpdate () {

        //isOnGround = Physics2D.OverlapCircle(GroundCheck1.position, 0.5f, groundLayer);
        isOnGround = Physics2D.IsTouchingLayers(this.GetComponent<Collider2D>(), groundLayer);
        if (isOnGround)
        {
            isJumping = false;
        }

        animator.SetBool("isJumping",isJumping);
        animator.SetBool("isWalking", isWalking);
}
    public void StopMovement()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]  // to be visible in inspector panel
    private float moveForce = 10f;
    
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private float movementY;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;

    private string WALK_ANIMATION = "walk";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private bool isGrounded;  // bool to check if we are on ground

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }
         
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    private void FixedUpdate()    // not called every frame
    {

    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");   //returns -1(left), 0 or 1(right)

        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime; // moving Player   
        //(Time.deltaTime = time between each frame) used to smooth movement
    }


    void AnimatePlayer()
    {
        if(movementX > 0){
            // moving to the right
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false; // default value
        }
        else if(movementX < 0){
            //moving to the left
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true; // to rotate the player
        }
        else{
            anim.SetBool(WALK_ANIMATION, false); 
        }
    }

    void PlayerJump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded){    // press and release (down)
            //anim.SetBool("jump", true);
            isGrounded = false; // not allow us to jump in the air again 
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // Rigid boddy
    }
    }



    private void OnCollisionEnter2D(Collision2D collision)  // detects collisions betwem rigid bodies
    {
        if(collision.gameObject.CompareTag(GROUND_TAG)){   //detects collisions with ground
            //anim.SetBool("jump", false);
            isGrounded = true;
        }
        if(collision.gameObject.CompareTag(ENEMY_TAG))   //collision with enemies
            Destroy(gameObject);  
    }

    private void OnTriggerEnter2D(Collider2D collision){     // colision with ghost (trigger)
        if (collision.gameObject.CompareTag(ENEMY_TAG))
            Destroy(gameObject);
    }
}//class
 
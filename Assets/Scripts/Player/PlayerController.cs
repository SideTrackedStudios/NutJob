using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpVelocity = 5f;
    public LayerMask playerMask;
    public bool CanMoveInAir = true;
    Transform myTransform;
    Transform groundCheck;
    Rigidbody2D myBody;
    Animator myAnimator;

    public bool isGrounded = false;
    bool isJumping = false;

    float jumpTime = 0f;
    float jumpDelay = .5f;

    // Use this for initialization
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
        groundCheck = GameObject.Find(this.name + "/GroundCheck").transform;
        myAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.Linecast(myTransform.position, groundCheck.position, playerMask);
        myAnimator.SetBool("grounded",isGrounded);
        //move the bastard
        Move(Input.GetAxisRaw("Horizontal"));

        //do we need to jump
        if (Input.GetButtonDown("Jump"))
            Jump();
    }

    public void Move(float horizonatalInput)
    {
        //this is used to keep the player from changing direction while in air.
        //our default will let them do this
        if (!CanMoveInAir && !isGrounded)
            return;
        
        Vector2 moveVelocity = myBody.velocity;

        moveVelocity.x = horizonatalInput * Speed;
        myBody.velocity = moveVelocity;

        //update the animator parameter member with my speed
        myAnimator.SetFloat("speed", Mathf.Abs(horizonatalInput));

        flip(horizonatalInput);
    }
    void flip(float horizonatalInput)
    {
        //moving right
        
        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        if ((myBody.velocity.x > 0 && theScale.x < 0) || myBody.velocity.x < 0 && theScale.x > 0)
        {
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
    public void Jump()
    {
        if (isGrounded)
        {
            myBody.velocity += JumpVelocity * Vector2.up;
            myAnimator.SetTrigger("jump");
        }
        myAnimator.SetBool("grounded", isGrounded);
                            
    }
}

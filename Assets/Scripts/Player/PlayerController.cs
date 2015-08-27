using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float Speed = 10f;
    public float JumpVelocity = 10f;
    public LayerMask playerMask;
    public bool CanMoveInAir = true;

    Transform myTransform;
    Transform groundCheck;
    Rigidbody2D myBody;

    bool isGrounded = false;
    

    // Use this for initialization
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
        groundCheck = GameObject.Find(this.name + "/GroundCheck").transform;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.Linecast(myTransform.position, groundCheck.position, playerMask);

        //move the bastard
        Move(Input.GetAxisRaw("Horizontal"));
        
        //do we need to jump
        if (Input.GetButtonDown("Jump"))
            Jump();
        
    }

    // Update is called once per frame
    void Update()
    {

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
    }
    void flip()
    {
        // Switch the way the player is labelled as facing
     //   facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void Jump()
    {
        if (isGrounded)
            myBody.velocity += JumpVelocity * Vector2.up;
    }
}

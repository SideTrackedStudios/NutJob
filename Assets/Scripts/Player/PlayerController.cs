using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    //set all these variables up in the unity interface
    public float moveSpeed;
    public float jumpHeight;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;
    private bool doubleJumped;
    private float moveVelocity;

    private Animator anim;
    Rigidbody2D rb2D;
    Renderer ren;



    // Use this for initialization
    void Start()
    {
        //anim = GetComponent<Animator> ();
        //rb2D = GetComponent<Rigidbody2D> ();
        //ren = GetComponent<Renderer> ();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        /*
            For keybindings, check out Edit->Project Settings->Input in Unity.  Currently WASD/Joystick movement and Space/A to jump.
        */

        if (grounded)
        {
            doubleJumped = false;
        }

        //anim.SetBool ("Grounded", grounded);

        //jumpy jumpy
        if (Input.GetButtonDown("Jump") && grounded)
        {
            Jump();
        }

        if (Input.GetButtonDown("Jump") && !grounded && !doubleJumped)
        {
            Jump();
            doubleJumped = true;
        }

        //set the moveVel to 0 every frame for more control
        moveVelocity = 0f;

        //move right
        if (Input.GetAxis("Horizontal") > 0)
        {
            //GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
            moveVelocity = moveSpeed;
        }

        //move left
        if (Input.GetAxis("Horizontal") < 0)
        {
            //GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
            moveVelocity = -moveSpeed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector3(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        //anim.SetFloat ("Speed", Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x));

        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
    }
}

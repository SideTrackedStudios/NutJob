using UnityEngine;
using System.Collections;

public class LadderZone : MonoBehaviour {

    private PlayerController thePlayer;
    private Transform theLadder;

    private bool touchingLadder;

    void Start ()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    void FixedUpdate()
    {
        //check to see if player is touching a ladder and presses up
        if (touchingLadder)
        {
            if (Input.GetButtonDown("Vertical"))
            {
                thePlayer.ladderClimb(new Vector2(transform.position.x, transform.position.y));
            }
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.name == "Player") //todo - Create safeEqualsIgnore method
        {
            //thePlayer.onLadder = true;
            touchingLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            //thePlayer.onLadder = false;
            touchingLadder = false;
            thePlayer.ladderExit();
        }
    }
}

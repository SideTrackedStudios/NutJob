using UnityEngine;
using System.Collections;

public class LadderZone : MonoBehaviour {

    private PlayerController thePlayer;

    void Start ()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.name == "Player") //todo - Create safeEqualsIgnore method
        {
            thePlayer.onLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            thePlayer.onLadder = false;
        }
    }
}

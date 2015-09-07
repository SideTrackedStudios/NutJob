using UnityEngine;
using System.Collections;

public class CaveController : MonoBehaviour
{
    public PlayerController player;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (player.CanDig)
        {
            foreach (var item in GameObject.FindGameObjectsWithTag("Cave"))
            {
                item.SetActive(false);
            }
            
        }
    }
}

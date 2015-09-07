using UnityEngine;
using System.Collections;

public class PickupDigAbility : MonoBehaviour
{

    public PlayerController player;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        player.CanDig = true;
        GameObject.Find("DigAbility").SetActive(false);
    }
}

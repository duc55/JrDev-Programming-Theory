using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    Gold,
    Health
}

public class Pickup : MonoBehaviour
{
    public PickupType type;
    public int value;

    void OnPlayerPickup(PlayerBehavior player)
    {
        switch (type)
        {
            case PickupType.Gold:
                player.AddGold(value);
                break;

            default:
                Debug.Log("Picked up item");
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            //get the player
            PlayerBehavior player = other.gameObject.GetComponent<PlayerBehavior>();

            OnPlayerPickup(player);

            Destroy(gameObject);
        }
    }
}

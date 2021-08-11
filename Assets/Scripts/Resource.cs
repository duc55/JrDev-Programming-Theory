using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : Pickup // INHERITANCE
{
    public float respawnTime;

    [Header("Components")]
    public MeshRenderer meshRenderer;
    CapsuleCollider capsuleCollider;

    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            //get the player
            PlayerBehavior player = other.gameObject.GetComponent<PlayerBehavior>();

            OnPlayerPickup(player);

            StartCoroutine("RespawnPickup");
        }
    }

    IEnumerator RespawnPickup()
    {
        //Disable collider
        capsuleCollider.enabled = false;
        Color col = meshRenderer.material.color;
        col.a = 0.1f;
        meshRenderer.material.color = col;

        yield return new WaitForSeconds(respawnTime);

        //Enable collider
        capsuleCollider.enabled = true;
        col.a = 1.0f;
        meshRenderer.material.color = col;
    }
}

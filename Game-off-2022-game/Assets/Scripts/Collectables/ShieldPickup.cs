using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    //public GameObject pickupEffect;

    public int shieldGain = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Pickup(collision));
        }
    }

    IEnumerator Pickup(Collider2D collision)
    {
        //Instantiate(pickupEffect, transform.position, transform.rotation);
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
           
        }
        else
        {
            player = GameObject.Find("Character").GetComponent<Player>();
        }
        player.tempShield(shieldGain);

        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        yield return new WaitForSeconds(5);
        player.tempShield(-shieldGain);
        Destroy(gameObject);
    }
}

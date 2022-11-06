using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    //public GameObject pickupEffect;

    public int healthGain = 20;

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
        player.tempHealth(healthGain);

        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        float healthChange = 0;
        while (healthChange <= healthGain)
        {
            healthChange  += 0.1f;
            yield return new WaitForSeconds(0.1f);
            player.tempHealth(-0.1f);
        }
        
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{
    public int damage = 10;
    private bool PlayerColliding = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                PlayerColliding = true;
            }
            else
            {
                PlayerColliding = true;
                player = GameObject.Find("Character").GetComponent<Player>();
            }
            StartCoroutine(wait(0.75f, player));
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerColliding = false;

        }
    }

    IEnumerator wait(float time, Player player)
    {
        while (PlayerColliding)
        {
            yield return new WaitForSeconds(time);
            player.TakeDamage(damage);
        }
        
    }
}

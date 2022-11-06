using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AIPatrol : MonoBehaviour
{
    public float speed, range;
    private float distToPlayer;

    [HideInInspector]public bool mustPatrol;
    private bool mustTurn;

    public Rigidbody2D Rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public Transform Player;

    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(distToPlayer < range)
        {
            if (Player.position.x > transform.position.x + 0.3 && transform.localScale.x < 0 )
            {
                speed = -120;
            }
            else if (Player.position.x < transform.position.x - 0.3 && transform.localScale.x > 0)
            {
                speed = 120;
            }
        }
        else
        {
            if (Player.position.x > transform.position.x + 0.3 && transform.localScale.x < 0)
            {
                speed = -100;
            }
            else if (Player.position.x < transform.position.x - 0.3 && transform.localScale.x > 0)
            {
                speed = 100;
            }

        }

        if (mustPatrol)
        {
            Patrol();
        }

        distToPlayer = Vector2.Distance(transform.position, Player.position);
        if (distToPlayer < range)
        {
           
            if (distToPlayer != 0)
            {
                if (Player.position.x > transform.position.x + 0.3 && transform.localScale.x < 0 || Player.position.x < transform.position.x - 0.3 && transform.localScale.x > 0)
                {
                    Flip();
                }
            }
            else
            {
                mustPatrol = true;
            }
        }
            
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if ((mustTurn || bodyCollider.IsTouchingLayers(groundLayer)))
        {
            Flip();
        }
        Rb.velocity = new Vector2(speed * Time.fixedDeltaTime, Rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        mustPatrol = true;
    }
}

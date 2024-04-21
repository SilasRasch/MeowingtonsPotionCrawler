using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed = 1f;
    public int MaxDistance = 6;
    public float MinDistance = 0.1f;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < MaxDistance && distance > MinDistance)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;

            // Set velocity towards the player
            rb.velocity = direction * Speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        Flip();
    }

    void Flip()
    { 
        if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
}


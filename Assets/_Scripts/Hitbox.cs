using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private AttackScript attackScript;

    private void Start()
    {
        attackScript = GameObject.Find("Player").GetComponent<AttackScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyStats stats = collision.gameObject.GetComponent<EnemyStats>();

        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Damage or destroy the enemy.
            //Destroy(collision.gameObject);
            stats.TakeDamage(attackScript.baseDamage);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    private ChestScript chestScript;
    private PlayerStats playerStats;
    private PlayerMovement playerMovement;
    private AttackScript attackScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if (gameObject.name.Contains("HP"))
            {
                playerStats = collision.gameObject.GetComponent<PlayerStats>();
                playerStats.maxHealth += 10;
                playerStats.UpdateHealthBar();
                Debug.Log("HP potion picked up");
            }
            if (gameObject.name.Contains("MP"))
            {
                playerStats = collision.gameObject.GetComponent<PlayerStats>();
                playerStats.maxMana += 10;
                playerStats.UpdateManaBar();
                Debug.Log("MP potion picked up");
            }
            if (gameObject.name.Contains("Speed"))
            {
                playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
                if (playerMovement._speed < 3f)
                {
                    playerMovement._speed += 0.5f;
                }
                Debug.Log("Speed potion picked up");
            }
            if (gameObject.name.Contains("Strength"))
            {
                collision.gameObject.GetComponent<AttackScript>().baseDamage += 5;
                Debug.Log("Strength potion picked up");
            }

            Debug.Log("Potion destroyed");
            Destroy(gameObject);
            
        }
    }

}

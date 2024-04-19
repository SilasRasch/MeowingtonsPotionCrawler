using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    public ChestScript chestScript;
    public PlayerStats playerStats;
    public PlayerMovement playerMovement;
    public AttackScript attackScript;

    public float amount;
    public float duration;

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
                collision.gameObject.GetComponent<PlayerStats>().Heal(10);
                Debug.Log("HP potion picked up");
            }
            if (gameObject.name.Contains("MP"))
            {
                collision.gameObject.GetComponent<PlayerStats>().RestoreMana(5);
                Debug.Log("MP potion picked up");
            }
            if (gameObject.name.Contains("Speed"))
            {
                // Duration ???
                // Other fix ???
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

    //private void SpeedPotFunction(float duration)
    //{
    //    playerMovement._speed += 1f;
    //    StartCoroutine(ResetSpeedAfterDuration(duration));
    //}

    //public void ResetSpeed()
    //{
    //    yield return new WaitForSeconds(duration);
    //    playerMovement._speed = 2f;
    //}

}

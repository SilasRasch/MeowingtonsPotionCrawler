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
            //foreach (GameObject item in chestScript.itemDrops)
            //{
            //    if (item == chestScript.HP_Potion_Prefab)
            //    {
            //        HealPotFunction(amount);
            //    }
            //    if (item == chestScript.MP_Potion_Prefab)
            //    {
            //        ManaPotFunction(amount);
            //    }
            //    if (item == chestScript.Speed_Potion_Prefab)
            //    {
            //        SpeedPotFunction(duration);
            //    }
            //    if (item == chestScript.Strength_Potion_Prefab)
            //    {
            //        StrengthPotFunction();
            //    }
            //}

            //DespawnPot();

            if (gameObject.name.Contains("HP"))
            {
                //HealPotFunction(10);
                collision.gameObject.GetComponent<PlayerStats>().Heal(10);
                Debug.Log("HP potion picked up");
            }
            if (gameObject.name.Contains("MP"))
            {
                //ManaPotFunction(5);
                collision.gameObject.GetComponent<PlayerStats>().RestoreMana(5);
                Debug.Log("MP potion picked up");
            }
            if (gameObject.name.Contains("Speed"))
            {
                //SpeedPotFunction(60);
                Debug.Log("Speed potion picked up");
            }
            if (gameObject.name.Contains("Strength"))
            {
                //StrengthPotFunction();
                Debug.Log("Strength potion picked up");
            }

            Debug.Log("Potion destroyed");
            Destroy(gameObject);
            
        }
    }

    private void HealPotFunction(float amount)
    {
        playerStats.Heal(amount);
        //playerStats.health += amount;
        Debug.Log("You got healed for " + amount);
    }

    private void ManaPotFunction(float amount)
    {
        playerStats.RestoreMana(amount);
        //playerStats.mana += amount;
        Debug.Log("Your mana got restored for " + amount);
    }

    private void SpeedPotFunction(float duration)
    {
        playerMovement._speed += 1f;
        StartCoroutine(ResetSpeedAfterDuration(duration));
        Debug.Log("Your speed has been increased");
    }

    private void StrengthPotFunction()
    {
        attackScript.baseDamage += 5;
        Debug.Log("Your strength has increased");
    }

    IEnumerator ResetSpeedAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        playerMovement._speed = 1f;

    }

    private void DespawnPot()
    {
        foreach(GameObject potion in chestScript.itemDrops)
        {
            potion.SetActive(false);
        }
    }
}

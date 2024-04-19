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
        if (collision.gameObject.tag == "player")
        {
            foreach (GameObject item in chestScript.itemDrops)
            {
                if(item == chestScript.HP_Potion_Prefab)
                {
                    HealPotFunction(amount);
                }
                if(item == chestScript.MP_Potion_Prefab)
                {
                    ManaPotFunction(amount);
                }
                if(item == chestScript.Speed_Potion_Prefab)
                {
                    SpeedPotFunction(duration);
                }
                if(item == chestScript.Strength_Potion_Prefab)
                {
                    StrengthPotFunction();
                }
            }

            DespawnPot();
        }
    }

    private void HealPotFunction(float amount)
    {
        playerStats.health += amount;
        Debug.Log("You got healed for " + amount);
    }

    private void ManaPotFunction(float amount)
    {
        playerStats.mana += amount;
        Debug.Log("Your mana got restored for " + amount);
    }

    private void SpeedPotFunction(float duration)
    {
        playerMovement._speed += 1f;
        StartCoroutine(ResetSpeedAfterDuration(duration));
        Debug.Log("You speed has been increased");
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

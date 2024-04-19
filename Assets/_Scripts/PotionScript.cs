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
        playerMovement._speed = 2f;

    }

    private void StrengthPotFunction()
    {
        attackScript.baseDamage += 5;
    }

    IEnumerator ResetSpeedAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);

    }
}

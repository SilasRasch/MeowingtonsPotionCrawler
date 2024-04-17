using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    private GameObject HP_Potion_Prefab;
    private GameObject MP_Potion_Prefab;
    private GameObject Speed_Potion_Prefab;
    private GameObject Strength_Potion_Prefab;


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

    private void SpeedPotFunction()
    {

    }

    private void HealPotFunction()
    {

    }

    private void ManaPotFunction()
    {

    }

    private void StrengthPotFunction()
    {

    }
}

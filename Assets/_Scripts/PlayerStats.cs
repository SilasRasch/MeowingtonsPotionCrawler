using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Slider healthBar_Slider;

    public float mana;
    public float maxMana;
    public Slider manaBar_Slider;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        mana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        UpdateHealthBar();
    }

    public void Heal(float healAmount)
    {
        health += healAmount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthBar_Slider.value = health / maxHealth;
    }

    public void UseMana(float manaCost)
    {
        mana -= manaCost;
        if (mana < 0)
        {
            mana = 0;
        }
        UpdateManaBar();
    }

    public void RestoreMana(float manaAmount)
    {
        mana += manaAmount;
        if (mana > maxMana)
        {
            mana = maxMana;
        }
        UpdateManaBar();
    }

    public void UpdateManaBar()
    {
        manaBar_Slider.value = mana / maxMana;
    }
}

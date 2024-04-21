using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class PlayerStats : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Slider healthBar_Slider;

    public float mana;
    public float maxMana;
    public Slider manaBar_Slider;

    private float timer;
    private float dmgSoundTimer;


	[SerializeField] private AudioClip catSoundDamageTaken;

	// Start is called before the first frame update
	void Start()
    {
        timer = 0;
        dmgSoundTimer = 1f;
        health = maxHealth;
        mana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        dmgSoundTimer += Time.deltaTime;

        if (timer >= 1)
        {
            Heal(1);
            RestoreMana(1);
            timer = 0;
        }

        UpdateHealthBar();
        UpdateManaBar();
    }

    public void Die()
    {
        UpdateHealthBar();

        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        UpdateHealthBar();

        // Sound
        if (dmgSoundTimer >= 1f)
        {
            SoundManager.instance.PlaySound(catSoundDamageTaken);
            dmgSoundTimer = 0;
        }
		
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
        if (health <= 0)
        {
            health = 0;
        }
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
        if (mana <= 0)
        {
            mana = 0;
        }
        manaBar_Slider.value = mana / maxMana;
    }
}

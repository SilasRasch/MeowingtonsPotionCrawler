using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float health;
    public float maxHealth;
	[SerializeField] private AudioClip enemyDamageTaken;
	[SerializeField] private AudioClip enemyDeathSound;
	// Start is called before the first frame update
	void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Die()
    {
        Destroy(gameObject);
		SoundManager.instance.PlaySound(enemyDeathSound);
	}

	public void TakeDamage(float damage)
	{
		health -= damage;
		if (health <= 0)
		{
			Die();
		}
		else
		{
			SoundManager.instance.PlaySound(enemyDamageTaken);
		}
	}

	//private void OnCollisionEnter2D(Collision2D collision)
	//{
	//    if (collision.gameObject.tag == "PlayerStaff")
	//    {
	//        TakeDamage(10);
	//    }
	//}

}

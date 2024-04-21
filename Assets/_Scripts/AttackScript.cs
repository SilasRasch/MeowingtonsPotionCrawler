using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
	[SerializeField] private AudioClip MeleeAttackSound;
	private Animator animator;
    private CapsuleCollider2D hitbox;
    private GameObject staff;
    private Vector3 rotation;
    private float timer;
    private bool CanHit;

    public float baseDamage = 20;

    private void Start()
    {
        timer = 0;
        CanHit = true;
        staff = GameObject.Find("Player_Staff");
        animator = staff.GetComponent<Animator>();
        hitbox = staff.transform.Find("HitBox").GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if (!CanHit)
        {        
            timer += Time.deltaTime;

            if (timer > 0.2f)
            {
                CanHit = true;
                timer = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && CanHit) // Attack on Space key press.
        {
            SoundManager.instance.PlaySound(MeleeAttackSound);
            //Debug.Log("Attack");
            //animator.SetTrigger("MeleeAttack");
            Invoke("ActivateHitbox", 0.2f); // Activate hitbox after 0.2 seconds.
            
            Invoke("DeactivateHitbox", 0.4f); // Deactivate hitbox after 0.4 seconds.

            CanHit = false;
            timer = 0;
        }
    }

    void ActivateHitbox()
    {
        // Get Z-rotation to reset later
        rotation = staff.transform.eulerAngles;

        // set hitbox active
        hitbox.gameObject.SetActive(true);
        //animator.SetBool("IsFlipped", staff.GetComponentInParent<PlayerMovement>().IsFlipped);
        //animator.SetBool("IsMeleeing", true);

        // Run "Animation"
        staff.transform.eulerAngles = new Vector3(rotation.x,
                        rotation.y,
                        -50);
    }

    void DeactivateHitbox()
    {
        // Deactivate hitbox
        hitbox.gameObject.SetActive(false);
        //animator.SetBool("IsMeleeing", false);

        // Reset staff-rotation
        staff.transform.eulerAngles = rotation;
    }
}

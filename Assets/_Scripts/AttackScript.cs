using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private Animator animator;
    private CapsuleCollider2D hitbox;
    private GameObject staff;
    private Vector3 rotation;

    public float baseDamage = 20;

    private void Start()
    {
        staff = GameObject.Find("Player_Staff");
        animator = staff.GetComponent<Animator>();
        hitbox = staff.transform.Find("HitBox").GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Attack on Space key press.
        {
            //Debug.Log("Attack");
            //animator.SetTrigger("MeleeAttack");
            Invoke("ActivateHitbox", 0.2f); // Activate hitbox after 0.2 seconds.
            
            Invoke("DeactivateHitbox", 0.4f); // Deactivate hitbox after 0.4 seconds.
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

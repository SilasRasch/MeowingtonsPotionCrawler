using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private Animator animator;
    private CapsuleCollider2D hitbox;
    private GameObject staff;

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
        hitbox.gameObject.SetActive(true);
    }

    void DeactivateHitbox()
    {
        hitbox.gameObject.SetActive(false);
    }
}

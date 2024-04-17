using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force = 1f;
    private AttackScript attackScript;
    public float TimeToLive = 1.5f;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        attackScript = GameObject.Find("Player").GetComponent<AttackScript>();

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();

        // Get target
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        // Launch projectile
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        // Rotate
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > TimeToLive)
        {
            Destroy(gameObject);
        }

        timer += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyStats stats = collision.gameObject.GetComponent<EnemyStats>();
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            stats.TakeDamage(attackScript.baseDamage * 2);
        }

        Destroy(gameObject);
    }
}

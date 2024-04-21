using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastFireballScript : MonoBehaviour
{
	[SerializeField] private AudioClip fireBallSound;
	private Camera mainCam;
    private Vector3 mousePos;
    public GameObject Projectile;
    public Transform ProjectileTransform;
    public bool CanFire;
    private float timer;
    public float timeBetweenFiring;
    private GameObject player;
    private PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.Find("Player");
        stats = player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
		// Make spawn-box follow cursor position
		mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        
        // Check if can fire
        if (!CanFire)
        {
            timer += Time.deltaTime;

            if (timer > timeBetweenFiring && stats.mana >= 10)
            {
                CanFire = true;
                timer = 0;
            }
        }

        // Fire projectile
        if (Input.GetMouseButtonDown(0) && CanFire)
        {
			SoundManager.instance.PlaySound(fireBallSound);
			CanFire = false;
            Instantiate(Projectile, ProjectileTransform.position, Quaternion.identity);
            stats.UseMana(10);
        }
    }
}

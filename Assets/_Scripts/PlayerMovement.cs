using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [field: SerializeField]
    private float _speed = 1f;
    private float _actualSpeed;
    public int Lives = 3; // Should be moved
    public int Points = 0;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidBody;
    public float horizontal;
    public float vertical;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (horizontal > 0)
        {
            _spriteRenderer.flipX = false;
        }

        if (Lives <= 0)
            gameObject.SetActive(false);

    }

    private void FixedUpdate()
    {
        _actualSpeed = _speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _actualSpeed = _speed * 1.5f;
        }

        _rigidBody.velocity = new Vector2(horizontal * _actualSpeed, vertical * _actualSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Lives--;
        }

        if (collision.gameObject.tag == "Heart")
        {
            Lives++;
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Coin")
        {
            Points++;
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "SpeedPotion")
        {
            _speed += 1;
            collision.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [field: SerializeField]
    public float _speed = 1f;
    private float _actualSpeed;
    private GameObject _staff;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidBody;
    public float horizontal;
    public float vertical;
    public Vector3 _staffRightPosition = new Vector3(0.35f, -0.026f, 0.068f);
    public Vector3 _staffLeftPosition = new Vector3(-0.385f, -0.008f, 0.068f);
    public bool IsFlipped { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _staff = GameObject.Find("Player_Staff");
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal < 0)
        {
            FlipStaff(true);
        }
        else if (horizontal > 0)
        {
            FlipStaff(false);
        }
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

    private void FlipStaff(bool isFlipped)
    {
        if (isFlipped == true)
        {
            //IsFlipped = true;
            _spriteRenderer.flipX = true;
            _staff.transform.position = this.transform.position + _staffLeftPosition;
            _staff.transform.eulerAngles = new Vector3(
                _staff.transform.eulerAngles.x,
                180,
                _staff.transform.eulerAngles.z);
        }
        else
        {
            //IsFlipped = false;
            _spriteRenderer.flipX = false;
            _staff.transform.position = this.transform.position + _staffRightPosition;
            _staff.transform.eulerAngles = new Vector3(
                _staff.transform.eulerAngles.x,
                0,
                _staff.transform.eulerAngles.z);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Monster")
    //    {
    //        Lives--;
    //    }

    //    if (collision.gameObject.tag == "Heart")
    //    {
    //        Lives++;
    //        collision.gameObject.SetActive(false);
    //    }

    //    if (collision.gameObject.tag == "Coin")
    //    {
    //        Points++;
    //        collision.gameObject.SetActive(false);
    //    }

    //    if (collision.gameObject.tag == "SpeedPotion")
    //    {
    //        _speed += 1;
    //        collision.gameObject.SetActive(false);
    //    }
    //}
}

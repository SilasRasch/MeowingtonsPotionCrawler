using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [field: SerializeField]
    private float _speed = 1f;
    private float _actualSpeed;
    private GameObject _staff;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidBody;
    public float horizontal;
    public float vertical;
    public Vector3 _staffRightPosition = new Vector3(0.35f, -0.026f, 0.068f);
    //public Quaternion _staffRightRotation = new Quaternion(0, 0, -18.747f);
    public Vector3 _staffLeftPosition = new Vector3(-0.385f, -0.008f, 0.068f);
    //public Vector3 _staffLeftRotation = new Vector3(0, 180, -18.747f);

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
            _spriteRenderer.flipX = true;
            _staff.transform.position = this.transform.position + _staffLeftPosition;
            _staff.transform.eulerAngles = new Vector3(
                _staff.transform.eulerAngles.x,
                180,
                _staff.transform.eulerAngles.z);
        }
        else if (horizontal > 0)
        {
            _spriteRenderer.flipX = false;
            _staff.transform.position = this.transform.position + _staffRightPosition;
            _staff.transform.eulerAngles = new Vector3(
                _staff.transform.eulerAngles.x,
                0,
                _staff.transform.eulerAngles.z);
        }
    }

    private void FixedUpdate()
    {
        //_rigidBody.velocity = Vector2.zero;
        Debug.Log(_rigidBody.velocity);
        _actualSpeed = _speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _actualSpeed = _speed * 1.5f;
        }

        _rigidBody.velocity = new Vector2(horizontal * _actualSpeed, vertical * _actualSpeed);
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

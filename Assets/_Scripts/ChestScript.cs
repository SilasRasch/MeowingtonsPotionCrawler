using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite openSprite, closedSprite;

    private bool isOpen;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!isOpen)
            {
                _animator.SetBool("IsOpen", true);
                spriteRenderer.sprite = openSprite;
                isOpen = true;
            }
        }
    }
}

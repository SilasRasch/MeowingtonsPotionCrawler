using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Animation
        if (_rb.velocity != Vector2.zero)
        {
            _animator.SetFloat("Moving", 1);
        }
        else
        {
            _animator.SetFloat("Moving", 0);
        }
    }
}

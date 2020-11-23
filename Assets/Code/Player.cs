using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _moveVelocity;
    private float _jumpForce;
    private bool _hasJump;
    void Start()
    {
        _rb = (Rigidbody2D) GetComponent<Rigidbody2D>();
        _moveVelocity = 5;
        _jumpForce = 500;
        _hasJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Controls
        // Movement: arrow keys (l/r)
        // Jumping: arrow keys (up)
        // Shooting: spacebar 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // TODO: Implement Shoot   
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.velocity = new Vector2(-_moveVelocity, _rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb.velocity = new Vector2(_moveVelocity, _rb.velocity.y);   
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && _hasJump)
        {
            _rb.AddForce(_jumpForce * Vector2.up);
            _hasJump = false;
        } 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            _hasJump = true;
        }
    }
}

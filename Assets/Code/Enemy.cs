using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rb;
    private UnityEngine.Object _key;
    private float _jumpForce;
    private bool _hasJump;
    private float _coolDown;
    private bool _isJumping;
    void Start()
    {
        _jumpForce = 500f;
        _coolDown = 0.5f;
        _rb = (Rigidbody2D) GetComponent<Rigidbody2D>();
        _isJumping = false;
        _hasJump = true;
        _key = Resources.Load("Key");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!_isJumping)
        {
            _coolDown -= Time.deltaTime;
        }
        
        if (_coolDown <= 0f)
        {
            _coolDown = Random.Range(0.5f, 3f);
            _hasJump = true;
        }
        
        if (_hasJump)
        {
            _rb.AddForce(_jumpForce * Vector2.up);
            _hasJump = false;
            _isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            _isJumping = false;
        }

        if (other.gameObject.tag == "Bullet")
        {
            var p = FindObjectOfType<Player>();
            p.EnemyDies();
            Instantiate(_key, _rb.position, new Quaternion());
            Destroy(gameObject);
        }
    }
}

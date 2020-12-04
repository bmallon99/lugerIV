using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Object _bullet;
    private float _moveVelocity;
    private float _jumpForce;
    private bool _hasJump;
    internal static bool _hasGun = false;
    public Sprite playerWithBoots;
    public Sprite playerWithGun;
    // Audio clips //
    public AudioClip death;
    public AudioClip pickUpKey;
    public AudioClip shoot;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _rb = (Rigidbody2D) GetComponent<Rigidbody2D>();
        _bullet = Resources.Load("Bullet");
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
        if (Input.GetKeyDown(KeyCode.Space) && _hasGun)
        {
            GameObject b = Instantiate(_bullet, new Vector2(_rb.position.x + 0.5f, _rb.position.y), new Quaternion()) as GameObject;
            var comp = b.GetComponent<Rigidbody2D>();
            comp.velocity = new Vector2(6f, 0f);
            audioSource.PlayOneShot(shoot, 0.5f);
        }
    }

    public void EnemyDies()
    {
        audioSource.PlayOneShot(death, 0.5f);
    }

    public void PickUpKey()
    {
        audioSource.PlayOneShot(pickUpKey, 0.5f);
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

        if (other.gameObject.tag == "Boots")
        {
            var sr = GetComponent<SpriteRenderer>();
            sr.sprite = playerWithBoots;
            BossEdge.boots = true;
        }

        if (other.gameObject.tag == "Gun")
        {
            var sr = GetComponent<SpriteRenderer>();
            sr.sprite = playerWithGun;
            _hasGun = true;
        }
    }
}

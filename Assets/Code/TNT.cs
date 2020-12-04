using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour
{
    public Sprite explosion;
    public AudioClip explode;
    internal AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BlowUp()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            audioSource.PlayOneShot(explode, 0.5f);
            var sr = GetComponent<SpriteRenderer>();
            sr.sprite = explosion;
            gameObject.transform.localScale = new Vector3(3f, 3f, 1f);
            var wbu = FindObjectOfType<WallBlowUp>();
            wbu.BlowUp();
            Invoke("BlowUp", 1f);
        }
    }
}

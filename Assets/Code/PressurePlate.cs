using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public AudioClip activate;
    internal AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            audioSource.PlayOneShot(activate, 0.5f);
            var sr = GetComponent<SpriteRenderer>();
            sr.color = Color.green;
            var nl = FindObjectOfType<NextLevel>();
            nl.Unlock();
        }
    }
}

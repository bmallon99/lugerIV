using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip openDoor;
    public AudioClip bSound;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        audioSource.PlayOneShot(openDoor, 0.5f);
    }

    public void BNoise()
    {
        audioSource.PlayOneShot(bSound, 0.5f);
    }
}

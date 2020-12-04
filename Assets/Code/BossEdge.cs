using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEdge : MonoBehaviour
{
    public static bool boots = false;
   
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && boots)
        {
            var b = FindObjectOfType<Boss>();
            b.makeB();
        }
    }
}

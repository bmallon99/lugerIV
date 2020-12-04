﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var nl = FindObjectOfType<NextLevel>();
            nl.Unlock();
            Destroy(gameObject);
        }
    }
}

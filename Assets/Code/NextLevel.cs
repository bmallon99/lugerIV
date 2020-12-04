using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class NextLevel : MonoBehaviour
{
    private int levelNum;
    private bool isLocked = false;
    public Sprite unlockedDoor;

    // Start is called before the first frame update
    void Start()
    {
        var name = SceneManager.GetActiveScene().name;
        levelNum = Int32.Parse(name.Substring(name.Length - 1));
        if (levelNum != 0 && levelNum != 3 && levelNum != 5)
        {
            isLocked = true;
        }
        if (levelNum != 0)
        {
            Player._hasGun = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Unlock()
    {
        isLocked = false;
        var sr = GetComponent<SpriteRenderer>();
        sr.sprite = unlockedDoor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isLocked)
        {
            if (levelNum != 5)
            {
                var ds = FindObjectOfType<DoorSound>();
                ds.OpenDoor();
            }
            levelNum++;
            SceneManager.LoadScene("level" + levelNum.ToString());
            isLocked = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class NextLevel : MonoBehaviour
{
    private int levelNum;
    private static bool isLocked = false;

    // Start is called before the first frame update
    void Start()
    {
        var name = SceneManager.GetActiveScene().name;
        levelNum = Int32.Parse(name.Substring(name.Length - 1));
        if (levelNum != 0)
        {
            isLocked = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Unlock()
    {
        isLocked = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isLocked)
        {
            levelNum++;
            SceneManager.LoadScene("level" + levelNum.ToString());
            isLocked = true;
        }
    }
}

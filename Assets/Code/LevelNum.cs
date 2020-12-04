using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LevelNum : MonoBehaviour
{
    private static Text _levelText;
    private int levelNum;
    // Start is called before the first frame update
    void Start()
    {
        var name = SceneManager.GetActiveScene().name;
        levelNum = Int32.Parse(name.Substring(name.Length - 1));
        _levelText = GetComponentInChildren<Text>();
        if (levelNum != 6)
        {
            _levelText.text = "Level " + levelNum.ToString();
        }
        else
        {
            _levelText.text = "You're winner";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

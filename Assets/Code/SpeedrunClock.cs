using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedrunClock : MonoBehaviour
{    
    private static Text _levelText;
    internal static bool counting = true;
    internal static float finalTime;
    // Start is called before the first frame update
    void Start()
    {
        _levelText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counting)
        {
            finalTime = Time.time;
        }
        _levelText.text = "Time: " + finalTime.ToString();
    }
}

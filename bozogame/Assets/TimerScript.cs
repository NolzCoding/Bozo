using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI text;

    
    
    
    
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        int mins = (int)Time.time / 60;
        int secs = (int) (Time.time - mins * 60);

        text.text = mins + ":" + secs;
    }
}

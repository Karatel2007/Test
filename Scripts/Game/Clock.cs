using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{

    public TextMeshProUGUI timerText; 
    public TextMeshProUGUI dayText; 
    private float timeInSeconds; 
    private int days;
    private int skipTime = 1;
    private void Start()
    {
        timeInSeconds = 0f; 
        days = 0; 
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            skipTime = 60;
        }
        else
        {
            skipTime = 1;
        }
        timeInSeconds += Time.deltaTime * skipTime;

        if (timeInSeconds >= 24 * 60)
        {
            days++; 
            timeInSeconds -= 24 * 60; 
        }
        
        
        int hours = (int)(timeInSeconds / 60);
        int minutes = (int)(timeInSeconds % 60);

        

        timerText.text = string.Format("{0}.{1:D2}",hours, minutes);
        dayText.text = string.Format("Day: {0}", days);
    }
}
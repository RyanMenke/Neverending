using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop
{
    public bool isTimeStopped;
    public float coolDown = 0.0f;
    public float duration = 3.0f;
    
    public void TimeHandler()
    {
        if (Input.GetKeyDown(KeyCode.E) && coolDown <= 0)
        {
            isTimeStopped = true;
        }

        if (duration <= 0)
        {
            isTimeStopped = false;
            duration = 3.0f;
            coolDown = 5.0f;
        }
        
        if (isTimeStopped)
        {
            duration -= Time.deltaTime;
        }

        if (coolDown > 0 && !isTimeStopped)
        {
            coolDown -= Time.deltaTime;
        }
        
    }
}

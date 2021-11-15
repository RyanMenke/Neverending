using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStopPower : MonoBehaviour
{
    [SerializeField] private float timeStopDuration;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StopTime();
        }
    }

    private void StopTime()
    {
        if (TimeManager.IsTimeStopped())
            return;
        
        TimeManager.StopTime();
        StartCoroutine(ResumeTimeAfterDelay());
    }

    IEnumerator ResumeTimeAfterDelay()
    {
        yield return new WaitForSeconds(timeStopDuration);
        
        if (TimeManager.IsTimeStopped())
            TimeManager.ResumeTime();
    }
    
    
}

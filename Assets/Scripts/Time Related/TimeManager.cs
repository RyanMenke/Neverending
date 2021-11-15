using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    private static bool timeIsStopped = false;

    public static bool IsTimeStopped() => timeIsStopped;

    public static event Action timeStoppedEvent;
    public static event Action timeResumedEvent;

    public static void StopTime()
    {
        if (timeIsStopped)
            return;

        timeIsStopped = true;
        
        if (timeStoppedEvent != null)
            timeStoppedEvent();
    }

    public static void ResumeTime()
    {
        if (!timeIsStopped)
            return;
        
        timeIsStopped = false;

        if (timeResumedEvent != null)
            timeResumedEvent();
    }
}
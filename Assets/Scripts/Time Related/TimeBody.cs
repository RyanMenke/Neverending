using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    
    private Vector2 velocityAtFreeze;
    private Vector2 positionAtFreeze;
    private RigidbodyType2D rbTypeAtFreeze;
    
    private Vector2 velocityAccrued;

    private void OnEnable()
    {
        TimeManager.timeStoppedEvent += OnTimeStopped;
        TimeManager.timeResumedEvent += OnTimeResumed;
    }

    private void OnDisable()
    {
        TimeManager.timeStoppedEvent -= OnTimeStopped;
        TimeManager.timeResumedEvent -= OnTimeResumed;
    }

    private void Update()
    {
        if (TimeManager.IsTimeStopped())
            transform.position = positionAtFreeze;
    }

    private void OnTimeStopped()
    {
        velocityAtFreeze = (rb) ? rb.velocity : Vector2.zero;
        positionAtFreeze = transform.position;
        rbTypeAtFreeze = (rb) ? rb.bodyType : RigidbodyType2D.Dynamic;
        
        velocityAccrued = Vector2.zero;

        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnTimeResumed()
    {
        rb.velocity = (velocityAccrued.magnitude > 0) ? velocityAccrued : velocityAtFreeze;
        rb.bodyType = rbTypeAtFreeze;
    }
}
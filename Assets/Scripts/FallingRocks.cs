using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRocks : MonoBehaviour
{
    public Collider2D rocks;
    public TimeStop tStop;
    
    // Start is called before the first frame update
    void Start()
    {
        rocks = GetComponent<Collider2D>();
        tStop = new TimeStop();
    }

    // Update is called once per frame
    void Update()
    {
        tStop.TimeHandler();
        if (!tStop.isTimeStopped)
        {
            rocks.transform.position += (Vector3.down * Time.deltaTime);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTime
{ 
    TimeSpan time;

    public TimeSpan Time { get => time; /*set => time = value;*/ }

    public ClockTime(TimeSpan time)
    {
        this.time = time;
    }

    public override string ToString()
    {
        return time.Hours + ":" + time.Minutes + ":" + time.Seconds;
    }
}

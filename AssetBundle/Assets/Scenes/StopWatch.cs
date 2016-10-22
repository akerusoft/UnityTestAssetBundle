using UnityEngine;
using System.Collections;

static public class StopWatch
{
    static private System.Diagnostics.Stopwatch _stopWatch = new System.Diagnostics.Stopwatch();

    static public void Start()
    {
        _stopWatch.Reset();
        _stopWatch.Start();
    }

    static public long Stop()
    {
        _stopWatch.Stop();
        return _stopWatch.ElapsedMilliseconds;
    }
}

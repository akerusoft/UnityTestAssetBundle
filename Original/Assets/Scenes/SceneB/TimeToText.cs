using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimeToText : MonoBehaviour
{
    Text _text;

    void Awake()
    {
        _text = GetComponent<Text>();
    }

    void Start()
    {
        _text.text = string.Format("{0}[ms]\nAllocated Memory:{1}", StopWatch.Stop(), Profiler.GetTotalAllocatedMemory());
    }
}

using UnityEngine;
using System;

public class DigitalClock : MonoBehaviour
{

    public Color activeColor;
    public Color inactiveColor;

    public GameObject hourNumberLeft;
    public GameObject hourNumberRight;
    public GameObject minuteNumberLeft;
    public GameObject minuteNumberRight;
    public GameObject secondNumberLeft;
    public GameObject secondNumberRight;

    private void Update()
    {
        DateTime currentTime = DateTime.Now;
        SetNumber(hourNumberLeft, currentTime.Hour / 10);
        SetNumber(hourNumberRight, currentTime.Hour % 10);
        SetNumber(minuteNumberLeft, currentTime.Minute / 10);
        SetNumber(minuteNumberRight, currentTime.Minute % 10);
        SetNumber(secondNumberLeft, currentTime.Second / 10);
        SetNumber(secondNumberRight, currentTime.Second % 10);
    }

    void SetNumber(GameObject numberGameObject, int number)
    {
        bool[] segments = GetSegments(number);

        for (int i = 0; i < 7; i++)
        {
            GameObject segment = numberGameObject.transform.Find($"segment{i}").gameObject;
            Renderer renderer = segment.GetComponent<Renderer>();
            renderer.material.color = segments[i] ? activeColor : inactiveColor;
        }
    }

    bool[] GetSegments(int number)
    {
        bool[][] segments = new bool[][]
        {
            new bool[] { true, true, true, true, true, true, false },       // 0
            new bool[] { false, true, true, false, false, false, false },   // 1
            new bool[] { true, true, false, true, true, false, true },      // 2
            new bool[] { true, true, true, true, false, false, true },      // 3
            new bool[] { false, true, true, false, false, true, true },     // 4
            new bool[] { true, false, true, true, false, true, true },      // 5
            new bool[] { true, false, true, true, true, true, true },       // 6
            new bool[] { true, true, true, false, false, false, false },    // 7
            new bool[] { true, true, true, true, true, true, true },        // 8
            new bool[] { true, true, true, true, false, true, true }        // 9
        };

        return segments[number];
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using UnityEngine.UIElements;

public class TimeTrackerLogic : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    [SerializeField] public double currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        timeText.text = "Time: " +  Math.Round(currentTime, 2);;
    }
}

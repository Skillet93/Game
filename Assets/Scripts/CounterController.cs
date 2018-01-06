using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterController : MonoBehaviour
{
    public Text counterView;
    public Text jumpCounterView;
    public Text timmerView;
    private int numberOfBoxes;
    private int numberOfAvailableJumps;
    private float timer;
    

    // Use this for initialization
    void Start()
    {
        ResetCounter();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        timmerView.text = string.Format("{0}", Math.Round(timer, 0));
    }

    private void ResetCounter()
    {
        timer = 0;
        numberOfBoxes = 0;
        counterView.text = numberOfBoxes.ToString();
        numberOfAvailableJumps = 0;
        jumpCounterView.text = numberOfAvailableJumps.ToString();
    }

    public void IncrementCounter()
    {
        numberOfBoxes++;
        numberOfAvailableJumps++;
        counterView.text = numberOfBoxes.ToString();
        jumpCounterView.text = numberOfAvailableJumps.ToString();
    }

    public void DecrementJumpCounter()
    {
        numberOfAvailableJumps--;
        jumpCounterView.text = numberOfAvailableJumps.ToString();
    }

    public bool IsAvailablePowerJump()
    {
        return numberOfAvailableJumps > 0;
    }
}
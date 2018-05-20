using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTest : MonoBehaviour {

    [SerializeField] private Timer timer;

    System.Action onTimerEnd = delegate { };

    private void Awake()
    {
        onTimerEnd = () => ConfirmTime();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            timer.CallBackIn(1, onTimerEnd);
        }
    }

    void ConfirmTime()
    {
        Debug.Log("I'm aware");
    }
}

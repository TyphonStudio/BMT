using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public void CallBackIn(float time, System.Action callBack)
    {
        StartCoroutine(Measure(time, callBack));
    }

    IEnumerator Measure(float time, System.Action onTime)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("time!");
        onTime?.Invoke();
    }
}

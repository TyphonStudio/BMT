using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comparison : MonoBehaviour {

    public static int CompareByDistanceFromObject(Transform one, Transform two, Transform center)
    {
        float distanceFromOne = (one.transform.position - center.transform.position).sqrMagnitude;
        float distanceFromTwo = (two.transform.position - center.transform.position).sqrMagnitude;

        int compare = distanceFromOne.CompareTo(distanceFromTwo);

        if(compare != 0)
        {
            return compare;
        }
        else
        {
            return 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTest : MonoBehaviour {

    public MyPool pool;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            pool.GetFromPool();
        }
    }
}

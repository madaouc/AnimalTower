using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCount : MonoBehaviour
{
    public float second = 2;
    float countSecond = 0;
    bool counterStart = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Press P to Start Timer");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            countSecond = 0.0f;
            counterStart = true;
        }

        if(counterStart)
        {
            countSecond += Time.deltaTime;
            Debug.Log(countSecond);
            if(countSecond > second)
            {
                Debug.Log("Times up");
                //countSecond = 0.0f;
                counterStart = false;
                Debug.Log("Press P to restart Timer");
            }
        }


    }
}

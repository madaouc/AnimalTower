using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraYFollow : MonoBehaviour
{
    public GameObject zoo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = transform.position;
        camPos.y = zoo.transform.position.y;
        transform.position = camPos;
    }
}

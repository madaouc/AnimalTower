using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTest : MonoBehaviour
{
     GameObject zoo;

    // Start is called before the first frame update
    void Start()
    {
        zoo = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 camPos = transform.position;
        camPos.y = zoo.transform.position.y;
        transform.position = camPos;
    }

}

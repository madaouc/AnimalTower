using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZooKeepingTest : MonoBehaviour
{
    public GameObject []animals;
    GameObject currentAnimal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            int randNum = Random.Range(0, 3);
            Debug.Log(randNum);
            //Vector3 spawnPos = transform.position;
            //Quaternion spawnRot = transform.rotation;


            currentAnimal =  Instantiate(animals[randNum]);
            currentAnimal.transform.position = transform.position;
        }
    }
}

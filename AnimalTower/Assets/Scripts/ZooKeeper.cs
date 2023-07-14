using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZooKeeper : MonoBehaviour
{
    public GameObject [] animals;

    GameObject currentAnimal;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");

        Vector3 zooPos = transform.position;

        // x = x + 1

        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D");
        }

        transform.position = zooPos;

        if (Input.GetButtonDown("Jump"))
        {
            int index = Random.Range(0, 3);
            
            currentAnimal = Instantiate(animals[index]);
            currentAnimal.transform.position = transform.position;
        }



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZooKeeper : MonoBehaviour
{
    public GameObject [] animals;
    GameObject currentAnimal;

    public float movement = 0.2f;

    bool haveAnimal = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");
    
    //zoo move
        Vector3 zooPos = transform.position;
        // x = x + 1
        if(Input.GetKey(KeyCode.A))
        {
            
            Debug.Log("A");
            zooPos.x = zooPos.x - movement * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            Debug.Log("D");
            zooPos.x = zooPos.x + movement * Time.deltaTime;
        }
        transform.position = zooPos;


    //spawn animal
        //if (Input.GetKeyDown(KeyCode.M) && haveAnimal == false) 
        if (Input.GetKeyDown(KeyCode.M) && !haveAnimal) 
        {
            haveAnimal = true;
            
            int index = Random.Range(0, animals.Length);
            currentAnimal = Instantiate(animals[index]);
            currentAnimal.transform.position = transform.position;
        }

        //if (Input.GetKeyDown(KeyCode.Space) && haveAnimal == true)
        if (Input.GetKeyDown(KeyCode.Space) && haveAnimal)
        {
            currentAnimal.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            haveAnimal = false;
        }   



    }
}

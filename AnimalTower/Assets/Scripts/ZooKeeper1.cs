using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZooKeeper1 : MonoBehaviour
{
    public GameObject [] animals;
    GameObject currentAnimal;

    [Header("Zoo Movement")]
    public float movement = 0.5f;
    public int turns = 8;
    int turnCount = 0;

    public float gravity = 0.5f;

    bool haveAnimal = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            moveLeft();
        if (Input.GetKeyDown(KeyCode.D))
            moveRight();



        //spawn animal
        //if (Input.GetKeyDown(KeyCode.M) && haveAnimal == false) 
        if (Input.GetKeyDown(KeyCode.M) && !haveAnimal) 
        {
            haveAnimal = true;

            int index = Random.Range(0, animals.Length);
            currentAnimal = Instantiate(animals[index]);
            currentAnimal.transform.position = transform.position;
            turnCount = 0;
        }

        //if (Input.GetKeyDown(KeyCode.Space) && haveAnimal == true)
        if (Input.GetKeyDown(KeyCode.Space) && haveAnimal)
        {
            currentAnimal.GetComponent<Rigidbody2D>().gravityScale =
                gravity;
            haveAnimal = false;
        }
      
    

    //animal Rotation
        if(Input.GetKeyDown(KeyCode.E))
        {
            //turnCount = turnCount + 1;
            turnCount -= 1;
        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            turnCount += 1;
        }

        float zAngle = (360.0f / turns) * turnCount;
        //Debug.Log("zAngle: " + zAngle);

        Vector3 animalRot = new Vector3(0.0f, 0.0f, zAngle);
        
        if(haveAnimal)
        {
            currentAnimal.transform.eulerAngles =
                animalRot;
        }


        

    }

    void moveLeft()
    {
        Vector3 zooPos = transform.position;
        zooPos.x = zooPos.x - movement;
        transform.position = zooPos;
        //animal follow    
        if (haveAnimal)
        {
            currentAnimal.transform.position = transform.position;
        }
    }
    void moveRight()
    {
        Vector3 zooPos = transform.position;
        zooPos.x = zooPos.x + movement;
        transform.position = zooPos;
        //animal follow    
        if (haveAnimal)
        {
            currentAnimal.transform.position = transform.position;
        }
    }

    
    void rotate()
    {

    }



}

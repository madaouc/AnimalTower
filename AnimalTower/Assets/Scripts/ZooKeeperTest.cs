using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZooKeeperTest : MonoBehaviour
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



    //zoo Move
        if (Input.GetKey(KeyCode.A))
            move(-1);
        if (Input.GetKey(KeyCode.D))
            move(1);




        //animal Rotation
        if (Input.GetKeyDown(KeyCode.E))
        {
            rotate();    
        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            rotate(1);
        }

        
    }

    void move(int dir)
    {
        //dir: -1, left; 1, right
        Vector3 zooPos = transform.position;
        zooPos.x = zooPos.x + movement * Time.deltaTime * dir;    
        transform.position = zooPos;

        if (haveAnimal)
        {
            currentAnimal.transform.position = transform.position;
        }
    }

 
    void rotate(int dir = -1)
    {
        //dir: -1, clockwise
        turnCount += dir;
      
        float zAngle = (360.0f / turns) * turnCount;
        //Debug.Log("zAngle: " + zAngle);

        Vector3 animalRot = new Vector3(0.0f, 0.0f, zAngle);
        if (haveAnimal)
        {
            currentAnimal.transform.eulerAngles =
                animalRot;
        }
    }

}

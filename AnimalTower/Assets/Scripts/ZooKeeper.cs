using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZooKeeper : MonoBehaviour
{
    public GameObject [] animals;
    GameObject currentAnimal;

    [Header("Zoo Movement")]
    public float movement = 0.5f;
    public int turns = 8;
    int turnCount = 0;

    public float gravity = 0.5f;
    bool haveAnimal = false;

    AudioSource SE;

    //timer
    public float coolDown = 2.0f;
    float countTime = 0.0f;
    bool timesUp = true;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        SE = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            moveLeft();
        if (Input.GetKeyDown(KeyCode.D))
            moveRight();
        if (Input.GetKeyDown(KeyCode.E))
            rotate();
        if (Input.GetKeyDown(KeyCode.Space))
            release();


        //spawn animal
        if (!haveAnimal && timesUp) 
        {
            haveAnimal = true;
            timesUp = false;
            int index = Random.Range(0, animals.Length);
            currentAnimal = Instantiate(animals[index]);
            currentAnimal.transform.position = transform.position;
            turnCount = 0;
        }

        if(!haveAnimal)
        {
            countTime += Time.deltaTime;
            if(countTime > coolDown)
            {
                timesUp = true;
                countTime = 0.0f;
            }
        }

       
      
    }


    public void moveLeft()
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
    public void moveRight()
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

    public void rotate()
    {        
        turnCount -= 1;
        float zAngle = (360.0f / turns) * turnCount;
        //Debug.Log("zAngle: " + zAngle);
        Vector3 animalRot = new Vector3(0.0f, 0.0f, zAngle);
        if (haveAnimal)
        {
            currentAnimal.transform.eulerAngles =
                animalRot;
        }
    }

    public void rotateCCW()
    {
        turnCount += 1;
        float zAngle = (360.0f / turns) * turnCount;
        //Debug.Log("zAngle: " + zAngle);
        Vector3 animalRot = new Vector3(0.0f, 0.0f, zAngle);
        if (haveAnimal)
        {
            currentAnimal.transform.eulerAngles =
                animalRot;
        }
    }

    public void release()
    {
        if (haveAnimal)
        {
            currentAnimal.GetComponent<Rigidbody2D>().gravityScale =
                gravity;
            haveAnimal = false;
            SE.Play();
            
        }
    }




}

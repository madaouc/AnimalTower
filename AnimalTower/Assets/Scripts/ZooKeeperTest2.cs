using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZooKeeperTest2 : MonoBehaviour
{
    public GameObject [] animals;
    GameObject currentAnimal;

    public float spawnYOffset = 2.0f;
    public float zooUpStep = 0.5f;
    float targetY;  //spawn point move to Y + offset
    public float stableWaitTime = 0.5f;
    float stableCount = 0.0f;

    [Header("Animals Movement")]
    public float movement = 0.5f;
    public int turns = 8;
    int turnCount = 0;
    public float gravity = 0.5f;

    bool haveAnimal = false;
    bool letGo = false;

    AudioSource soundFx;
    [Header("SFX")]
    public AudioClip clipLetGo, clipGameOver;
    
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        soundFx = GetComponent<AudioSource>();
        targetY = 0.0f + spawnYOffset;
        transform.position = new Vector3(0.0f, targetY, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

        if (currentAnimal == null)
            haveAnimal = false;


        if(!haveAnimal )
        {
            Vector3 zooPos = transform.position;
            if (transform.position.y < targetY)
            {
                //move Upward
                zooPos.y = Mathf.MoveTowards(zooPos.y, targetY, zooUpStep * Time.deltaTime);
                //zooPos.x = Mathf.MoveTowards(zooPos.x, 0.0f, zooUpStep * Time.deltaTime);
                zooPos.x = 0.0f;
                transform.position = zooPos;
            }
            else
            {
                //spawn Animal
                haveAnimal = true;
                letGo = false;
                turnCount = 0;
                int index = Random.Range(0, animals.Length);    //random animal
                currentAnimal = Instantiate(animals[index]);
                currentAnimal.transform.position = transform.position;

            }
        }

       

        //if (Input.GetKeyDown(KeyCode.Space) && haveAnimal == true)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            releaseAnimal();
        }

        // check is animals stable
        if(haveAnimal)
        {
            bool landed;
            landed = currentAnimal.GetComponent<AniLanding>().landed;

            if(landed)
            {
                float animalVelocitySqr;
                animalVelocitySqr = currentAnimal.GetComponent<Rigidbody2D>().velocity.sqrMagnitude;
                if (animalVelocitySqr < 0.01f)
                {
                    stableCount += Time.deltaTime;
                    if (stableCount > stableWaitTime)
                    {
                        haveAnimal = false;
                        targetY = findTopY() + spawnYOffset;
                        stableCount = 0.0f;
                    }

                }
                else
                    stableCount = 0.0f;

            }

        }
       

    //zoo Move
        if (Input.GetKeyDown(KeyCode.A))
            move(-1);
        if (Input.GetKeyDown(KeyCode.D))
            move(1);


        //animal Rotation
        if (Input.GetKeyDown(KeyCode.E))
            rotate();   //clockwise    
        else if(Input.GetKeyDown(KeyCode.Q))
            rotate(1);  //counter clockwise
   
    }

    public void move(int dir)
    {
        if (letGo)
            return;

        //dir: -1, left; 1, right
        Vector3 zooPos = transform.position;
        zooPos.x = zooPos.x + movement * dir;    
        transform.position = zooPos;

        if (haveAnimal)
        {
            currentAnimal.transform.position = transform.position;
        }
    }

    public void rotate(int dir = -1)
    {
        if (letGo)
            return;

        //dir: -1, clockwise
        turnCount += dir;
      
        float zAngle = (360.0f / turns) * turnCount;
        //Debug.Log("zAngle: " + zAngle);

        Vector3 animalRot = new Vector3(0.0f, 0.0f, zAngle);
        if (haveAnimal)
        {
            currentAnimal.transform.eulerAngles = animalRot;
        }        
        

    }

    public void releaseAnimal()
    {
        if(haveAnimal)
        {
            currentAnimal.GetComponent<Rigidbody2D>().gravityScale =
                    gravity;
            letGo = true;
            //soundFx.clip = clipLetGo;
            soundFx.Play();
        }
    }

    float findTopY()
    {
        GameObject[] droppedAnimals;
        droppedAnimals = GameObject.FindGameObjectsWithTag("Animals");
        float topY = 0.0f;
        if (droppedAnimals.Length != 0)
        {
            foreach(GameObject animal in droppedAnimals)
            {
                float animalY = animal.transform.position.y;
                if (animalY > topY)
                    topY = animalY;
            }
        }
        return topY;
    }

}

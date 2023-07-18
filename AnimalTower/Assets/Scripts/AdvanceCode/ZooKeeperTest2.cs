using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZooKeeperTest2 : MonoBehaviour
{
    public GameObject [] animals;
    GameObject currentAnimal;

    [Header("Zoo Movement")]
    public float movement = 0.5f;
    public int turns = 8;
    int turnCount = 0;
    public float gravity = 0.5f;

    bool haveAnimal = false;
    bool letGo = false;

    bool gameOverFlag = false;


    AudioSource soundFx;
    [Header("SFX")]
    public AudioClip clipLetGo, clipGameOver;
    
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        soundFx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverFlag)
            return;


        //spawn animal
        if (!haveAnimal)
        {
            haveAnimal = true;
            letGo = false;
            turnCount = 0;

            int index = Random.Range(0, animals.Length);
            currentAnimal = Instantiate(animals[index]);
            currentAnimal.transform.position = transform.position;
        }
    

        //if (Input.GetKeyDown(KeyCode.Space) && haveAnimal == true)
        if (Input.GetKeyDown(KeyCode.Space) && haveAnimal)
        {
            currentAnimal.GetComponent<Rigidbody2D>().gravityScale =
                gravity;
            letGo = true;
            soundFx.clip = clipLetGo;
            soundFx.Play();
        }

        if(haveAnimal)
        {
            if (currentAnimal == null)
            {
                Debug.Log("GameOver");
                gameOverFlag = true;
                GetComponent<SpriteRenderer>().enabled = false;
                haveAnimal = false;
                letGo = false;

                soundFx.clip = clipGameOver;
                soundFx.Play();
                return;
            }

            bool landed;
            landed = currentAnimal.GetComponent<AniLanding>().landed;

            float animalVelocitySqr;
            animalVelocitySqr = currentAnimal.GetComponent<Rigidbody2D>().velocity.sqrMagnitude;

            if (landed && animalVelocitySqr < 0.01f)
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
            rotate();   //clockwise    
        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            rotate(1);  //counter clockwise
        }

        
    }

    public void move(int dir)
    {
        if (letGo)
            return;

        //dir: -1, left; 1, right
        Vector3 zooPos = transform.position;
        zooPos.x = zooPos.x + movement * Time.deltaTime * dir;    
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
            currentAnimal.transform.eulerAngles =
                animalRot;
        }
    }


}

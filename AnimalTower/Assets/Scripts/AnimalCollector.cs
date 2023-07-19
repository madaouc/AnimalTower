using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCollector : MonoBehaviour
{
    AudioSource SE;

    // Start is called before the first frame update
    void Start()
    {
        SE = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isAnimal = false;
        isAnimal = collision.gameObject.CompareTag("Animals");
        if(isAnimal)
        {
            Debug.Log("GameOver");
            Destroy(collision.gameObject);
            SE.Play();
        }
    }


}

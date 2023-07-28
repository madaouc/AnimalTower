using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniLanding : MonoBehaviour
{
    public bool landed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Animals"))
            landed = true;
        if (collision.gameObject.CompareTag("Ground"))
            landed = true;
    }

}

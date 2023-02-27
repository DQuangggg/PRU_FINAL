using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlockTrap : MonoBehaviour
{
    new Rigidbody2D rb;
    bool fly = false;


    void OnTriggerEnter2D(Collider2D collision)
    {
        rb = GetComponent<Rigidbody2D>();
        if (!fly)
        {
            if (collision.gameObject.tag == "Player")
            {
                rb.isKinematic = false;
                rb.gravityScale = -5f;
                fly = true;
            }
        }
    }

    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

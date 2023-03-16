using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    new Rigidbody2D rb;
    bool fall = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        rb = GetComponent<Rigidbody2D>();
        if (!fall)
        {
            if (collision.gameObject.tag == "Player")
            {
                rb.isKinematic = false;
                rb.gravityScale = 2f;
                rb.mass = 4;
                fall = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Trap")
        {
            gameObject.tag = "Trap";
        }
    }
}

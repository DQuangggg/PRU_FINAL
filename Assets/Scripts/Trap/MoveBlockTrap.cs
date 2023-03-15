using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlockTrap : MonoBehaviour
{
    new Rigidbody2D rb;
    bool fly = false;
    public float gravity;

    private GameObject moveBlockPrefab;
    private Vector3 blockPosition;

    void Start() {
        blockPosition = transform.position;
        moveBlockPrefab = (GameObject)Resources.Load(@"Prefabs\FallTrap");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        rb = GetComponent<Rigidbody2D>();
        if (!fly)
        {
            if (collision.gameObject.tag == "Player")
            {
                rb.isKinematic = false;
                rb.gravityScale = gravity;
                fly = true;
            }
        }
        else {
            if (collision.gameObject.tag == "Trap")
            {
                gameObject.SetActive(false);
                Invoke("LoadResource",2f);
            }
        }
    }

    void LoadResource() {
        GameObject newObject =Instantiate(moveBlockPrefab, blockPosition, Quaternion.identity);
        Destroy(gameObject);
        newObject.SetActive(true); 
    }


}

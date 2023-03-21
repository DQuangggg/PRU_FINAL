using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Transform curentPoint;
    public GameObject ladder1;
    public GameObject ladder2;
    private bool allowFloow = false;
    public Transform target;
    public float speed;
    public float stopDistance = 2f;
    private bool isKilled;
    private bool lookRight;

    public Transform initialPosition;

    private int currentPoint = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        curentPoint = point2.transform;

    }


    public void ResetPosition()
    {
        transform.position = initialPosition.position;
        isKilled = false;
    }
    void Update()
    {

        if (target.GetComponent<CharacterController>().GetIsRefresh())
        {

        }

        if (target.transform.position.y <= -8f)
        {
            speed = 9f;
            //transform.LookAt(target);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if(target.position.x > transform.position.x )
            {
                sr.flipX = true;
            } else
            {
                sr.flipX = false;
            }

        }
        else
        {
            Vector2 point = curentPoint.position - transform.position;
            speed = 2f;
            if (curentPoint == point2.transform)
            {
                sr.flipX = true;
                rb.velocity = new Vector2(speed, 0);
            }
            else
            {
                sr.flipX = false;
                rb.velocity = new Vector2(-speed, 0);
            }
            if (Vector2.Distance(transform.position, curentPoint.position) < 0.5f && curentPoint == point2.transform)
            {
                curentPoint = point1.transform;
                currentPoint = 0;
            }
            if (Vector2.Distance(transform.position, curentPoint.position) < 0.5f && curentPoint == point1.transform)
            {
                curentPoint = point2.transform;
                currentPoint = 1;
            }

            Debug.Log("Vector2.Distance(transform.position, target.position):" + Vector2.Distance(transform.position, target.position));


        }
        if (isKilled)
        {
            gameObject.SetActive(false);
            ladder1.gameObject.SetActive(true);
            ladder2.gameObject.SetActive(true);
        }
        else
        {
            ladder1.gameObject.SetActive(false);
            ladder2.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CircleKillBoss"))
        {
            isKilled = true;
        }
        else
        {
            isKilled = false;
        }
    }

    private void Awake()
    {
        ladder1.gameObject.SetActive(false);
        ladder2.gameObject.SetActive(false);
    }

    public void SetFollow()
    {
        allowFloow = true;
        isKilled = false;
    }
}

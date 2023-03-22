using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed ;
    [SerializeField] private float jump ;
    public GameObject BloodEffect;
    float horizontalMove;
    bool facingRight;
    bool grounded;
    Animator animator;
    Rigidbody2D rb;

    public AudioSource audioSource;
    [Header("SoundFX")]
    [SerializeField]
    public AudioClip jumpClip;
    [SerializeField]
    public AudioClip deathClip;
    [SerializeField]
    public AudioClip gameOverClip;

    SpawPoint spawPoint;
    SpawPoint spawPoint1;

    public int hearts = 5;
    public int currentHearts;


    public GameObject pauseMenuScreen;
    public UnityEngine.UI.Slider volumeSlider;
    public AudioMixer mixer;
    private float value;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        facingRight = true;
        audioSource = gameObject.GetComponent<AudioSource>();
        
        spawPoint = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<SpawPoint>();
        spawPoint1 = GameObject.FindGameObjectWithTag("SpawnPoint1").GetComponent<SpawPoint>();
        currentHearts = hearts;
    }

    void FixedUpdate()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);


        if (horizontalMove > 0 && !facingRight)
        {
            flip();
        }
        else if (horizontalMove < 0 && facingRight)
        {
            flip();
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            if (grounded)
            {
                animator.SetBool("jump", true);
                grounded = false;
                audioSource.PlayOneShot(jumpClip);
                rb.velocity = new Vector2(rb.velocity.x, jump);
            }
        }
        else
        {
            animator.SetBool("jump", false);
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Hazard")
        {
            grounded = true;

        }
        if (collision.gameObject.tag == "Trap")
        {
            animator.SetBool("dead", true);
            Instantiate(BloodEffect, transform.position, transform.rotation);
            audioSource.PlayOneShot(deathClip);
            StartCoroutine(waiter());
        }  

        IEnumerator waiter()
        {
            //stop all movement on main character
            rb.bodyType = RigidbodyType2D.Static;
            yield return new WaitForSeconds(0.5f);
            hearts--;
            currentHearts = hearts; 
            if (hearts <= 0)
            {
                audioSource.PlayOneShot(gameOverClip);
                //Cho nay cho Mai 
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                animator.SetBool("dead", false);
                if (transform.position.x >= spawPoint1.transform.position.x)
                {
                    transform.position = new Vector3(spawPoint1.transform.position.x, spawPoint1.transform.position.y, 0);
                }
                else
                {
                    transform.position = new Vector3(spawPoint.transform.position.x, spawPoint.transform.position.y, 0);
                }
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }

    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void SetMusic()
    {
        mixer.SetFloat("music", volumeSlider.value);
    }

    /* public void SetSound()
     {
         soundMixer.SetFloat("volumeSound", soundSlider.value);
     }*/
}

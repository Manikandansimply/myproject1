using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public int score;
    public int health = 100;
    public int jumpforce;
    public bool isJumping;
    private new Rigidbody2D rigidbody;
    public Text scoreText;
    public Text healthText;
    public Text gameOverUI;
    public AudioSource coinSound;
    public AudioSource jumpSound;
    public AudioSource damageSound;
    //public Camera camera; 
    void Start()
    {
        health = 100;
        rigidbody = GetComponent<Rigidbody2D>();
        scoreText.text = "Score  " + score.ToString();
        healthText.text = "Health " + health.ToString();

    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            jumpSound.Play();
            isJumping = true;
            jump();

        }

    }

    void jump()
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpforce);
    }


    void OnCollisionEnter2D(Collision2D colloider)
    {
        if (colloider.gameObject.tag == "coin")
        {
            score++;
            coinSound.Play();
            scoreText.text = "Score " + score.ToString();
            Destroy(colloider.gameObject);
        }
        else if (colloider.gameObject.tag == "spike")
        {
            health -= 25;
            damageSound.Play();
            healthText.text = "Health " + health.ToString();
            if (health == 0)
            {
                this.gameObject.SetActive(false);
                //camera.enabled = true;
                gameOverUI.gameObject.SetActive(true);
            }
        }
        if (colloider.gameObject.tag == "Floor")
        {
            isJumping = false;
        }


    }

}

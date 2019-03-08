using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int score;
    private int lives;
    private bool facingRight;


    public float speed;
    public float jumpForce;
    public Text winText;
    public Text scoreText;
    public Text livesText;
    public Text loseText;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;
    Animator anim;
   

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        score = 0;
        SetScoreText();
        winText.text = "";
        lives = 3;
        loseText.text = "";
        musicSource.clip = musicClipOne;
        musicSource.Play();
        musicSource.loop=true;
        facingRight = true;
    }

  

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(force: movement * speed);
        if (Input.GetKey("escape"))
            Application.Quit();

        if (facingRight == false&&moveHorizontal>0)
        {
            Flip(moveHorizontal);
        }
        else if(facingRight==true&&moveHorizontal<0)
        {
            Flip(moveHorizontal);
        }
        
    }

 
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "Ground")
        { if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    anim.SetInteger("State", 2);
                }
                else
                {
                    anim.SetInteger("State", 0);
                }
            }
        }
             
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetInteger("State", 1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetInteger("State", 1);
            
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetInteger("State", 0);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetInteger("State", 0);
        }
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            SetScoreText();
        }
        if (score == 4)
        {
            transform.position = new Vector3(36.0f, 0.0f, 0.0f);
            lives = 3;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();
        }
    }

    void SetScoreText()

    {
        if (score >= 8)
        {
            musicSource.clip = musicClipOne;
            musicSource.Stop();
        }
        scoreText.text = "Score: " + score.ToString();
        if (score >= 8)
        {
            winText.text = "You Win!";
            
            musicSource.clip = musicClipTwo;
            musicSource.Play();

        }
       

    }
    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            loseText.text = "You Lose!";
            Destroy(this);
           
        }
       
    }
    void Flip(float moveHorizontal)
    {
        if(moveHorizontal > 0 && !facingRight || moveHorizontal <0 && facingRight)
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
     
}

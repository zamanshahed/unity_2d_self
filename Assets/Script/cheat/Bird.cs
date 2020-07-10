using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bird : MonoBehaviour {

    Rigidbody2D rb;
    SpriteRenderer sp;
    Animator anim;
    public Animator parentBirdAnim;

    public float speed;
    public Sprite birdDead;
     
    public Score score;
    public GameManager gameManager;
    public ObstacleSpawner obstacleSpawner;

    int angle;
    int maxAngle = 20;
    int minAngle = -90;

    bool touchGround;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb.gravityScale = 0;        
    }
	
	// Update is called once per frame
	void Update () {
            if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false && GameManager.gamePaused == false)
            {
                if (GameManager.gameStarted == false)
                {
                    parentBirdAnim.enabled = false;
                    rb.gravityScale = 0.8f;
                    Flap();
                    obstacleSpawner.InstantiateObstacles();
                    gameManager.GameHasStarted();
                }
                else
                {
                    Flap();
                }

        }
        
        BirdRotation();      
	}

    void Flap()
    {
        rb.velocity = Vector2.zero;
        //Jump
        rb.velocity = new Vector2(rb.velocity.x, speed);
    }

    void BirdRotation()
    {
        if (rb.velocity.y > 0)
        {
            rb.gravityScale = 0.8f;
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = 0.6f;

            if (rb.velocity.y < -1.3f)
            {
                if (angle >= minAngle)
                {
                    angle = angle - 3;
                }
            }
        }

        if (touchGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles")) {
            score.Scored();
            Debug.Log("Scored");
        }
        else if(collision.CompareTag("Pipe"))
        {
            //game over
            gameManager.GameOver();
            GameOverBird();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver == false)
            {
                //game over
                gameManager.GameOver();
                GameOverBird();
            }
            else
            {
                //something..
                GameOverBird();
            }
        }        
    }
    public void GameOverBird()
    {
        touchGround = true;
        sp.sprite = birdDead;
        anim.enabled = false;
        transform.rotation = Quaternion.Euler(0, 0, -90f);
    }
}

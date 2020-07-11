using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public GameManager gameManager;
    public Score score;

    public Animator wheelAnim;
    public GameObject coin;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Tap Detected!");
            rb.gravityScale = 0.8f;
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.zero;
        //Jump
        rb.velocity = new Vector2(rb.velocity.x, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Coin Scored !!");
            score.Scored();
            Destroy(collision.gameObject);
        }
    }
        
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //Debug.Log("Obstacle Collsion ... !!");
            if (GameManager.gameOver == false)
            {
                //game over
                gameManager.GameOver();
                //Debug.Log("Obstacle Collsion ... !!");
            }
            else
            {
                //something..
            }
        }
    }



}

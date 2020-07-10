using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public Animator wheelAnim;
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
}

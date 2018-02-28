using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int startVelocity;
    public float movementStrength;
    public float acceleration;
    public int maximumVelocity;

    //Current score
    private int score;
    //The acceleration to be applied to the player.
    private float acc;
    //The current velocity of the player going to the right.
    private float velocity;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        this.acc = acceleration / 1000;
        this.velocity = this.startVelocity;
        this.rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(velocity,0);
        rb.gravityScale = 0;
        this.score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        float x = 0;
        if (Input.GetKey("up"))
            x = - movementStrength;
        else if (Input.GetKey("down"))
            x = movementStrength;

        rb.AddForce(new Vector2(0, x));
        //rb.velocity = new Vector2(x, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            this.score++;
            collision.gameObject.SetActive(false);
        }
    }
}
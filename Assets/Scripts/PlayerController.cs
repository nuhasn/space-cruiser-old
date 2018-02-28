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
    //The acceleration to be applied to the falling player.
    private float acc;
    //The current velocity of the player falling downwards.
    private float velocity;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        this.acc = acceleration / 1000;
        this.velocity = this.startVelocity;
        this.rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(velocity, 0);
        this.score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (velocity < maximumVelocity)
            velocity = velocity + acc;

        rb.velocity = new Vector2(velocity, rb.velocity.y);
        float x = 0;
        if (Input.GetKey("up"))
            transform.position = new Vector2(this.transform.position.x, this.transform.position.y + movementStrength / 100);
        else if (Input.GetKey("down"))
            transform.position = new Vector2(this.transform.position.x, this.transform.position.y - movementStrength / 100);
        else if (Input.GetKey("left"))
            transform.position = new Vector2(this.transform.position.x - movementStrength / 100, this.transform.position.y);
        else if (Input.GetKey("right"))
            transform.position = new Vector2(this.transform.position.x + movementStrength / 100, this.transform.position.y);
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
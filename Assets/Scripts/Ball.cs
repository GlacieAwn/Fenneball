using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeedX = 6;
    public float ballSpeedY = -8;
    public float ballMaxSpeed = 6;
    public float ballSpeedModifier = 0.05f;

    public float timer = 0;

    private int polarity;
    private int resetTime = 5000;

    public ScoreManager scoreManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = resetTime * Time.deltaTime;
        polarity = Random.Range((int)1, (int)-1);
        // set polarity to -1 if it's equal to 0 in this round
        if(polarity <= 0)
        {
            polarity = -1;
        }


        ballSpeedX = polarity * ballMaxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= 1;
        if(timer < 0)
        {
            transform.Translate((float)ballSpeedX * Time.deltaTime, (float)ballSpeedY * Time.deltaTime, 0);

            if(ballSpeedX >= 6)
            {
                ballSpeedX += ballSpeedModifier * Time.deltaTime;
            }
            else if(ballSpeedX <= -6)
            {
                ballSpeedX -= ballSpeedModifier * Time.deltaTime;
            }
        }

        if(transform.position.y >= 4.28)
        {
            ballSpeedY = -ballSpeedY;
        }
        else if(transform.position.y <= -4.28)
        {
            ballSpeedY = -ballSpeedY;
        }
        

    }

    void ResetBall()
    {
        timer = resetTime * Time.deltaTime;
        transform.position = new Vector2(0, 0);
        ballSpeedX = ballMaxSpeed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftPaddle"))
        {
            ballSpeedX = -ballSpeedX;
        }
        else if (collision.gameObject.CompareTag("RightPaddle"))
        {
            ballSpeedX = -ballSpeedX;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // check for collision between the left and right score barriers
        if (collision.gameObject.CompareTag("Barrier") && ballSpeedX >= 6)
        {
            scoreManager.rightScore += 1;
            ResetBall();
        }
        else if(collision.gameObject.CompareTag("Barrier") && ballSpeedX <= 6)
        {
            scoreManager.leftScore += 1;
            ResetBall();
        }
    }
}


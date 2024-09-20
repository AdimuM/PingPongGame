using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Difficulty { Easy, Medium, Hard }

public class AIPaddleController : MonoBehaviour
{
    public Transform ball;
    public float easySpeed = 3f;
    public float mediumSpeed = 5f;
    public float hardSpeed = 7f;
    public float easyReactionTime = 1f;
    public float mediumReactionTime = 0.5f;
    public float hardReactionTime = 0.2f;
    public Difficulty difficulty = Difficulty.Medium;

    private Rigidbody2D rb;
    private float nextActionTime = 0f;
    private float speed;
    private float reactionTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetDifficulty(difficulty);
    }

    void Update()
    {
        if (Time.time >= nextActionTime)
        {
            nextActionTime = Time.time + reactionTime;
            MovePaddle();
        }
    }

    void MovePaddle()
    {
        if (ball.position.y > transform.position.y)
        {
            rb.velocity = new Vector2(0, speed);
        }
        else if (ball.position.y < transform.position.y)
        {
            rb.velocity = new Vector2(0, -speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void SetDifficulty(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                speed = easySpeed;
                reactionTime = easyReactionTime;
                break;
            case Difficulty.Medium:
                speed = mediumSpeed;
                reactionTime = mediumReactionTime;
                break;
            case Difficulty.Hard:
                speed = hardSpeed;
                reactionTime = hardReactionTime;
                break;
        }
    }
}

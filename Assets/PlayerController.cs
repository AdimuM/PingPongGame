using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public bool isPlayerA = false;
    public GameObject circle;
    public GameObject collisionEffectPrefab; // Add this line

    private Rigidbody2D rb;
    private Vector2 playerMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (isPlayerA)
        {
            // Apply the customizable paddle size and speed only to PaddleA
            transform.localScale = new Vector3(transform.localScale.x, GameSettings.paddleSize, transform.localScale.z);
            speed = GameSettings.paddleSpeed;
        }
    }

    void Update()
    {
        if (isPlayerA)
        {
            PaddleAController();
        }
        else
        {
            PaddleBController();
        }
    }

    private void PaddleBController()
    {
        if (circle.transform.position.y > transform.position.y + 0.5f)
        {
            playerMovement = new Vector2(0, 1);
        }
        else if (circle.transform.position.y < transform.position.y - 0.5f)
        {
            playerMovement = new Vector2(0, -1);
        }
        else
        {
            playerMovement = new Vector2(0, 0);
        }
    }

    private void PaddleAController()
    {
        playerMovement = new Vector2(0, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        rb.velocity = playerMovement * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Instantiate(collisionEffectPrefab, collision.contacts[0].point, Quaternion.identity);
        }
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     public float speed = 10f;
//     public string inputAxis = "Vertical";
//     public bool reverseControls = false;

//     private Rigidbody2D rb;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         transform.localScale = new Vector3(transform.localScale.x, GameSettings.paddleSize, transform.localScale.z);
//     }

//     void Update()
//     {
//         float move = Input.GetAxis(inputAxis) * speed * Time.deltaTime;
//         if (reverseControls)
//         {
//             move = -move;
//         }
//         rb.velocity = new Vector2(0, move);
//     }
// }

// transform.localScale = new Vector3(transform.localScale.x, 
//             GameSettings.paddleSize, transform.localScale.z);

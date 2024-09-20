using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallController : MonoBehaviour
{
    public float initialSpeed = 10f;
    public float speedIncrease = 0.2f;
    public Text playerText;
    public Text opponentText;

    private int hitCounter;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        Invoke("StartBall",2f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, initialSpeed
            + (speedIncrease * hitCounter));
    }

    private void StartBall(){
        rb.velocity = new Vector2(-1, 0) * (GameSettings.ballSpeed + 0.2f * hitCounter);
    }
    private void RestartBall(){
        Debug.Log("RestartBall called");
        rb.velocity = new Vector2(0,0);
        transform.position = new Vector2(0,0);
        hitCounter = 0;
        Invoke("StartBall",2f);
    }
    private void PlayerBounce(Transform obj){
        hitCounter++;
        Vector2 ballPosition = transform.position;
        Vector2 playerPosition = obj.position;

        float xDirection;
        float yDirection;

        if(transform.position.x > 0){
            xDirection = -1;
        }else{
            xDirection = 1;
        }

        yDirection = (ballPosition.y - playerPosition.y)/obj.GetComponent<Collider2D>().bounds.size.y;

        if(yDirection == 0){
            yDirection = 0.25f;
        }

        rb.velocity = new Vector2(xDirection, yDirection) * (GameSettings.ballSpeed + (0.2f * hitCounter));
    }

    private void OnCollisionEnter2D(Collision2D other){
        Debug.Log("OnCollisionEnter2D called with " + other.gameObject.name);
        if(other.gameObject.name == "PaddleA" || other.gameObject.name == "PaddleB"){
            PlayerBounce(other.transform);
        }else if (other.gameObject.CompareTag("wall3") || other.gameObject.CompareTag("wall4")){
            WallBounce();
        }
    
    }

    private void WallBounce()
    {
        Vector2 newVelocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        rb.velocity = newVelocity;
    }

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("OnTriggerEnter2D called with " + other.gameObject.name);

        if (other.CompareTag("BoundaryA") || other.CompareTag("BoundaryB")){
            if (transform.position.x > 0){
                Debug.Log("Ball crossed right boundary");
                RestartBall();
                opponentText.text = (int.Parse(opponentText.text) + 1).ToString();
            }
            else if (transform.position.x < 0){
                Debug.Log("Ball crossed left boundary");
                RestartBall();
                playerText.text = (int.Parse(playerText.text) + 1).ToString();
            }
        }
    }

}

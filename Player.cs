using System.Collections;
using UnityEngine;


public class Player : MonoBehaviour
{

    public float speed = 15f;
    public float mapWidth = 5f;
    private Rigidbody2D rb;

    
    private void Start()
    {
        //Caches the rigidbody of the Player
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Input.GetAxis returns a value between -1 and 1 
        //Use Time.fixedDeltaTime under FixedUpdate
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

        //Vector2.right is the same as the vector zero up and one over to the right
        Vector2 newPosition = rb.position + Vector2.right * x;

        //Mathf.Clamp clamps the given value between two floats
        //Makes sure the player does not go out of bounds
        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);

        //Moves the object to a certain position, checking for collisions along the way
        rb.MovePosition(newPosition);

    }

    //Callback function like Start and Update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Block(Clone)")
        {
            
            FindObjectOfType<GameManager>().EndGame();
        }
        
    }
}


/*
 
*/
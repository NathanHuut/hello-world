//Inside of Block game object

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private float fallSpeed = 1f;

    private void Start()
    {
        //Gradually increases the fall speed of blocks based on timeSinceLevelLoad
        fallSpeed += (Time.timeSinceLevelLoad / 20f);
        
        //Ensures that fallSpeed will never exceed 2
        fallSpeed = Mathf.Clamp(fallSpeed, 1f, 2f);
        
        GetComponent<Rigidbody2D>().gravityScale = fallSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -2f)
        {
            FindObjectOfType<Score>().AddScore();
            Destroy(gameObject);
            
        }
    }
}

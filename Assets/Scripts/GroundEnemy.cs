using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private float speed = 2.24f;
    private int frameRate = 30;
    private float rightBound;
    private float leftBound;
    private bool rightBoundFlag = false;
    private float collsionVelocity = 6.8f;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        Application.targetFrameRate = frameRate;
        rightBound = transform.position.x + 3;
        leftBound = transform.position.x - 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if(transform.position.x > rightBound)
        {
            rightBoundFlag = true;
        }

            if(transform.position.x < leftBound)
        {
            rightBoundFlag = false;
        }

            if(transform.position.x < rightBound && !rightBoundFlag)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        
        if(transform.position.x > leftBound && rightBoundFlag)
        {  
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        

    }

    private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("Player") && collision.relativeVelocity.magnitude > collsionVelocity)
            {
                Destroy(gameObject);
            }
        }
}

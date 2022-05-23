using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyMovement : MonoBehaviour
{
    private Rigidbody enemyRb;
    private float speed = 2.25f;
    private int frameRate = 30;
    private float topBound;
    private float bottomBound;
    private bool topBoundFlag = false;
    private float collsionVelocity = 6.8f;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        Application.targetFrameRate = frameRate;
        topBound = transform.position.y + 3;
        bottomBound = transform.position.y - 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if(transform.position.y > topBound)
        {
            topBoundFlag = true;
        }

            if(transform.position.y < bottomBound)
        {
            topBoundFlag = false;
        }

            if(transform.position.y < topBound && !topBoundFlag)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        
        if(transform.position.y > bottomBound && topBoundFlag)
        {  
            transform.Translate(Vector3.down * Time.deltaTime * speed);
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

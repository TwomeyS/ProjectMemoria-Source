using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableGround : MonoBehaviour
{
    private Rigidbody groundRb;
    private float collsionVelocity = 15.8f;

    // Start is called before the first frame update
    void Start()
    {
        groundRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("Player") && collision.relativeVelocity.magnitude > collsionVelocity)
            {
                Destroy(gameObject);
            }
        }
}

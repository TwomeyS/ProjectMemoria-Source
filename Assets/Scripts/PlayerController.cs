using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// INFINITE DASH BUG WHEN YOU GO OFF A LEDGE WITHOUT JUMPING
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 8f;
    private float turnSpeed = 55f;
    private float horizontalInput;
    private float forwardInput;
    public float jumpForce = 7.5f;
    public bool isOnGround = true;
    public bool boosted = false;
    private float speedUp = 11.5f;
    private float speedUpUP = 13f;
    public int frameRate = 60;
    public bool airFlag =false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Application.targetFrameRate = frameRate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if(isOnGround)
        {
            airFlag = false;
        }
            if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        }
        // get player input
        horizontalInput = Input.GetAxis("Vertical");
        forwardInput = Input.GetAxis("Horizontal");
        // Move the vehicle forward
		transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // 
        
        //Sean here, I made a small modification that allows boosting in both directions by creating two if staments and basing whether it uses vector3.right or
        //vector3.left off whether forwardInput is positive or negative at the time that the boost is being used 
        //Just tell me if you want to add an option for boosting while standing still
        
        //Also I fixed the position and rotation issues with boost by disabling rotation on every axis using the rigidbody component as well as the freezing the z position
        //on rigid body

        // I added in multi directional dashing, just changed the forward directions into a GetKey to add more directions, also changed controls to dash with left shift and jump with space
            if(Input.GetKeyDown(KeyCode.LeftShift) && boosted == false && Input.GetKey(KeyCode.RightArrow) && airFlag == false)
        {
            playerRb.velocity = new Vector3(1, 0, 0);
            playerRb.AddForce(Vector3.right * speedUp, ForceMode.Impulse);
            boosted = true;
            airFlag = true;
            playerRb.useGravity = false;
            StartCoroutine(MidAirStartGrav());
            StartCoroutine(BoostCooldown());
        }
            if(Input.GetKeyDown(KeyCode.LeftShift) && boosted == false && Input.GetKey(KeyCode.LeftArrow) && airFlag == false)
        {
            playerRb.velocity = new Vector3(1, 0, 0);
            playerRb.AddForce(Vector3.left * speedUp, ForceMode.Impulse);
            boosted = true;
            airFlag = true;
            playerRb.useGravity = false;
            StartCoroutine(MidAirStartGrav());
            StartCoroutine(BoostCooldown());
        } 
            if(Input.GetKeyDown(KeyCode.LeftShift) && boosted == false && Input.GetKey(KeyCode.UpArrow) && airFlag == false)
        {
            playerRb.velocity = new Vector3(1, 0, 0);
            playerRb.AddForce(Vector3.up * speedUpUP, ForceMode.Impulse);
            boosted = true;
            airFlag = true;
            playerRb.useGravity = false;
            StartCoroutine(MidAirStartGrav());
            StartCoroutine(BoostCooldown());
        } 
            if(Input.GetKeyDown(KeyCode.LeftShift) && boosted == false && Input.GetKey(KeyCode.DownArrow) && airFlag == false)
        {
            playerRb.velocity = new Vector3(1, 0, 0);
            playerRb.AddForce(Vector3.down * speedUp, ForceMode.Impulse);
            boosted = true;
            airFlag = true;
            playerRb.useGravity = false;
            StartCoroutine(MidAirStartGrav());
            StartCoroutine(BoostCooldown());
        } 
        // this one doesnt work yet, would have to be placed as an if statement and the other up and right keys would be elses, could be used for diagonal.
            if(Input.GetKeyDown(KeyCode.LeftShift) && boosted == false && Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow) && airFlag == false)
        {
            playerRb.velocity = new Vector3(1, 0, 0);
            playerRb.AddForce(new Vector3(.5f,0,.5f)* speedUp, ForceMode.Impulse);
            boosted = true;
            airFlag = true;
            playerRb.useGravity = false;
            StartCoroutine(MidAirStartGrav());
            StartCoroutine(BoostCooldown());
        }

    } 
     void Update()
     {
         if (boosted)
         {
            GameObject.Find("Player").GetComponent<Renderer>().material.color = new Color(0, 204, 102);
         }

     }           
    
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
            }
        }
        IEnumerator BoostCooldown()
    {
        yield return new WaitForSeconds(0.75f);
        boosted = false;
    }
        IEnumerator MidAirStartGrav()
    {
        yield return new WaitForSeconds(0.05f);
        playerRb.useGravity = true;
    }
}

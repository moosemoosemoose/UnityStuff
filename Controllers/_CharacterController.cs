using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CharacterController : MonoBehaviour
{
    private bool shakeStatus = false;

  
    private Rigidbody rb;
    private float horizontalInput, verticalInput;
    [HideInInspector]
    public Vector3 jump;
    public bool grounded = true;
    public bool jumpAvailable = true;
    [HideInInspector]
    public Vector3 originalPos;
    private moveSpeed = 2.0f;

    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody>();
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

    }


    void FixedUpdate()
    {
    
        scanForInput();
        movePlayer();

    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.R))
        {
            respawn();
        }
    }

    void scanForInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


    }

    void movePlayer()
    {
      
        if (Input.GetKey(KeyCode.W) && grounded && jumpAvailable || Input.GetKey(KeyCode.UpArrow) && grounded && jumpAvailable)
        {
            jumpy();
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            fallFast();
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.position += Vector3.left * Time.deltaTime * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.position += Vector3.right * Time.deltaTime * moveSpeed;
        }

           
        

    }

    void jumpy()
    {
        if (grounded)
        {
            grounded = false;
            jumpAvailable = true;
            Vector3 jump = new Vector3(horizontalInput, 6.66f, verticalInput);
            rb.AddForce(jump, ForceMode.Impulse);
        }

        if (!grounded && jumpAvailable)
        {
            jumpAvailable = false;
            rb.velocity = Vector3.zero;
            Vector3 jump = new Vector3(horizontalInput, 3.34f, verticalInput);
            rb.AddForce(jump, ForceMode.Impulse);
        }


    }

    void fallFast()
    {
        if (!grounded)
        {
            Vector3 fall = new Vector3(horizontalInput, -3.14f, verticalInput);
            rb.AddForce(fall, ForceMode.Impulse);
            shakeStatus = true;
        }
    }

    void respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        gameObject.transform.position = originalPos;
    }

    void OnCollisionStay()
    {
        grounded = true;
        jumpAvailable = true;
        shakeStatus = false;
    }

    

   


public bool getShakeStatus()
    {
        return shakeStatus;
    }
}

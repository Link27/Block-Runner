using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // This is a reference to the Rigidbody component called "rb"
    public Rigidbody rb;
    public Vector3 startingPoint;
    public GameObject player;
    public float forwardForce;
    public float sidewaysForce;
    public float upwardForce;
    public bool onGround;
    public bool jump;
    public bool rightForce;
    public bool leftForce;
    public int maxSpeedForward;
    public Text startingMessage;
    public Text level01;
    public bool startingLine;
    public bool finishLine;
    [SerializeField]
    private Transform finishLineObject;
    [SerializeField]
    private Text distanceText;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        rb.freezeRotation = true;
        startingPoint = new Vector3(0f, 5f, 0f);
        player.transform.position = startingPoint;
        forwardForce = 1500f;
        sidewaysForce = 1500f;
        upwardForce = 2200f;
        onGround = false;
        jump = false;
        rightForce = false;
        leftForce = false;
        rb.useGravity = false;
        startingLine = false;
        finishLine = false;
        maxSpeedForward = 20;
    }
    
    void FixedUpdate()
    {
        // Press the spacebar to start the game
        if(Input.GetKey("space"))
        {
            rb.useGravity = true; // Allows the cube to drop
            // Removes the on screen texts
            startingMessage.enabled = false;
            level01.enabled = false;
        }

        if (onGround == true) // If the player is on the ground, allow this...
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime); // Add a forward force when the object hits the ground

            if (Input.GetKey("d") && Input.GetKey("a") && (Input.GetKeyDown("space") || Input.GetKeyDown("w") || Input.GetKey("space") || Input.GetKey("w")) && rb.velocity.magnitude > maxSpeedForward - 2)
            {
                // If "d", "a", and spacebar or "w" is being pressed, set rightForce, leftForce, and jump to true
                rightForce = true;
                leftForce = true;
                jump = true;
            }
            else if (Input.GetKey("d") && Input.GetKey("a"))
            {
                // If both "d" and "a" are being pressed, set rightForce and leftForce to true
                rightForce = true;
                leftForce = true;
            }
            else if (Input.GetKey("d") && (Input.GetKeyDown("space") || Input.GetKeyDown("w") || Input.GetKey("space") || Input.GetKey("w"))  && rb.velocity.magnitude > maxSpeedForward - 2)
            {
                // If "d" and spacebar or "w" are being pressed, set rightForce and jump to true
                rightForce = true;
                jump = true;
            }
            else if (Input.GetKey("a") && (Input.GetKeyDown("space") || Input.GetKeyDown("w") || Input.GetKey("space") || Input.GetKey("w"))  && rb.velocity.magnitude > maxSpeedForward - 2)
            {
                // if "a" and spacebar or "w" are being pressed, set leftForce and jump to true
                leftForce = true;
                jump = true;
            }
            else if (Input.GetKey("d"))
            {
                rightForce = true; // If "d" is pressed, set rightForce to true to allow a right force to be applied
            }
            else if (Input.GetKey("a"))
            {
                leftForce = true; // If "a" is pressed, set leftForce to true to allow a left force to be applied
            }
            else if ((Input.GetKeyDown("space") || Input.GetKeyDown("w") || Input.GetKey("space") || Input.GetKey("w"))  && rb.velocity.magnitude > maxSpeedForward - 2)
            {
                jump = true; // If the spacebar or "w" is pressed, set jump to true to allow the player to jump
            }

            if (rightForce == true && leftForce == true && jump == true && rb.transform.position.y == 1)
            {
                rb.AddForce(0, upwardForce * 5 * Time.deltaTime, forwardForce * Time.deltaTime); // Apply a force upwards to the player
                FollowPlayerSound.PlaySound("jump");

            }
            else if (rightForce == true && leftForce == true && jump == false)
            {
                rb.AddForce(0, 0, forwardForce * Time.deltaTime); // If both left and right are pressed, apply no sideways force in any direction
            }
            else if (rightForce == true && leftForce == false && jump == true && rb.transform.position.y == 1)
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, upwardForce * 5 * Time.deltaTime, forwardForce * Time.deltaTime); // Apply a force upwards and rightward to the player
                FollowPlayerSound.PlaySound("jump");
            }
            else if (rightForce == false && leftForce == true && jump == true && rb.transform.position.y == 1)
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, upwardForce * 5 * Time.deltaTime, forwardForce * Time.deltaTime); // Apply a force upwards and leftward to the player
                FollowPlayerSound.PlaySound("jump");
            }
            else if (rightForce == true && leftForce == false && jump == false)
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, forwardForce * Time.deltaTime); // Apply a sideways rightward force to the player
            }
            else if (leftForce == true && leftForce == true && jump == false)
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, forwardForce * Time.deltaTime); // Apply a sideways leftward force to the player
            }
            else if (jump == true && rightForce == false && leftForce == false && rb.transform.position.y == 1)
            {
                rb.AddForce(0, upwardForce * 5 * Time.deltaTime, forwardForce * Time.deltaTime); // Apply a force upwards to the player
                FollowPlayerSound.PlaySound("jump");
            }

            rightForce = false; // No longer pressing "d"
            leftForce = false; // No longer pressing "a"
            jump = false; // No longer pressing spacebar or "w"
        }

        // if the player falls off the map and reaches -5 on the y-axis, reset their position back to the start
        if (player.transform.position.y <= -8)
        {
            onGround = false;
            rightForce = false;
            leftForce = false;
            jump = false;
            rb.freezeRotation = true;
            rb.useGravity = false;
            startingLine = false;
            distanceText.text = "171.0 m";
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.transform.rotation = Quaternion.identity;
            player.transform.position = startingPoint;
        }

        // If the player falls off the ground, allow for the cube to rotate but disable left and right movements
        if (player.transform.position.x >= 8f)
        {
            rb.freezeRotation = false;
            rb.transform.Rotate(1f, 0f, -1f);
            onGround = false;
        }
        else if (player.transform.position.x <= -8f)
        {
            rb.freezeRotation = false;
            rb.transform.Rotate(1f, 0f, 1f);
            onGround = false;
        }

        if (rb.velocity.magnitude > maxSpeedForward)
        {
            rb.velocity = rb.velocity.normalized * maxSpeedForward; // Sets the max speed of the player to roughly 20
        }

        // Once the character has a position of 9+ on the z-axis, we know that they have crossed over the starting line
        if (rb.transform.position.z >= 9)
        {
            startingLine = true;
        }

        if (startingLine == true)
        {
            // This will count down the distance from the starting line to the finish line and display it on screen for the user to see
            distance = (finishLineObject.transform.position - transform.position).magnitude - 1;
            distanceText.text = distance.ToString("F1") + " m";
            
            if (rb.transform.position.z > 180 && rb.transform.position.x < 8 && rb.transform.position.x > -8)
            {
                // You have crossed the finish line
                finishLine = true;
            }
        }

        if (finishLine == true)
        {
            // Disable all forces to stay on platform and then create finished message with a continue button
            onGround = false;
            jump = false;
            rightForce = false;
            leftForce = false;
            distanceText.text = "0.0 m";
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Obstacle")
        {
            // When player collides against object, stops all movement and resets position back to the beginning
            FollowPlayerSound.PlaySound("crash");
            onGround = false;
            jump = false;
            rightForce = false;
            leftForce = false;
            rb.useGravity = false;
            startingLine = false;
            distanceText.text = "171.0 m";
            player.transform.position = startingPoint;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        else if(collisionInfo.collider.tag == "Ground")
        {
            onGround = true; // Lets game know that the player has started and landed on the ground to begin movement
        }
    }
}

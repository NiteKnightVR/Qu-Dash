using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	private float speed = 8f;            // The speed that the player will move at.		
	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    bool dash = false;

    void Awake ()
	{			
		// Set up references.
		playerRigidbody = GetComponent <Rigidbody> ();
	}
		
		
	void FixedUpdate ()
	{
		// Store the input axes.
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            dash = true;
            Debug.Log("dashing");
        }
        else
        {
            dash = false;
            Debug.Log("walk");
        }

        if (Input.GetKey("space"))
        {
            Time.timeScale = .2f;
            Debug.Log("slow");
        }
        else
            Time.timeScale = 1.0f;

        // Move the player around the scene.
        Move (h, v, dash);
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            GM.instance.Die();           
        }
    }

	void Move (float h, float v, bool sprint)
	{
        if (!sprint)
        {
            // Set the movement vector based on the axis input.
            movement.Set(h, v, 0f);

            // Normalise the movement vector and make it proportional to the speed per second.
            movement = movement.normalized * speed * Time.deltaTime;

            // Move the player to it's current position plus the movement.
            playerRigidbody.MovePosition(transform.position + movement);
        }
        else
        {
            movement.Set(h, v, 0f);

            // Normalise the movement vector and make it proportional to the speed per second.
            movement = movement.normalized * 15 * Time.deltaTime;

            // Move the player to it's current position plus the movement.
            playerRigidbody.MovePosition(transform.position + movement);
        }
	}
}


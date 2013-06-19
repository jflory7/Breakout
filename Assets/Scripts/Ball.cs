using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
	// Holds information about the game state.
	public GameState state;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Check to see if the speed is within the correct range.
		CheckSpeed ();
		
		// Check to see if the ball should be served.
		CheckServe ();
	}
	
	// Check the speed of the ball.
	private void CheckSpeed ()
	{
		// Store the direction the ball is traveling.
		float ballDirection = Mathf.Sign (rigidbody.velocity.y);
		
		// If the ball is traveling faster than the maximum velocity...
		if (Mathf.Abs (rigidbody.velocity.y) > 30)
		{
			// ...set the ball to the maximum velocity.
			rigidbody.velocity = new Vector3 (rigidbody.velocity.x, 30, 0);
		}
		
		Debug.Log (rigidbody.velocity.y);
	}
	
	// Check to see if the ball should be served.
	private void CheckServe ()
	{
		// Check to see if the ball is out of play...
		if (state.CurrentState != GameState.State.Play)
		{
			// Check to see if the user has served the ball...
			if (Input.GetButton ("Serve"))
			{
				// Call the serve method.
				Serve ();
			}
		}
	}
	
	// Serves the ball.
	private void Serve ()
	{
		// Update the current state.
		state.CurrentState = GameState.State.Play;
		
		// Set the ball in motion!
		rigidbody.AddForce (Random.Range (-200, 200), -750, 0);
	}
	
	//
	private float CalculateForce (float playerPosition)
	{
		return (transform.position.x - playerPosition) * 750;
	}
	
	// When a collision occurs...
	void OnCollisionEnter (Collision collision)
	{
		// ...check to see if the ball has collided with a block.
		if (collision.transform.parent)
		{
			Destroy (collision.gameObject);
		}

		// Check to see if the ball has collided with the player.
		Player player = collision.gameObject.GetComponent<Player>();
		{
			// Check to see if player exists...
			if (player !=null)
			{
				// ...if so, add force to the ball in the direction that the player's paddle is moving.
				rigidbody.AddForce (CalculateForce (player.transform.position.x), 0, 0);
			}
		}		
	}
}

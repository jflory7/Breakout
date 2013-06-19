using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// If the left input is pressed...
		if (Input.GetButton ("Left"))
		{
			// ...move left.
			transform.Translate (15 * Vector3.left * Time.deltaTime);
		}

		// If the right input is pressed...
		if (Input.GetButton ("Right"))
		{
			// ...move left.
			transform.Translate (15 * Vector3.right * Time.deltaTime);
		}
		
		// If the player's paddle is to the left of the screen...
		if (transform.position.x > 9.75f)
		{
			// ...reset the player's paddle to the top of the screen.
			transform.position = new Vector3 (9.75f, transform.position.y, transform.position.z);
		}
		
		// If the player's paddle is to the right of the screen...
		if (transform.position.x < -9.75f)
		{
			// ...reset the player's paddle to the bottom of the screen.
			transform.position = new Vector3 (-9.75f, transform.position.y, transform.position.z);
		}
	}
}
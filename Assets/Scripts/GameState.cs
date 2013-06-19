using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour
{
	// An enumeration of game states.
	public enum State
	{
		Pause,
		Play,
		GameOver
	};
	
	// Track the current state of the game.
	public State CurrentState { get; set; }
	
	// Use this for initialization
	void Start ()
	{
		// Initialize to the pause state.
		CurrentState = State.Pause;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

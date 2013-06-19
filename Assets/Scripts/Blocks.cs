using UnityEngine;
using System.Collections;

public class Blocks : MonoBehaviour
{
	// Store the location of the left and right walls.
	private float leftWall;
	private float rightWall;
	
	// Store the location of the top row of blocks.
	private float top;

	// Transforms for the three colors of blocks we will use.
	public Transform blueBlock;
	public Transform redBlock;
	public Transform greenBlock;
	
	// Use this for initialization
	void Start ()
	{
		// Initialize the course's boundaries.
		leftWall = -9.75f;
		rightWall = 9.75f;
		
		// Initialize the location of the top row of blocks.
		top = 13f;
		
		// Initialize the blocks on the screen.
		InitializeBlocks ();
	}

	// Initialize the blocks on the screen.
	public void InitializeBlocks ()
	{
		// Calculate the width of the court.
		float courtWidth = Mathf.Abs (leftWall)+ Mathf.Abs (rightWall);
		
		// Calculate the number of blocks that can fit in the court.
		float blockNum = Mathf.Floor (courtWidth / blueBlock.renderer.bounds.size.x);
		
		// Calculate the size of the gap between the maximum number of blocks court.
		float endGap = courtWidth - (blockNum * blueBlock.renderer.bounds.size.x);
		
		// Calculate the gap we want to place between each block.
		float blockGap = endGap / blockNum;
		
		// The y location of the current row of blocks.
		float yPosition = top;
		
		// Iterate through two rows of blocks...
		for (int row = 0; row < 2; row++)
		{
			// ...and iterate across the screen using the gap size and block width to guide us...
			for (float xPosition = leftWall; xPosition <= rightWall; xPosition = xPosition + blockGap + blueBlock.renderer.bounds.size.x)
			{				
				// Create the block in the game world, as a child of the "Blocks" container.
				(Instantiate (blueBlock, new Vector3 (xPosition, yPosition, 0), Quaternion.identity) as Transform).parent = transform;
			}
			
			// Update the new row's Y position.
			yPosition = yPosition - blueBlock.renderer.bounds.size.y - blockGap;
		}
		// Iterate through two rows of blocks...
		for (int row = 2; row < 4; row++)
		{
			// ...and iterate across the screen using the gap size and block width to guide us...
			for (float xPosition = leftWall; xPosition <= rightWall; xPosition = xPosition + blockGap + blueBlock.renderer.bounds.size.x)
			{				
				// Create the block in the game world, as a child of the "Blocks" container.
				(Instantiate (greenBlock, new Vector3 (xPosition, yPosition, 0), Quaternion.identity) as Transform).parent = transform;
			}
			
			// Update the new row's Y position.
			yPosition = yPosition - blueBlock.renderer.bounds.size.y - blockGap;
		}
		// Iterate through two rows of blocks...
		for (int row = 4; row < 6; row++)
		{
			// ...and iterate across the screen using the gap size and block width to guide us...
			for (float xPosition = leftWall; xPosition <= rightWall; xPosition = xPosition + blockGap + blueBlock.renderer.bounds.size.x)
			{				
				// Create the block in the game world, as a child of the "Blocks" container.
				(Instantiate (redBlock, new Vector3 (xPosition, yPosition, 0), Quaternion.identity) as Transform).parent = transform;
			}
			
			// Update the new row's Y position.
			yPosition = yPosition - blueBlock.renderer.bounds.size.y - blockGap;
		}
	}
}

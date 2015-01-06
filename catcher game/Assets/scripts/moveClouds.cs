using UnityEngine;
using System.Collections;

/*************************************************************************
 * Clouds move from the left to the right. At random locations on the left
 * edge of the screen, clouds ( the cloud sprite will be referenced in this	
 * script ) will generate with different scales and start to move at slightly 
 * different speeds to the right. Once they hit a collider to the right ( a destroyer ) 
 * they will die.
 * **********************************************************************/

public class moveClouds : MonoBehaviour {

	public Sprite cloud;

	// Use this for initialization
	void Start () {
		// find a random location on the screen height
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	/*************************************************************
	 * Generic function that returns the boundaries in world coordinates
	 * that can be used to place a sprite. This ensures that when the sprite
	 * is placed at an x,y location, 
	 ************************************************************/
	private float[] getHeight ( Sprite sprite , string direction )
	{
		Vector2 screenCo = new Vector2 (Screen.width, Screen.height);
		Vector2 worldCo = cam.ScreenToWorldPoint (screenCo);
		float clampWidth;
		float clampHeight;
		float[] boundary;

		if (direction == "width") 
		{
			clampWidth = (worldCo.x - sprite.bounds.extents.x) / 2
			boundary = { -clampWidth, clampWidth };
		}
		if (direction == "height")
		{
			clampHeight = (worldCo.x - sprite.bounds.extents.y) / 2
			boundary = { -clampHeight, clampHeight };
		}

		return boundary;
	}
}

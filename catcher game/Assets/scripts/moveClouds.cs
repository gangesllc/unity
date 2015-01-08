using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*************************************************************************
 * Clouds move from the left to the right. At random locations on the left
 * edge of the screen, clouds ( the cloud sprite will be referenced in this	
 * script ) will generate with different scales and start to move at slightly 
 * different speeds to the right. Once they hit a collider to the right ( a destroyer ) 
 * they will die.
 * **********************************************************************/

public class moveClouds : MonoBehaviour {

	public Sprite spriteCloud;
	public int spriteSizeVariations;
	private Camera cam;

	private Vector2[] spriteBoundaries;
	private List <Vector2> sb = new List <Vector2> () ;
	private GameObject cloudVector;

	// Use this for initialization
	void Start () {

		//find main camera reference
		cam = Camera.main;

		// Initialize the spriteBoundaries Vector based on the number of variations proposed
		spriteBoundaries = new Vector2[spriteSizeVariations];
//
//		spriteBoundaries [0] = new Vector2 (0.0f, 0.0f);
//		spriteBoundaries [1] = new Vector2 (0.0f, 0.0f);

		// find a random location on the screen height
		for (int i = 0; i < spriteSizeVariations; i ++)
		{
			spriteBoundaries[i] = getBoundaries (spriteCloud, i );
		}
		StartCoroutine ( spawnClouds());

	}
	
	// Update is called once per frame
	void Update () {


	}

	IEnumerator spawnClouds()
	{
		while (true) {

			// Select a random sprite cloud size to create
			int cloudSize = Random.Range (1, spriteSizeVariations );
			Vector2 spriteBoundary = spriteBoundaries [cloudSize];

			// Start with a new game object
			GameObject cloud = new GameObject ("cloud");

			// Add sprite renderer component to the empty game object
			cloud.AddComponent ("SpriteRenderer");

			//Make it a cloud
			cloud.GetComponent <SpriteRenderer> ().sprite = spriteCloud;

			// Position it at a random vertical location on the left edge..
			// Add 20 WCs to make the clouds start way out to the left so that it appears to slowly come 
			// from the left and disappear to the right
			cloud.transform.position = new Vector3 (-(spriteBoundary.x+40), Random.Range ( -spriteBoundary.y, spriteBoundary.y), 0.0f);

			// scale the cloud to the correct size
			cloud.transform.localScale = new Vector3(cloudSize,cloudSize,0);

			// Attach a script to the cloud game object so that it can independently move
			cloud.AddComponent ("moveCloud");

			// Yield for 3 seconds before creating a new cloud
			yield return new WaitForSeconds (15.0f);
		}
    }

	/*************************************************************
	 * Generic function that returns the boundaries in world coordinates
	 * that can be used to place a sprite. This ensures that when the sprite
	 * is placed at an x,y location, 
	 ************************************************************/
	private Vector2 getBoundaries ( Sprite sprite , int multiplier )
	{
		Vector2 screenCo = new Vector2 (Screen.width, Screen.height);
		Vector2 worldCo = cam.ScreenToWorldPoint (screenCo);
		float clampWidth;
		float clampHeight;
		Vector2 boundary = new Vector2(0.0f,0.0f);

			clampWidth = (worldCo.x - sprite.bounds.extents.x * multiplier) / 2;
			boundary.x = clampWidth;

			clampHeight = (worldCo.y - sprite.bounds.extents.y * multiplier) / 2;
			boundary.y = clampHeight;

		return boundary;
	}
}

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

	public Sprite spriteCloud;
	public Camera cam;

	private Vector2 spriteBoundariesX1;
	private Vector2 spriteBoundariesX2;
	private GameObject cloudVector;

	// Use this for initialization
	void Start () {
		// find a random location on the screen height
		spriteBoundariesX1 = getBoundaries( spriteCloud, 1 );
		spriteBoundariesX2 = getBoundaries( spriteCloud, 2 );

		//yield new WaitForSeconds ( 4 ) ; 
	}
	
	// Update is called once per frame
	void Update () {

		StartCoroutine ( spawnClouds());

	
	}

	IEnumerator spawnClouds()
	{
		yield return new WaitForSeconds(10.0f);
        GameObject cloud  = new GameObject ( "cloud" );
		cloud.AddComponent("SpriteRenderer");
		cloud.GetComponent <SpriteRenderer>().sprite = spriteCloud ;
		cloud.transform.position = new Vector3 ( spriteBoundariesX1.y,0.0f,0.0f );
		cloud.AddComponent("moveCloud");

		print ( "Time before slee = " + Time.time );
	

		print ( "Time after slee = " + Time.time );
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

			clampHeight = (worldCo.x - sprite.bounds.extents.y * multiplier) / 2;
			boundary.y = clampHeight;

		return boundary;
	}
}

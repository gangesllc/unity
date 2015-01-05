using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using System.Linq;
//using System;
using UnityEditor;

public class spawnBox : MonoBehaviour {

	public float leftEdge;
	public float rightEdge;
	float random;
	public Camera cam;
	public float catcherYPosition;
	private float catcherWidth;
	public int score; // Used to start at a big score for testing
	public Text scoreText;
	public Sprite[] sprites;
	private string[] nameSplitter = {"gem","1"};
	public Hashtable spriteWidth = new Hashtable();
	private Vector3 wCo ; 


	// Use this for initialization
	void Start () {
		Debug.Log ( "Spawn Box Started" );
		cam = Camera.main;
		// Call this function again if the catcher object changes.
		getCatcherWidth ();

		// Build the spriteWidth hash table that contains all sprites along with their width.
		// This ensures that no runtime calculations are required. 
		for (int i = 0; i < sprites.Length; i ++) 
		{
			spriteWidth.Add (sprites[i],sprites[i].bounds.extents.x);
		}

		wCo = cam.ScreenToWorldPoint (new Vector3(Screen.width, Screen.height, 0.0f));
	}
	
	// Update is called once per frame
	void Update () {
		//keyboardControl ();
		mouseControl ();
	}

	void FixedUpdate()
	{

	}

	void OnCollisionEnter2D(Collision2D coll)
	{

		Sprite sprite = sprites [Random.Range (1, 5)];
		float[] boundary = getScreenToWorld (sprite);
		random = Random.Range ( boundary[0] , boundary[1]);
		GameObject go = coll.gameObject;
		GameObject goD = Instantiate (go, new Vector3 (random, wCo.y,0.0f ), Quaternion.identity) as GameObject;
		goD.GetComponent<SpriteRenderer> ().sprite = sprite;
		goD.name = sprite.name;
		Destroy (go);



		string name;
		int scoreMultiplier;
		//string[] spriteNameAndLevel = sprite.name.Split ('_');

		// Get the action based on the name of the falling object
		name = go.name;
		// Its a gem. Increase points based on gem number
		if (name.StartsWith ("gem")) 
		{
			nameSplitter = name.Split('_');
		}

		scoreMultiplier = int.Parse (nameSplitter [1]);

		score += 1 * scoreMultiplier;
		scoreText.text = "Score : " + score;
	
	}

	void getCatcherWidth(){
		this.catcherWidth =  renderer.bounds.extents.x;
	}

	private float getCatcherWidth(Sprite sprite){

		return sprite.bounds.extents.x;

	}

	void keyboardControl()
	{
		 //Begin -- Keyboard Control
		if (Input.GetKey ("left")) 
		{
			gameObject.transform.Translate ( -.2f, 0, 0);
			return;
		}

		if (Input.GetKey ("right")) 
		{
			gameObject.transform.Translate ( .2f, 0, 0);
			return;
		}
		 //End - Keyboard Control
	}

	void mouseControl()
	{


		//Get the screen width and the corresponding World Co-ordinates
		Vector2 screenWidth = new Vector2 (Screen.width, Screen.height);
		Vector2 targetWidth = cam.ScreenToWorldPoint (screenWidth);
		//print ("Screenwidth = " + screenWidth + "targetWidth = " + targetWidth);
		//Screenwidth = (1179.0, 663.0)targetWidth = (28.8, 17.2)
		
		//Get the mouse pointer and the corresponding world co-ordinates
		Vector2 mp = Input.mousePosition;
		Vector2 worldPosition = cam.ScreenToWorldPoint (Input.mousePosition);
		
		// Set the Y position to a fixed vertical position
		float currentYPosition = catcherYPosition;//transform.position.y;

		// Substract the catcher width from the target X position
		targetWidth.x -= catcherWidth;
		
		//Clip the target X position to not go beyond the width of the screen.
		float targetXPosition;
		if (worldPosition.x > targetWidth.x) {
			targetXPosition = targetWidth.x;
		} else if (worldPosition.x < (targetWidth.x * -1.0f)) {
			targetXPosition = -targetWidth.x ;
		} else {
			targetXPosition = worldPosition.x;
		}
		
		Vector3 targetPosition = new Vector3 (targetXPosition,currentYPosition, 0.0f);
		
		transform.position = targetPosition;
		


	}

	private float[] getScreenToWorld ( Sprite sprite )
	{
		Vector2 screenCo = new Vector2 (Screen.width, Screen.height);
		Vector2 worldCo = cam.ScreenToWorldPoint (screenCo);
		float spriteWidth = getCatcherWidth (sprite);
		float clampWidth = (worldCo.x - spriteWidth) / 2;
		float[] boundary = { -clampWidth, clampWidth };
		//Debug.Break();
		print ("boundary = " + boundary[0] + " " + boundary[1]);
		return boundary;
	}



}

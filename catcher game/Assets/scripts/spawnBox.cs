using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class spawnBox : MonoBehaviour {

	public float leftEdge;
	public float rightEdge;
	float random;
	public Camera cam;
	public float catcherYPosition;
	private float catcherWidth;
	private int score;
	public Text scoreText;


	// Use this for initialization
	void Start () {
		Debug.Log ( "Spawn Box Started" );
		cam = Camera.main;

		// Call this function again if the catcher object changes.
		getCatcherWidth ();

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

		GameObject go;
		score += 1;
		scoreText.text = "Score : " + score;

		//GameObject goD;
		go = coll.gameObject;
		random = Random.Range ( leftEdge , rightEdge);
		//goD = Instantiate (go, new Vector3(random,7f,0f), Quaternion.identity) as GameObject;
		Instantiate (go, new Vector3 (random, 7f, 0f), Quaternion.identity);
		Destroy (go);

	
	}

	void getCatcherWidth(){
		this.catcherWidth =  renderer.bounds.extents.x;
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

}

using UnityEngine;
using System.Collections;

public class siva : MonoBehaviour {

	public string var1;
	public GameObject ground;

	// Use this for initialization
	void Start () {
		Debug.Log ("I just go started");

		//Get the components
		//Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		//rb.mass = 10;

		// Add a vertical force up
		//rb.AddForce ( Vector2.up * 10f);

		//Get a reference to the ground
		//Transform t = ground.transform;
		//Debug.Log (" Transform of the ground is " + t.position.x + t.position.y + t.position.z);

	}
	
	// Update is called once per frame
	void Update () {
		//print ("Hi");	
	}

	void fixedUpdate(){

	}
}

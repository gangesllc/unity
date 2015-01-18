using UnityEngine;
using System.Collections;

public class generateTerrain : MonoBehaviour {

	/***************************************************************************
	 * Assign this script to the runner. This will generate the terrain dynamically
	 * The terrain generation will always be with respect to the player's position 
	 * Step 1 : Raycast in the negative Y direction ( Assuming normaly gravity )
	 * 			// This should give the current terrain block on which the character is standing
	 * Step 2 : 
	 */


	// The list of prefabs that will be used to construct the terrain
	public GameObject[] prefabs;

	// The speed at which the terrain runs
	public float speed;


	private GameObject[] path;

	// This is the center piece of the terrain objects based on which the remaining path is built.
	// This is reset to the current terrain object after the terrain piece is traversed. 
	// The traversed traversed is recycled back to the object pool
	// All the terrain objects 
	private terrainObject rootTerrainObject;
	// Use this for initialization

	void Start () {
		path = new GameObject[10];
		terrainObject to = new terrainObject();

		//path[0] = new GameObject();
		path[0] = Instantiate (prefabs[0],new Vector3(0,0,0), Quaternion.identity) as GameObject;
		//path[1] = Instantiate (prefabs[1],new Vector3(0,0,6), Quaternion.identity) as GameObject;

		foreach ( Transform t in path[0].transform )
		{
			//print ("name is " + t.name);
		}

		Transform[] ts = path[0].GetComponentsInChildren  <Transform> ();
		foreach ( Transform t in ts )
		{
			print ( t.name );
		}

		//Transform t = path[0].transform.Find ("front");

		//path[0].transform.parent = gameObject.transform;
		//path[1].transform.parent = gameObject.transform;

	}
	
	// Update is called once per frame
	void Update () {

		for ( int i = 0 ; i < 2 ; i++ )
		{
			path[i].transform.Translate (Vector3.back * Time.deltaTime * speed);
		}
	}
}

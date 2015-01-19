using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class objectPooler : MonoBehaviour {


	/* A static reference to this object
	 * will be initialized in "awake" method
	 */
	public static objectPooler current;


	/* The type of game objects that are to be pooled. 
	 * Assign them to this variable at run time
	 */
	public List<GameObject> go;

	/* The count of the initial object pool count that would be initiated
	 * They would be extended later if required
	 */
	public int objectCount;

	/* Decides if the pool size should increase if more objects are needed
	 * Making this controllable via assignment
	 */
	public bool willGrow;

	/* a hashmap of the list of different game object types that are pooled. 
	 * the "key" is the prefab or the game object name. The corresponding list
	 * would contain a pool objects corresponding to that game object name
	 */
	public Dictionary <string,List<GameObject>> pool  ;



	// This is where the reference to the static self is created.
	void Awake ()
	{
		current = this;

		Debug.Log ("Awake of object pooler called");
		pool = new Dictionary<string, List<GameObject>> ();
		
		/* This is where the object pool is created
		 * for each game object type initiated in "go" 
		 * as many objects are created as "ObjectCount"
		 * The key is the object name and the value is the object in the dictionary
		 */
		for ( int i = 0 ; i < go.Count ; i++ )
		{
			
			// This list would contain the list of Game objects of a single type
			List<GameObject> list = new List<GameObject> ();
			for ( int j = 0 ; j < objectCount ; j++ ) 
			{
				GameObject obj = Instantiate(go[i]) as GameObject;
				obj.SetActive (false );
				/* This ensures that the clone will have the same name as the object it is clong
				 * Otherwise it will get the name followed by "(clone)" by default
				 */
				obj.name = go[i].name;
				list.Add (obj);
			}
			pool.Add (go[i].name , list);
			
		}
	}


	// Use this for initialization
	void Start () {


		print ("size of pool is " + pool.Count);
	}

	/* Get a list of game object names this pooler object contains
	 */
	public List<string> getNames ()
	{
		// Initialize a string array as big as the size of the pool count
		List<string> names = new List<string> ();

		// Iterate over the pool to get all the names and assign them to the names array
		foreach (KeyValuePair < string, List<GameObject> >  kvp in pool) 
		{
			names.Add(kvp.Key);
		}
		return names;
	}

	/* Used to get a game object from the pool
	 * The name of the game object should be unique
	 */
	public GameObject get ( string objName )
	{
		print ("get Object called");

		foreach (KeyValuePair<string,List<GameObject>> kvp1 in pool) 
		{

			// Found the key in the dictionary that matches the object name asked
			if (kvp1.Key == objName )
			{
				// Now get an inactive object and return it to the caller

				// Get the list assocaited with the key
				List<GameObject> list = kvp1.Value;

				// Iterate throught the list to find an inactive object
				for ( int i = 0 ; i < list.Count ; i ++ ) 
				{
					// Is object inactive
					if ( ! list[i].activeInHierarchy )
					{
						return list[i];
					}
				}

				// If inactive object not found, grow or return null
				if (willGrow == true )
				{
					//create a new game object of this type, put it in the pool and return it.
					// Pick the last object int he list as a source to clone
					GameObject obj = Instantiate(list[list.Count-1]) as GameObject;
					obj.SetActive (false );
					/* This ensures that the clone will have the same name as the object it is clong
				 	 * Otherwise it will get the name followed by "(clone)" by default
				     */
					obj.name = list[list.Count-1].name;
					list.Add (obj);
					return obj;
				}
				else
				{
					// We don't want the pool to grow. So, if we don't find any active objects in the pool, return null
					return null;
				}

			}
			else 
			{
				continue;
			}

		}

		/* Game Object of this type not found. What's the point. Just return null
		 */
		return null;

	}

	/* No need to explicitly push the object back into the pool. 
	 * We didn't pop it in the first place. 
	 * Just inactivate it. 	 * 
	 */
	public void put (GameObject gobj)
	{
		// Inactivate the game object. Thats it
		gobj.SetActive ( false );
	}
}

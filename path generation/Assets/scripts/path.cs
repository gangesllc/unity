using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class path : MonoBehaviour {

	private List<string> names;
	public	 GameObject root;


	// Use this for initialization
	void Start () {
		Debug.Log ("start of path called");
		root = new GameObject ();	
		root.transform.position = new Vector3 (0, 0, 0);
		GameObject go = new GameObject ();
		/* Get a list of all game objects that will constitute the path. The prefabs ( game objects ) that will 
		 * make up the path are initialized there
		 */
		names = objectPooler.current.getNames ();

		for (int i = 0; i < names.Count; i++) 
		{
			print ("game objects are " + i + " " + names[i]);
		}

		InvokeRepeating( "generatePath" , 0f,1f);

		// Print all the names
		//print ("Game objects in the pool are " + names.ToString);
		// Testing

		//get a cube
		//go = objectPooler.current.get ( 

//		go1 = Instantiate (go, new Vector3(1,1,1), Quaternion.identity) as GameObject;	
//		go2 = Instantiate (go,new Vector3(1,1,6), Quaternion.identity) as GameObject;
//		go1.transform.parent = gameObject.transform;
//		go2.transform.parent = gameObject.transform;
//
//		InvokeRepeating ("generatePath",0,1f);

		//print ( "new object is " + objectPooler.self.getObject("cube"));

//		GameObject str = objectPooler.current.get ("Cube");
//		print ("Game object returned is " + str.name);
//
//		print ("putting the game object back" + str.name);
//		objectPooler.current.put (str);


	}
	
	// Update is called once per frame
	void Update () {
//		for (int i = 0 ; i < gameObject.transform.childCount; i++)
//		{
//			Transform[] ts = gameObject.GetComponentsInChildren<Transform> ();
//			ts[i].Translate(Vector3.back * Time.deltaTime * pathSpeed);
//		}
//		//go1.transform.Translate (Vector3.back * Time.deltaTime * pathSpeed);
		root.transform.Translate (Vector3.back * Time.deltaTime * 5);
//		
	}

	void generatePath()
	{
//		GameObject go1 = Instantiate (go, new Vector3(1,1,1), Quaternion.identity) as GameObject;	
//		go1.transform.parent = gameObject.transform;
		string name = names [Random.Range (0,names.Count-1)];
		print ("object being created is " + name);
		GameObject go = objectPooler.current.get (name);
		if (go == null) 
		{
			print ("object of type " + name + " could not be created");
		}
		else
		{
			go.SetActive (true);
			go.transform.parent = root.transform;
		}
		
		
	}

	void Awake ()
	{
		print ("path awake");
	}

}

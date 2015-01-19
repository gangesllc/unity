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
		root.transform.position = new Vector3 (0, 0, 20);
		root.name = "root";
		root.AddComponent<MeshRenderer>();
		root.AddComponent<MeshFilter>();
		GameObject go = new GameObject ();
		/* Get a list of all game objects that will constitute the path. The prefabs ( game objects ) that will 
		 * make up the path are initialized there
		 */
		names = objectPooler.current.getNames ();

		for (int i = 0; i < names.Count; i++) 
		{
			print ("game objects are " + i + " " + names[i]);
		}

		InvokeRepeating( "generatePath" , 0f,.2f);
	

	}
	
	// Update is called once per frame
	void Update () {

		/* root.transform returns all the first level children. Don't use getComponentsInChildren here. It will return
		 * the entire hierarchy which we don't require
		 */
		foreach ( Transform children in root.transform )
		{
			//print ("children are " + children.position);


//			if (children.renderer.isVisible != true)
//			{
//				objectPooler.current.put ( children.gameObject );
//			}
//			else 
			{
				print ( children.name );
				children.transform.Translate ( Vector3.back * Time.deltaTime * 10 ) ;
			}
		}
	}

	void generatePath()
	{
//		GameObject go1 = Instantiate (go, new Vector3(1,1,1), Quaternion.identity) as GameObject;	
//		go1.transform.parent = gameObject.transform;
		pathDestroyer  pd;	
		string name = names [Random.Range (0,names.Count)];
		print ("object being created is " + name);
		GameObject go = objectPooler.current.get (name);
		if (go == null) 
		{
			print ("object of type " + name + " could not be created");
		}
		else
		{
			go.SetActive (true);
			pd = go.GetComponent<pathDestroyer>();
			if ( pd == null )
			{
				print ( "no path destroyer object attached. doing it now ");
				go.AddComponent("pathDestroyer");
            }
			go.transform.parent = root.transform;
			go.transform.localPosition = new Vector3(0,0,0 );
			//print ("new object created is at " + go.transform.position);
		}
		
		
	}

	void Awake ()
	{
		print ("path awake");
	}

}
